namespace KeybindAudio
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelVolume = new System.Windows.Forms.Label();
            this.groupBoxKeybindSounds = new System.Windows.Forms.GroupBox();
            this.groupBoxState = new System.Windows.Forms.GroupBox();
            this.radioButtonToggledOff = new System.Windows.Forms.RadioButton();
            this.radioButtonToggledOn = new System.Windows.Forms.RadioButton();
            this.labelIsEnabled = new System.Windows.Forms.Label();
            this.groupBoxKeybind = new System.Windows.Forms.GroupBox();
            this.comboBoxKey = new System.Windows.Forms.ComboBox();
            this.comboBoxModifier = new System.Windows.Forms.ComboBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelPlus = new System.Windows.Forms.Label();
            this.labelModifier = new System.Windows.Forms.Label();
            this.groupBoxSoundfile = new System.Windows.Forms.GroupBox();
            this.buttonSoundFileBrowseOff = new System.Windows.Forms.Button();
            this.labelSoundFilePathOff = new System.Windows.Forms.Label();
            this.labelSoundFileOff = new System.Windows.Forms.Label();
            this.labelSoundFileOn = new System.Windows.Forms.Label();
            this.buttonSoundFileBrowseOn = new System.Windows.Forms.Button();
            this.labelSoundFilePathOn = new System.Windows.Forms.Label();
            this.buttonRenameKeybind = new System.Windows.Forms.Button();
            this.buttonDeleteKeybind = new System.Windows.Forms.Button();
            this.buttonNewKeybind = new System.Windows.Forms.Button();
            this.listBoxKeybindSounds = new System.Windows.Forms.ListBox();
            this.openFileDialogSound = new System.Windows.Forms.OpenFileDialog();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripToolbar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemToggleShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.labelVolumeNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.groupBoxKeybindSounds.SuspendLayout();
            this.groupBoxState.SuspendLayout();
            this.groupBoxKeybind.SuspendLayout();
            this.groupBoxSoundfile.SuspendLayout();
            this.contextMenuStripToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(250, 42);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "KeybindAudio";
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(15, 51);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(134, 20);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "by piggeywig2000";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.LargeChange = 0;
            this.trackBarVolume.Location = new System.Drawing.Point(305, 64);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(145, 23);
            this.trackBarVolume.SmallChange = 0;
            this.trackBarVolume.TabIndex = 2;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolume.Value = 100;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            this.trackBarVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarVolume_MouseUp);
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(266, 68);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(42, 13);
            this.labelVolume.TabIndex = 3;
            this.labelVolume.Text = "Volume";
            // 
            // groupBoxKeybindSounds
            // 
            this.groupBoxKeybindSounds.Controls.Add(this.groupBoxState);
            this.groupBoxKeybindSounds.Controls.Add(this.labelIsEnabled);
            this.groupBoxKeybindSounds.Controls.Add(this.groupBoxKeybind);
            this.groupBoxKeybindSounds.Controls.Add(this.groupBoxSoundfile);
            this.groupBoxKeybindSounds.Controls.Add(this.buttonRenameKeybind);
            this.groupBoxKeybindSounds.Controls.Add(this.buttonDeleteKeybind);
            this.groupBoxKeybindSounds.Controls.Add(this.buttonNewKeybind);
            this.groupBoxKeybindSounds.Controls.Add(this.listBoxKeybindSounds);
            this.groupBoxKeybindSounds.Location = new System.Drawing.Point(12, 93);
            this.groupBoxKeybindSounds.Name = "groupBoxKeybindSounds";
            this.groupBoxKeybindSounds.Size = new System.Drawing.Size(460, 256);
            this.groupBoxKeybindSounds.TabIndex = 4;
            this.groupBoxKeybindSounds.TabStop = false;
            this.groupBoxKeybindSounds.Text = "Keybind Sounds";
            // 
            // groupBoxState
            // 
            this.groupBoxState.Controls.Add(this.radioButtonToggledOff);
            this.groupBoxState.Controls.Add(this.radioButtonToggledOn);
            this.groupBoxState.Location = new System.Drawing.Point(204, 193);
            this.groupBoxState.Name = "groupBoxState";
            this.groupBoxState.Size = new System.Drawing.Size(250, 41);
            this.groupBoxState.TabIndex = 9;
            this.groupBoxState.TabStop = false;
            this.groupBoxState.Text = "Current Toggle State";
            // 
            // radioButtonToggledOff
            // 
            this.radioButtonToggledOff.AutoSize = true;
            this.radioButtonToggledOff.Checked = true;
            this.radioButtonToggledOff.Location = new System.Drawing.Point(98, 18);
            this.radioButtonToggledOff.Name = "radioButtonToggledOff";
            this.radioButtonToggledOff.Size = new System.Drawing.Size(81, 17);
            this.radioButtonToggledOff.TabIndex = 1;
            this.radioButtonToggledOff.TabStop = true;
            this.radioButtonToggledOff.Text = "Toggled Off";
            this.radioButtonToggledOff.UseVisualStyleBackColor = true;
            this.radioButtonToggledOff.CheckedChanged += new System.EventHandler(this.radioButtonToggledOff_CheckedChanged);
            // 
            // radioButtonToggledOn
            // 
            this.radioButtonToggledOn.AutoSize = true;
            this.radioButtonToggledOn.Location = new System.Drawing.Point(9, 18);
            this.radioButtonToggledOn.Name = "radioButtonToggledOn";
            this.radioButtonToggledOn.Size = new System.Drawing.Size(81, 17);
            this.radioButtonToggledOn.TabIndex = 0;
            this.radioButtonToggledOn.Text = "Toggled On";
            this.radioButtonToggledOn.UseVisualStyleBackColor = true;
            this.radioButtonToggledOn.CheckedChanged += new System.EventHandler(this.radioButtonToggledOn_CheckedChanged);
            // 
            // labelIsEnabled
            // 
            this.labelIsEnabled.AutoSize = true;
            this.labelIsEnabled.Location = new System.Drawing.Point(204, 237);
            this.labelIsEnabled.Name = "labelIsEnabled";
            this.labelIsEnabled.Size = new System.Drawing.Size(46, 13);
            this.labelIsEnabled.TabIndex = 8;
            this.labelIsEnabled.Text = "Enabled";
            // 
            // groupBoxKeybind
            // 
            this.groupBoxKeybind.Controls.Add(this.comboBoxKey);
            this.groupBoxKeybind.Controls.Add(this.comboBoxModifier);
            this.groupBoxKeybind.Controls.Add(this.labelKey);
            this.groupBoxKeybind.Controls.Add(this.labelPlus);
            this.groupBoxKeybind.Controls.Add(this.labelModifier);
            this.groupBoxKeybind.Location = new System.Drawing.Point(204, 19);
            this.groupBoxKeybind.Name = "groupBoxKeybind";
            this.groupBoxKeybind.Size = new System.Drawing.Size(250, 73);
            this.groupBoxKeybind.TabIndex = 5;
            this.groupBoxKeybind.TabStop = false;
            this.groupBoxKeybind.Text = "Keybind";
            // 
            // comboBoxKey
            // 
            this.comboBoxKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKey.FormattingEnabled = true;
            this.comboBoxKey.Items.AddRange(new object[] {
            "None",
            "Cancel",
            "Back",
            "Tab",
            "LineFeed",
            "Clear",
            "Enter",
            "Pause",
            "CapsLock",
            "Escape",
            "Space",
            "PageUp",
            "PageDown",
            "End",
            "Home",
            "Left",
            "Up",
            "Right",
            "Down",
            "Select",
            "Print",
            "Execute",
            "PrintScreen",
            "Insert",
            "Delete",
            "Help",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "Multiply",
            "Add",
            "Separator",
            "Subtract",
            "Decimal",
            "Divide",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "F13",
            "F14",
            "F15",
            "F16",
            "F17",
            "F18",
            "F19",
            "F20",
            "F21",
            "F22",
            "F23",
            "F24",
            "NumLock",
            "Scroll",
            "VolumeMute",
            "VolumeDown",
            "VolumeUp",
            "MediaNextTrack",
            "MediaPreviousTrack",
            "MediaStop",
            "MediaPlayPause",
            "OemSemicolon",
            "OemPlus",
            "OemComma",
            "OemMinus",
            "OemPeriod",
            "OemQuestion",
            "OemTilde",
            "OemOpenBrackets",
            "OemPipe",
            "OemCloseBrackets",
            "OemQuotes",
            "OemBackslash"});
            this.comboBoxKey.Location = new System.Drawing.Point(142, 46);
            this.comboBoxKey.Name = "comboBoxKey";
            this.comboBoxKey.Size = new System.Drawing.Size(102, 21);
            this.comboBoxKey.TabIndex = 7;
            this.comboBoxKey.SelectionChangeCommitted += new System.EventHandler(this.comboBoxKey_SelectionChangeCommitted);
            // 
            // comboBoxModifier
            // 
            this.comboBoxModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModifier.FormattingEnabled = true;
            this.comboBoxModifier.Items.AddRange(new object[] {
            "None",
            "Ctrl",
            "Alt",
            "Ctrl + Alt",
            "Shift",
            "Ctrl + Shift",
            "Alt + Shift",
            "Ctrl + Alt + Shift"});
            this.comboBoxModifier.Location = new System.Drawing.Point(6, 46);
            this.comboBoxModifier.Name = "comboBoxModifier";
            this.comboBoxModifier.Size = new System.Drawing.Size(103, 21);
            this.comboBoxModifier.TabIndex = 6;
            this.comboBoxModifier.SelectionChangeCommitted += new System.EventHandler(this.comboBoxModifier_SelectionChangeCommitted);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(140, 30);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(28, 13);
            this.labelKey.TabIndex = 4;
            this.labelKey.Text = "Key:";
            // 
            // labelPlus
            // 
            this.labelPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlus.Location = new System.Drawing.Point(115, 46);
            this.labelPlus.Name = "labelPlus";
            this.labelPlus.Size = new System.Drawing.Size(21, 21);
            this.labelPlus.TabIndex = 2;
            this.labelPlus.Text = "+";
            this.labelPlus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelModifier
            // 
            this.labelModifier.AutoSize = true;
            this.labelModifier.Location = new System.Drawing.Point(3, 30);
            this.labelModifier.Name = "labelModifier";
            this.labelModifier.Size = new System.Drawing.Size(47, 13);
            this.labelModifier.TabIndex = 0;
            this.labelModifier.Text = "Modifier:";
            // 
            // groupBoxSoundfile
            // 
            this.groupBoxSoundfile.Controls.Add(this.buttonSoundFileBrowseOff);
            this.groupBoxSoundfile.Controls.Add(this.labelSoundFilePathOff);
            this.groupBoxSoundfile.Controls.Add(this.labelSoundFileOff);
            this.groupBoxSoundfile.Controls.Add(this.labelSoundFileOn);
            this.groupBoxSoundfile.Controls.Add(this.buttonSoundFileBrowseOn);
            this.groupBoxSoundfile.Controls.Add(this.labelSoundFilePathOn);
            this.groupBoxSoundfile.Location = new System.Drawing.Point(204, 98);
            this.groupBoxSoundfile.Name = "groupBoxSoundfile";
            this.groupBoxSoundfile.Size = new System.Drawing.Size(250, 89);
            this.groupBoxSoundfile.TabIndex = 4;
            this.groupBoxSoundfile.TabStop = false;
            this.groupBoxSoundfile.Text = "Sound File";
            // 
            // buttonSoundFileBrowseOff
            // 
            this.buttonSoundFileBrowseOff.Location = new System.Drawing.Point(189, 60);
            this.buttonSoundFileBrowseOff.Name = "buttonSoundFileBrowseOff";
            this.buttonSoundFileBrowseOff.Size = new System.Drawing.Size(55, 23);
            this.buttonSoundFileBrowseOff.TabIndex = 5;
            this.buttonSoundFileBrowseOff.Text = "Browse";
            this.buttonSoundFileBrowseOff.UseVisualStyleBackColor = true;
            this.buttonSoundFileBrowseOff.Click += new System.EventHandler(this.buttonSoundFileBrowseOff_Click);
            // 
            // labelSoundFilePathOff
            // 
            this.labelSoundFilePathOff.AutoSize = true;
            this.labelSoundFilePathOff.Location = new System.Drawing.Point(6, 70);
            this.labelSoundFilePathOff.Name = "labelSoundFilePathOff";
            this.labelSoundFilePathOff.Size = new System.Drawing.Size(68, 13);
            this.labelSoundFilePathOff.TabIndex = 4;
            this.labelSoundFilePathOff.Text = "SoundFileOff";
            // 
            // labelSoundFileOff
            // 
            this.labelSoundFileOff.AutoSize = true;
            this.labelSoundFileOff.Location = new System.Drawing.Point(6, 57);
            this.labelSoundFileOff.Name = "labelSoundFileOff";
            this.labelSoundFileOff.Size = new System.Drawing.Size(102, 13);
            this.labelSoundFileOff.TabIndex = 3;
            this.labelSoundFileOff.Text = "\"Toggle Off\" sound:";
            // 
            // labelSoundFileOn
            // 
            this.labelSoundFileOn.AutoSize = true;
            this.labelSoundFileOn.Location = new System.Drawing.Point(6, 16);
            this.labelSoundFileOn.Name = "labelSoundFileOn";
            this.labelSoundFileOn.Size = new System.Drawing.Size(102, 13);
            this.labelSoundFileOn.TabIndex = 2;
            this.labelSoundFileOn.Text = "\"Toggle On\" sound:";
            // 
            // buttonSoundFileBrowseOn
            // 
            this.buttonSoundFileBrowseOn.Location = new System.Drawing.Point(189, 20);
            this.buttonSoundFileBrowseOn.Name = "buttonSoundFileBrowseOn";
            this.buttonSoundFileBrowseOn.Size = new System.Drawing.Size(55, 23);
            this.buttonSoundFileBrowseOn.TabIndex = 1;
            this.buttonSoundFileBrowseOn.Text = "Browse";
            this.buttonSoundFileBrowseOn.UseVisualStyleBackColor = true;
            this.buttonSoundFileBrowseOn.Click += new System.EventHandler(this.buttonSoundFileBrowseOn_Click);
            // 
            // labelSoundFilePathOn
            // 
            this.labelSoundFilePathOn.AutoEllipsis = true;
            this.labelSoundFilePathOn.Location = new System.Drawing.Point(6, 29);
            this.labelSoundFilePathOn.Name = "labelSoundFilePathOn";
            this.labelSoundFilePathOn.Size = new System.Drawing.Size(177, 14);
            this.labelSoundFilePathOn.TabIndex = 0;
            this.labelSoundFilePathOn.Text = "SoundFileOn";
            // 
            // buttonRenameKeybind
            // 
            this.buttonRenameKeybind.Location = new System.Drawing.Point(138, 22);
            this.buttonRenameKeybind.Name = "buttonRenameKeybind";
            this.buttonRenameKeybind.Size = new System.Drawing.Size(60, 23);
            this.buttonRenameKeybind.TabIndex = 3;
            this.buttonRenameKeybind.Text = "Rename";
            this.buttonRenameKeybind.UseVisualStyleBackColor = true;
            this.buttonRenameKeybind.Click += new System.EventHandler(this.buttonRenameKeybind_Click);
            // 
            // buttonDeleteKeybind
            // 
            this.buttonDeleteKeybind.Location = new System.Drawing.Point(72, 22);
            this.buttonDeleteKeybind.Name = "buttonDeleteKeybind";
            this.buttonDeleteKeybind.Size = new System.Drawing.Size(60, 23);
            this.buttonDeleteKeybind.TabIndex = 2;
            this.buttonDeleteKeybind.Text = "Delete";
            this.buttonDeleteKeybind.UseVisualStyleBackColor = true;
            this.buttonDeleteKeybind.Click += new System.EventHandler(this.buttonDeleteKeybind_Click);
            // 
            // buttonNewKeybind
            // 
            this.buttonNewKeybind.Location = new System.Drawing.Point(7, 22);
            this.buttonNewKeybind.Name = "buttonNewKeybind";
            this.buttonNewKeybind.Size = new System.Drawing.Size(60, 23);
            this.buttonNewKeybind.TabIndex = 1;
            this.buttonNewKeybind.Text = "New";
            this.buttonNewKeybind.UseVisualStyleBackColor = true;
            this.buttonNewKeybind.Click += new System.EventHandler(this.buttonNewKeybind_Click);
            // 
            // listBoxKeybindSounds
            // 
            this.listBoxKeybindSounds.FormattingEnabled = true;
            this.listBoxKeybindSounds.Location = new System.Drawing.Point(6, 51);
            this.listBoxKeybindSounds.Name = "listBoxKeybindSounds";
            this.listBoxKeybindSounds.ScrollAlwaysVisible = true;
            this.listBoxKeybindSounds.Size = new System.Drawing.Size(192, 199);
            this.listBoxKeybindSounds.TabIndex = 0;
            this.listBoxKeybindSounds.Click += new System.EventHandler(this.listBoxKeybindSounds_Click);
            // 
            // openFileDialogSound
            // 
            this.openFileDialogSound.Title = "Sound file selection";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripToolbar;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "KeybindAudio";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseClick);
            // 
            // contextMenuStripToolbar
            // 
            this.contextMenuStripToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemToggleShow,
            this.toolStripMenuItemExit});
            this.contextMenuStripToolbar.Name = "contextMenuStripToolbar";
            this.contextMenuStripToolbar.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItemToggleShow
            // 
            this.toolStripMenuItemToggleShow.Name = "toolStripMenuItemToggleShow";
            this.toolStripMenuItemToggleShow.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemToggleShow.Text = "Show/Hide Window";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            // 
            // labelVolumeNumber
            // 
            this.labelVolumeNumber.Location = new System.Drawing.Point(447, 68);
            this.labelVolumeNumber.Name = "labelVolumeNumber";
            this.labelVolumeNumber.Size = new System.Drawing.Size(25, 13);
            this.labelVolumeNumber.TabIndex = 5;
            this.labelVolumeNumber.Text = "100";
            this.labelVolumeNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.labelVolumeNumber);
            this.Controls.Add(this.groupBoxKeybindSounds);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "KeybindAudio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.groupBoxKeybindSounds.ResumeLayout(false);
            this.groupBoxKeybindSounds.PerformLayout();
            this.groupBoxState.ResumeLayout(false);
            this.groupBoxState.PerformLayout();
            this.groupBoxKeybind.ResumeLayout(false);
            this.groupBoxKeybind.PerformLayout();
            this.groupBoxSoundfile.ResumeLayout(false);
            this.groupBoxSoundfile.PerformLayout();
            this.contextMenuStripToolbar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.GroupBox groupBoxKeybindSounds;
        private System.Windows.Forms.Button buttonRenameKeybind;
        private System.Windows.Forms.Button buttonDeleteKeybind;
        private System.Windows.Forms.Button buttonNewKeybind;
        private System.Windows.Forms.ListBox listBoxKeybindSounds;
        private System.Windows.Forms.OpenFileDialog openFileDialogSound;
        private System.Windows.Forms.GroupBox groupBoxSoundfile;
        private System.Windows.Forms.Button buttonSoundFileBrowseOn;
        private System.Windows.Forms.Label labelSoundFilePathOn;
        private System.Windows.Forms.GroupBox groupBoxKeybind;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.Label labelModifier;
        private System.Windows.Forms.Label labelPlus;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.ComboBox comboBoxKey;
        private System.Windows.Forms.ComboBox comboBoxModifier;
        private System.Windows.Forms.Label labelIsEnabled;
        private System.Windows.Forms.Label labelVolumeNumber;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripToolbar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemToggleShow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Label labelSoundFileOn;
        private System.Windows.Forms.Button buttonSoundFileBrowseOff;
        private System.Windows.Forms.Label labelSoundFilePathOff;
        private System.Windows.Forms.Label labelSoundFileOff;
        private System.Windows.Forms.GroupBox groupBoxState;
        private System.Windows.Forms.RadioButton radioButtonToggledOff;
        private System.Windows.Forms.RadioButton radioButtonToggledOn;
    }
}

