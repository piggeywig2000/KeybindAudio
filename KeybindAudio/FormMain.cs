using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Flac;
using NAudio.Vorbis;
using WindowsInput;
using WindowsInput.Native;

namespace KeybindAudio
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// The configuration file containing volume and keybinds
        /// </summary>
        private Configuration config = ConfigParser.LoadFile(Useful.pathToConfig);
        /// <summary>
        /// The currently selected keybind
        /// </summary>
        private KeybindSound selectedKeybind { get
            {
                KeybindSound soundToReturn = null;

                foreach(KeybindSound bind in config.KeybindSounds)
                {
                    if (soundToReturn != null) bind.IsSelected = false;
                    else
                    {
                        if (bind.IsSelected)
                        {
                            soundToReturn = bind;
                        }
                    }
                }

                return soundToReturn;
            } }

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the form first loads, register click events, set some control's values, register keybinds, and update listbox
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //Set the menuitem's click events
            contextMenuStripToolbar.Items[0].Click += ShowHideContextItem_Click;
            contextMenuStripToolbar.Items[1].Click += ExitContextItem_Click;

            //Set some values
            trackBarVolume.Value = config.Volume;
            labelVolumeNumber.Text = config.Volume.ToString();

            //Setup keybinds
            foreach(KeybindSound bind in config.KeybindSounds)
            {
                //If it fails, set the keybind to none (done automatically) and overwrite the config file
                if (!bind.UpdateHotkey(Handle))
                {
                    ConfigParser.SaveFile(Useful.pathToConfig, config);
                }
                bind.HotkeyTriggered += Bind_HotkeyTriggered;
            }

            //Populate listbox
            UpdateKeybindListboxAndControls();
        }

        /// <summary>
        /// When the volume is done being adjusted, set any playing audio's volumes and overwrite the config file
        /// </summary>
        private void trackBarVolume_MouseUp(object sender, MouseEventArgs e)
        {
            labelVolumeNumber.Text = trackBarVolume.Value.ToString();
            foreach(KeybindSound bind in config.KeybindSounds)
            {
                if (bind.AudioPlayer != null)
                {
                    if (bind.AudioPlayer.PlaybackState == PlaybackState.Playing)
                    {
                        bind.AudioPlayer.Volume = (float)trackBarVolume.Value / 100f;
                    }
                }
            }

            config.Volume = trackBarVolume.Value;
            ConfigParser.SaveFile(Useful.pathToConfig, config);
        }

        /// <summary>
        /// When the volume is being adjusted, change the number on the right
        /// </summary>
        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            labelVolumeNumber.Text = trackBarVolume.Value.ToString();
        }

        /// <summary>
        /// Updates the is enabled control depending on whether the selecte keybind is enabled
        /// </summary>
        private void UpdateIsEnabledLabel()
        {
            if (selectedKeybind.IsEnabled)
            {
                labelIsEnabled.Text = "Keybind Enabled";
                labelIsEnabled.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                labelIsEnabled.Text = "Keybind Disabled";
                labelIsEnabled.ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// Repopulate the keybind listbox and the controls next to it about the currently selected keybind
        /// </summary>
        private void UpdateKeybindListboxAndControls()
        {
            //Clear listbox, sort the items, repopulate the listbox, then set the selected index
            listBoxKeybindSounds.Items.Clear();
            config.KeybindSounds = config.KeybindSounds.OrderBy(x => x.Name).ToList();

            foreach (KeybindSound bind in config.KeybindSounds)
            {
                listBoxKeybindSounds.Items.Add(bind.Name);
            }
            if (config.KeybindSounds.IndexOf(selectedKeybind) > -1) ignoreListboxIndexChange = true;
            listBoxKeybindSounds.SelectedIndex = config.KeybindSounds.IndexOf(selectedKeybind);

            //Enable or disable elements depending on if there is a selected element
            bool disableOrEnable = listBoxKeybindSounds.SelectedIndex != -1;

            buttonDeleteKeybind.Enabled = disableOrEnable;
            buttonRenameKeybind.Enabled = disableOrEnable;

            comboBoxModifier.Enabled = disableOrEnable;
            comboBoxKey.Enabled = disableOrEnable;
            labelIsEnabled.Visible = disableOrEnable;

            labelSoundFilePathOn.Visible = disableOrEnable;
            buttonSoundFileBrowseOn.Enabled = disableOrEnable;
            labelSoundFilePathOff.Visible = disableOrEnable;
            buttonSoundFileBrowseOff.Enabled = disableOrEnable;

            radioButtonToggledOn.Enabled = disableOrEnable;
            radioButtonToggledOff.Enabled = disableOrEnable;

            if (disableOrEnable)
            {
                comboBoxModifier.SelectedIndex = selectedKeybind.KeyModifier;
                KeysConverter converter = new KeysConverter();
                comboBoxKey.SelectedIndex = comboBoxKey.FindStringExact(converter.ConvertToString(selectedKeybind.Keybind));

                UpdateIsEnabledLabel();

                labelSoundFilePathOn.Text = Path.GetFileName(selectedKeybind.PathToSoundFileOn);
                labelSoundFilePathOff.Text = Path.GetFileName(selectedKeybind.PathToSoundFileOff);

                radioButtonToggledOn.Checked = selectedKeybind.ToggledOn;
                radioButtonToggledOff.Checked = !selectedKeybind.ToggledOn;
            }
        }

        /// <summary>
        /// Adds a new keybind and updates the keybind listbox. Overwrites the config file
        /// </summary>
        private void buttonNewKeybind_Click(object sender, EventArgs e)
        {
            //Make this new one the selected one
            foreach (KeybindSound bind in config.KeybindSounds) bind.IsSelected = false;
            config.KeybindSounds.Add(new KeybindSound { IsSelected = true });

            //Update the listbox
            UpdateKeybindListboxAndControls();

            //Register the HotkeyTriggered event
            selectedKeybind.HotkeyTriggered += Bind_HotkeyTriggered;

            //Overwrite the config file
            ConfigParser.SaveFile(Useful.pathToConfig, config);
        }

        /// <summary>
        /// Deletes the currently seleced keybind and updates the keybind listbox. Overwrites the config file
        /// </summary>
        private void buttonDeleteKeybind_Click(object sender, EventArgs e)
        {
            //Stop audio playback and dispose of the hotkey, which unregisters it
            StopAudioIfPlaying(selectedKeybind);
            if (selectedKeybind.HotKey != null) selectedKeybind.HotKey.Dispose();

            //Remove the selected keybind and update the listbox
            config.KeybindSounds.RemoveAt(listBoxKeybindSounds.SelectedIndex);
            UpdateKeybindListboxAndControls();

            //Overwrite the config file
            ConfigParser.SaveFile(Useful.pathToConfig, config);
        }

        /// <summary>
        /// Renames the currently selected keybind and updates the keybind listbox. Overwrites the config file
        /// </summary>
        private void buttonRenameKeybind_Click(object sender, EventArgs e)
        {
            //Prompt for new name. Return if nothing was entered
            string newRenameText = Microsoft.VisualBasic.Interaction.InputBox("Enter a new name:", "Rename", selectedKeybind.Name);
            if (newRenameText == "") return;

            //Set the name of the currently selected keybind and update the listbox
            selectedKeybind.Name = newRenameText;
            UpdateKeybindListboxAndControls();

            //Overwrite the config file
            ConfigParser.SaveFile(Useful.pathToConfig, config);
        }

        /// <summary>
        /// When the listbox is clicked, update the currently selected item and update the listbox. Overwrite the config file
        /// </summary>
        private void listBoxKeybindSounds_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Whether to ignore a change in the selected index of the listbox. Used to change the index without triggering the event
        /// </summary>
        bool ignoreListboxIndexChange = false;

        /// <summary>
        /// When the selected index is changed in the listbox, update the currently selected item and update the listbox. Overwrite the config file
        /// </summary>
        private void listBoxKeybindSounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignoreListboxIndexChange)
            {
                ignoreListboxIndexChange = false;
                return;
            }

            //Set all keybinds to not selected
            foreach (KeybindSound bind in config.KeybindSounds) bind.IsSelected = false;

            //Check first that something is selected
            if (listBoxKeybindSounds.SelectedIndex > -1)
            {
                //Update the currently selected keybind
                config.KeybindSounds[listBoxKeybindSounds.SelectedIndex].IsSelected = true;

                //Update the listbox
                UpdateKeybindListboxAndControls();

                //Overwrite the config file
                ConfigParser.SaveFile(Useful.pathToConfig, config);
            }
        }




        /// <summary>
        /// When the key modifier is changed, update the key modifier, register the new keybind, and overwrite the config file
        /// </summary>
        private void comboBoxModifier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Set the modifier
            selectedKeybind.KeyModifier = (byte)comboBoxModifier.SelectedIndex;

            //If updating the hotkey fails, update the combo box to show the hotkey being reset to none
            if (!selectedKeybind.UpdateHotkey(this.Handle))
            {
                comboBoxKey.SelectedIndex = 0;
            }

            //Overwrite the config file
            ConfigParser.SaveFile(Useful.pathToConfig, config);

            UpdateIsEnabledLabel();
        }

        private void comboBoxKey_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Set the keybind to the Keys enum value of the currently selected keybind
            KeysConverter converter = new KeysConverter();
            selectedKeybind.Keybind = (int)((Keys)converter.ConvertFromString(comboBoxKey.Text));

            //If updating the hotkey fails, update the combo box to show the hotkey being reset to none
            if (!selectedKeybind.UpdateHotkey(this.Handle))
            {
                comboBoxKey.SelectedIndex = 0;
            }

            //Overwrite the config file
            ConfigParser.SaveFile(Useful.pathToConfig, config);

            UpdateIsEnabledLabel();
        }



        /// <summary>
        /// Stops audio from a particular keybind
        /// </summary>
        /// <param name="bindToStop">The keybind to stop</param>
        private void StopAudioIfPlaying(KeybindSound bindToStop)
        {
            if (bindToStop.AudioPlayer != null)
            {
                if (bindToStop.AudioPlayer.PlaybackState == PlaybackState.Playing)
                {
                    bindToStop.AudioPlayer.Stop();
                    bindToStop.AudioReader.Dispose();
                    bindToStop.AudioReader = null;
                    bindToStop.AudioPlayer.Dispose();
                    bindToStop.AudioPlayer = null;
                }
            }
        }

        /// <summary>
        /// When a hotkey is triggered, play its sound
        /// </summary>
        private void Bind_HotkeyTriggered(object sender, EventArgs e)
        {
            //Get the bind that was triggered
            KeybindSound bindTriggered = (KeybindSound)sender;
            if (!config.KeybindSounds.Contains(bindTriggered)) return;

            System.Diagnostics.Debug.WriteLine("Triggered: " + bindTriggered.PathToSoundFileOn);

            //Change the toggle state and overwrite the config
            bindTriggered.ToggledOn = !bindTriggered.ToggledOn;
            if (selectedKeybind.Equals(bindTriggered))
            {
                radioButtonToggledOn.Checked = bindTriggered.ToggledOn;
                radioButtonToggledOff.Checked = !bindTriggered.ToggledOn;
            }
            ConfigParser.SaveFile(Useful.pathToConfig, config);

            //Stop playback if already running
            StopAudioIfPlaying(bindTriggered);

            //Create the file reader
            string pathToUse;
            if (bindTriggered.ToggledOn) pathToUse = bindTriggered.PathToSoundFileOn;
            else pathToUse = bindTriggered.PathToSoundFileOff;

            try
            {
                switch (Path.GetExtension(pathToUse))
                {
                    case ".wav":
                        bindTriggered.AudioReader = new WaveFileReader(pathToUse);
                        break;
                    case ".mp3":
                        bindTriggered.AudioReader = new Mp3FileReader(pathToUse);
                        break;
                    case ".aiff":
                        bindTriggered.AudioReader = new AiffFileReader(pathToUse);
                        break;
                    case ".flac":
                        bindTriggered.AudioReader = new FlacReader(pathToUse);
                        break;
                    case ".ogg":
                        bindTriggered.AudioReader = new VorbisWaveReader(pathToUse);
                        break;
                    default:
                        return;
                }
            }
            catch (Exception)
            {
                return;
            }
            

            //Create the playback stream
            bindTriggered.AudioPlayer = new WaveOutEvent();
            bindTriggered.AudioPlayer.PlaybackStopped += (o, args) =>
            {
                if (bindTriggered.AudioReader != null)
                {
                    if (bindTriggered.AudioPlayer.PlaybackState == PlaybackState.Stopped)
                    {
                        bindTriggered.AudioReader.Dispose();
                        bindTriggered.AudioReader = null;
                        bindTriggered.AudioPlayer.Dispose();
                        bindTriggered.AudioPlayer = null;
                    }
                }
            };
            bindTriggered.AudioPlayer.Init(bindTriggered.AudioReader);
            bindTriggered.AudioPlayer.Volume = (float)config.Volume / 100.0f;
            bindTriggered.AudioPlayer.Play();

            //Temporarily disable the hotkey and send the keypress again
            bindTriggered.HotKey.Dispose();
            bindTriggered.HotKey = null;

            InputSimulator sim = new InputSimulator();

            List<VirtualKeyCode> modifiers = new List<VirtualKeyCode>();
            //Check for ctrl
            if ((bindTriggered.KeyModifier & 1) != 0)
            {
                modifiers.Add(VirtualKeyCode.CONTROL);
            }
            //Check for alt
            if ((bindTriggered.KeyModifier & 2) != 0)
            {
                modifiers.Add(VirtualKeyCode.MENU);
            }
            //Check for shift
            if ((bindTriggered.KeyModifier & 4) != 0)
            {
                modifiers.Add(VirtualKeyCode.SHIFT);
            }

            sim.Keyboard.ModifiedKeyStroke(modifiers, (VirtualKeyCode)bindTriggered.Keybind);

            bindTriggered.UpdateHotkey(this.Handle);
        }




        /// <summary>
        /// Shows the file dialogue
        /// </summary>
        /// <param name="initialPath">The path to start at. Typically ther path of the last selected file</param>
        /// <returns></returns>
        private string ShowFileDialogue(string initialPath)
        {
            //Set the initial filename and directory to what was provided in the initialPath.
            //If they don't exist, set them to empty
            try
            {
                string directory = Path.GetDirectoryName(initialPath);
                if (Directory.Exists(directory))
                {
                    openFileDialogSound.InitialDirectory = directory;

                    if (File.Exists(selectedKeybind.PathToSoundFileOn))
                    {
                        openFileDialogSound.FileName = Path.GetFileName(selectedKeybind.PathToSoundFileOn);
                    }
                    else
                    {
                        openFileDialogSound.FileName = "";
                    }
                }
                else
                {
                    openFileDialogSound.InitialDirectory = "";
                    openFileDialogSound.FileName = "";
                }
            }
            catch (ArgumentException)
            {
                openFileDialogSound.InitialDirectory = "";
                openFileDialogSound.FileName = "";
            }

            //Check that the user clicked OK and not cancel. If not, return nothing
            if (openFileDialogSound.ShowDialog() == DialogResult.OK)
            {
                //Check that the file extension is valid. If not, return nothing
                if (!Useful.supportedExtensions.Contains(Path.GetExtension(openFileDialogSound.FileName)))
                {
                    MessageBox.Show("Unsupported file extension. Supported file extensions are: " + string.Join(" ", Useful.supportedExtensions), "Error", MessageBoxButtons.OK);
                    return "";
                }

                //Return the path to the file
                return openFileDialogSound.FileName;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// When the browse for toggle on sound is clicked, show the dialogue, then if successful set properties and overwrite config
        /// </summary>
        private void buttonSoundFileBrowseOn_Click(object sender, EventArgs e)
        {
            if (ShowFileDialogue(selectedKeybind.PathToSoundFileOn) != "")
            {
                //Change properties and control labels
                selectedKeybind.PathToSoundFileOn = openFileDialogSound.FileName;
                labelSoundFilePathOn.Text = Path.GetFileName(selectedKeybind.PathToSoundFileOn);
                UpdateIsEnabledLabel();

                //Overwrite config
                ConfigParser.SaveFile(Useful.pathToConfig, config);
            }
        }

        /// <summary>
        /// When the browse for toggle off sound is clicked, show the dialogue, then if successful set properties and overwrite config
        /// </summary>
        private void buttonSoundFileBrowseOff_Click(object sender, EventArgs e)
        {
            if (ShowFileDialogue(selectedKeybind.PathToSoundFileOff) != "")
            {
                //Change properties and control labels
                selectedKeybind.PathToSoundFileOff = openFileDialogSound.FileName;
                labelSoundFilePathOff.Text = Path.GetFileName(selectedKeybind.PathToSoundFileOff);
                UpdateIsEnabledLabel();

                //Overwrite config
                ConfigParser.SaveFile(Useful.pathToConfig, config);
            }
        }




        /// <summary>
        /// When the toggled on radio button is clicked, set properties and overwrite config
        /// </summary>
        private void radioButtonToggledOn_CheckedChanged(object sender, EventArgs e)
        {
            selectedKeybind.ToggledOn = radioButtonToggledOn.Checked;
            ConfigParser.SaveFile(Useful.pathToConfig, config);
        }

        /// <summary>
        /// When the toggled off radio button is clicked, set properties and overwrite config
        /// </summary>
        private void radioButtonToggledOff_CheckedChanged(object sender, EventArgs e)
        {
            selectedKeybind.ToggledOn = !radioButtonToggledOff.Checked;
            ConfigParser.SaveFile(Useful.pathToConfig, config);
        }



        /// <summary>
        /// If the form is showing, minimise it and remove from taskbar. If not, open it up and put it on the taskbar
        /// </summary>
        private void ToggleFormShowHide()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        /// When the toolbar icon is clicked, toggle the form's visibility
        /// </summary>
        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleFormShowHide();
            }
        }

        /// <summary>
        /// When the show/hide button is clicked in the toolbar icon's context menu, toggle the form's visibility
        /// </summary>
        private void ShowHideContextItem_Click(object sender, EventArgs e)
        {
            ToggleFormShowHide();
        }

        /// <summary>
        /// Flag that is set when we should actually exit when the form is closing
        /// </summary>
        private bool shouldActuallyClose = false;

        /// <summary>
        /// When the exit button is clicked in the toolbar icon's context menu, set the shouldActuallyClose flag and exit
        /// </summary>
        private void ExitContextItem_Click(object sender, EventArgs e)
        {
            shouldActuallyClose = true;
            Application.Exit();
        }

        /// <summary>
        /// When the form is closing, cancel it and toggle the visibilty unless the shouldActuallyClose flag is set or if windows is shutting down
        /// </summary>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!shouldActuallyClose && e.CloseReason != CloseReason.WindowsShutDown && e.CloseReason != CloseReason.TaskManagerClosing)
            {
                e.Cancel = true;
                ToggleFormShowHide();
                notifyIconMain.ShowBalloonTip(3000, "KeybindAudio is running in the background", " ", ToolTipIcon.None);
            }
        }
    }
}
