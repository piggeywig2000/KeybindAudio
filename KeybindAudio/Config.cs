using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace KeybindAudio
{
    /// <summary>
    /// The config file
    /// </summary>
    class Configuration
    {
        /// <summary>
        /// The volume from 0 to 100
        /// </summary>
        public int Volume { get; set; } = 100;

        /// <summary>
        /// A list of keybind sounds
        /// </summary>
        public List<KeybindSound> KeybindSounds { get; set; } = new List<KeybindSound>();
    }

    /// <summary>
    /// Useful constants and readonlys
    /// </summary>
    public static class Useful
    {
        public static int currentId = 4636;
        public const string pathToConfig = "config.json";
        public static readonly string[] supportedExtensions = new string[] { ".wav", ".mp3", ".aiff", ".flac", ".ogg" };
    }

    /// <summary>
    /// A keybind sounds
    /// </summary>
    class KeybindSound
    {
        /// <summary>
        /// The name of the keybind
        /// </summary>
        public string Name { get; set; } = "Untitled";
        /// <summary>
        /// Whether it is selected
        /// </summary>
        public bool IsSelected { get; set; } = false;
        /// <summary>
        /// The Keys enum value representing the key required to trigger the hotkey
        /// </summary>
        public int Keybind { get; set; } = 0;
        /// <summary>
        /// Bitmask showing the modifier keys required to trigger the hotkey.
        /// From least to most significant bit: Ctrl, Alt, Shift
        /// </summary>
        public byte KeyModifier { get; set; } = 3;

        /// <summary>
        /// The hotkey object representing the hotkey registered through the windows
        /// </summary>
        [JsonIgnore]
        public HotKeyRegister HotKey { get; set; } = null;

        /// <summary>
        /// The path to the toggle on sound effect
        /// </summary>
        public string PathToSoundFileOn { get; set; } = "";
        /// <summary>
        /// The path to the toggle off sound effect
        /// </summary>
        public string PathToSoundFileOff { get; set; } = "";

        /// <summary>
        /// True if this sound effect is currently toggled on, false if not
        /// </summary>
        public bool ToggledOn { get; set; } = false;

        /// <summary>
        /// The audio playback object
        /// </summary>
        [JsonIgnore]
        public NAudio.Wave.WaveOutEvent AudioPlayer { get; set; } = null;
        /// <summary>
        /// The audio file reader object
        /// </summary>
        [JsonIgnore]
        public NAudio.Wave.WaveStream AudioReader { get; set; } = null;

        /// <summary>
        /// Triggered when the hotkey is pressed
        /// </summary>
        public event EventHandler HotkeyTriggered;

        /// <summary>
        /// Whether this is enabled. Dependent on the required properties being set
        /// </summary>
        public bool IsEnabled { get => Keybind != 0 && KeyModifier != 0 && PathToSoundFileOn != "" && PathToSoundFileOff != ""; }

        /// <summary>
        /// Updates the hotkey, re-registering it with the windows API
        /// </summary>
        /// <param name="handle">The Handle of the WinForms form</param>
        /// <returns>True if it succeeded, false if not</returns>
        public bool UpdateHotkey(IntPtr handle)
        {
            //If the hotkey is set, dispose of it
            if (HotKey != null) HotKey.Dispose();

            //If the hotkey is not none, set it
            if (Keybind != 0 && KeyModifier != 0)
            {
                //Create a new keymodifier object to pass to the windows API
                KeyModifiers newKeymods = new KeyModifiers();

                //If the key modifier is 0 (shouldn't happen), then newKeymods is None
                if (KeyModifier == 0)
                {
                    newKeymods = KeyModifiers.None;
                }
                //If not, set the newKeymods' values
                else
                {
                    //Check for ctrl
                    if ((KeyModifier & 1) != 0)
                    {
                        newKeymods = newKeymods | KeyModifiers.Control;
                    }

                    //Check for alt
                    if ((KeyModifier & 2) != 0)
                    {
                        newKeymods = newKeymods | KeyModifiers.Alt;
                    }

                    //Check for shift
                    if ((KeyModifier & 4) != 0)
                    {
                        newKeymods = newKeymods | KeyModifiers.Shift;
                    }
                }

                //Attempt to register the hotkey with the windows API
                try
                {
                    HotKey = new HotKeyRegister(handle, Useful.currentId, newKeymods, (Keys)Keybind);
                }
                //If it failed, set the hotkey to null and the keybind to None. Return false
                catch (ApplicationException)
                {
                    HotKey = null;
                    Keybind = 0;
                    return false;
                }

                //Subscribe the the event
                HotKey.HotKeyPressed += (object sender, EventArgs empty) =>
                {
                    if (IsEnabled)
                    {
                        HotkeyTriggered.Invoke(this, EventArgs.Empty);
                    }
                };
                Useful.currentId++;

                System.Diagnostics.Debug.WriteLine("Updated Hotkey: " + PathToSoundFileOn);
            }
            //If the hotkey is none, set the current hotkey object to null
            else
            {
                HotKey = null;
            }

            //If we got here, it was successful. Return true
            return true;
        }
    }

    /// <summary>
    /// Provides methods for loading and saving config files
    /// </summary>
    static class ConfigParser
    {
        /// <summary>
        /// Load a config file
        /// </summary>
        /// <param name="pathToFile">The path to the json file</param>
        /// <returns>A Configuration object representing the configuration in the config file</returns>
        public static Configuration LoadFile(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                SaveFile(pathToFile, new Configuration());
            }

            string jsonText = File.ReadAllText(pathToFile);

            return JsonConvert.DeserializeObject<Configuration>(jsonText);
        }

        /// <summary>
        /// Save a config file
        /// </summary>
        /// <param name="pathToFile">The path to the json file</param>
        /// <param name="configToSave">A Configuration object representing the configuration to save in the config file</param>
        public static void SaveFile(string pathToFile, Configuration configToSave)
        {
            string jsonText = JsonConvert.SerializeObject(configToSave);

            File.WriteAllText(pathToFile, jsonText);
        }
    }
}
