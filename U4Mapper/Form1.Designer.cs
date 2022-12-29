namespace U4Mapper
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbParty = new System.Windows.Forms.CheckBox();
            this.pnlPartyPositions = new System.Windows.Forms.Panel();
            this.rbWest = new System.Windows.Forms.RadioButton();
            this.rbSouth = new System.Windows.Forms.RadioButton();
            this.rbEast = new System.Windows.Forms.RadioButton();
            this.rbNorth = new System.Windows.Forms.RadioButton();
            this.cbTrigger4 = new System.Windows.Forms.CheckBox();
            this.cbTrigger3 = new System.Windows.Forms.CheckBox();
            this.cbTrigger2 = new System.Windows.Forms.CheckBox();
            this.cbTrigger1 = new System.Windows.Forms.CheckBox();
            this.cbMonsters = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picRoom = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstLevels = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbDungeons = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stuffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlPartyPositions.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(524, 468);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(80, 24);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1059, 451);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbParty);
            this.tabPage1.Controls.Add(this.pnlPartyPositions);
            this.tabPage1.Controls.Add(this.cbTrigger4);
            this.tabPage1.Controls.Add(this.cbTrigger3);
            this.tabPage1.Controls.Add(this.cbTrigger2);
            this.tabPage1.Controls.Add(this.cbTrigger1);
            this.tabPage1.Controls.Add(this.cbMonsters);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lstRooms);
            this.tabPage1.Controls.Add(this.trackBar1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.lstLevels);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.cmbDungeons);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1051, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dungeons";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbParty
            // 
            this.cbParty.AutoSize = true;
            this.cbParty.Location = new System.Drawing.Point(576, 216);
            this.cbParty.Name = "cbParty";
            this.cbParty.Size = new System.Drawing.Size(75, 17);
            this.cbParty.TabIndex = 24;
            this.cbParty.Text = "Party Start";
            this.cbParty.UseVisualStyleBackColor = true;
            this.cbParty.CheckedChanged += new System.EventHandler(this.cbParty_CheckedChanged);
            // 
            // pnlPartyPositions
            // 
            this.pnlPartyPositions.Controls.Add(this.rbWest);
            this.pnlPartyPositions.Controls.Add(this.rbSouth);
            this.pnlPartyPositions.Controls.Add(this.rbEast);
            this.pnlPartyPositions.Controls.Add(this.rbNorth);
            this.pnlPartyPositions.Location = new System.Drawing.Point(596, 232);
            this.pnlPartyPositions.Name = "pnlPartyPositions";
            this.pnlPartyPositions.Size = new System.Drawing.Size(56, 64);
            this.pnlPartyPositions.TabIndex = 24;
            // 
            // rbWest
            // 
            this.rbWest.AutoSize = true;
            this.rbWest.Location = new System.Drawing.Point(0, 48);
            this.rbWest.Name = "rbWest";
            this.rbWest.Size = new System.Drawing.Size(50, 17);
            this.rbWest.TabIndex = 4;
            this.rbWest.TabStop = true;
            this.rbWest.Text = "West";
            this.rbWest.UseVisualStyleBackColor = true;
            this.rbWest.CheckedChanged += new System.EventHandler(this.rbWest_CheckedChanged);
            // 
            // rbSouth
            // 
            this.rbSouth.AutoSize = true;
            this.rbSouth.Location = new System.Drawing.Point(0, 32);
            this.rbSouth.Name = "rbSouth";
            this.rbSouth.Size = new System.Drawing.Size(53, 17);
            this.rbSouth.TabIndex = 3;
            this.rbSouth.TabStop = true;
            this.rbSouth.Text = "South";
            this.rbSouth.UseVisualStyleBackColor = true;
            this.rbSouth.CheckedChanged += new System.EventHandler(this.rbSouth_CheckedChanged);
            // 
            // rbEast
            // 
            this.rbEast.AutoSize = true;
            this.rbEast.Location = new System.Drawing.Point(0, 16);
            this.rbEast.Name = "rbEast";
            this.rbEast.Size = new System.Drawing.Size(46, 17);
            this.rbEast.TabIndex = 2;
            this.rbEast.TabStop = true;
            this.rbEast.Text = "East";
            this.rbEast.UseVisualStyleBackColor = true;
            this.rbEast.CheckedChanged += new System.EventHandler(this.rbEast_CheckedChanged);
            // 
            // rbNorth
            // 
            this.rbNorth.AutoSize = true;
            this.rbNorth.Checked = true;
            this.rbNorth.Location = new System.Drawing.Point(0, 0);
            this.rbNorth.Name = "rbNorth";
            this.rbNorth.Size = new System.Drawing.Size(51, 17);
            this.rbNorth.TabIndex = 0;
            this.rbNorth.TabStop = true;
            this.rbNorth.Text = "North";
            this.rbNorth.UseVisualStyleBackColor = true;
            this.rbNorth.CheckedChanged += new System.EventHandler(this.rbNorth_CheckedChanged);
            // 
            // cbTrigger4
            // 
            this.cbTrigger4.AutoSize = true;
            this.cbTrigger4.Location = new System.Drawing.Point(576, 344);
            this.cbTrigger4.Name = "cbTrigger4";
            this.cbTrigger4.Size = new System.Drawing.Size(68, 17);
            this.cbTrigger4.TabIndex = 23;
            this.cbTrigger4.Text = "Trigger 4";
            this.cbTrigger4.UseVisualStyleBackColor = true;
            this.cbTrigger4.CheckedChanged += new System.EventHandler(this.cbTrigger4_CheckedChanged);
            // 
            // cbTrigger3
            // 
            this.cbTrigger3.AutoSize = true;
            this.cbTrigger3.Location = new System.Drawing.Point(576, 328);
            this.cbTrigger3.Name = "cbTrigger3";
            this.cbTrigger3.Size = new System.Drawing.Size(68, 17);
            this.cbTrigger3.TabIndex = 22;
            this.cbTrigger3.Text = "Trigger 3";
            this.cbTrigger3.UseVisualStyleBackColor = true;
            this.cbTrigger3.CheckedChanged += new System.EventHandler(this.cbTrigger3_CheckedChanged);
            // 
            // cbTrigger2
            // 
            this.cbTrigger2.AutoSize = true;
            this.cbTrigger2.Location = new System.Drawing.Point(576, 312);
            this.cbTrigger2.Name = "cbTrigger2";
            this.cbTrigger2.Size = new System.Drawing.Size(68, 17);
            this.cbTrigger2.TabIndex = 21;
            this.cbTrigger2.Text = "Trigger 2";
            this.cbTrigger2.UseVisualStyleBackColor = true;
            this.cbTrigger2.CheckedChanged += new System.EventHandler(this.cbTrigger2_CheckedChanged);
            // 
            // cbTrigger1
            // 
            this.cbTrigger1.AutoSize = true;
            this.cbTrigger1.Location = new System.Drawing.Point(576, 296);
            this.cbTrigger1.Name = "cbTrigger1";
            this.cbTrigger1.Size = new System.Drawing.Size(68, 17);
            this.cbTrigger1.TabIndex = 20;
            this.cbTrigger1.Text = "Trigger 1";
            this.cbTrigger1.UseVisualStyleBackColor = true;
            this.cbTrigger1.CheckedChanged += new System.EventHandler(this.cbTrigger1_CheckedChanged);
            // 
            // cbMonsters
            // 
            this.cbMonsters.AutoSize = true;
            this.cbMonsters.Location = new System.Drawing.Point(576, 200);
            this.cbMonsters.Name = "cbMonsters";
            this.cbMonsters.Size = new System.Drawing.Size(69, 17);
            this.cbMonsters.TabIndex = 19;
            this.cbMonsters.Text = "Monsters";
            this.cbMonsters.UseVisualStyleBackColor = true;
            this.cbMonsters.CheckedChanged += new System.EventHandler(this.cbMonsters_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.picRoom);
            this.panel2.Location = new System.Drawing.Point(664, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 376);
            this.panel2.TabIndex = 18;
            // 
            // picRoom
            // 
            this.picRoom.BackColor = System.Drawing.Color.White;
            this.picRoom.Location = new System.Drawing.Point(4, 4);
            this.picRoom.Name = "picRoom";
            this.picRoom.Size = new System.Drawing.Size(359, 364);
            this.picRoom.TabIndex = 0;
            this.picRoom.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(528, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Rooms";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstRooms
            // 
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.Location = new System.Drawing.Point(576, 32);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(80, 160);
            this.lstRooms.TabIndex = 16;
            this.lstRooms.SelectedIndexChanged += new System.EventHandler(this.lstRooms_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(64, 168);
            this.trackBar1.Maximum = 4;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(176, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 376);
            this.panel1.TabIndex = 14;
            // 
            // lstLevels
            // 
            this.lstLevels.FormattingEnabled = true;
            this.lstLevels.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3",
            "Level 4",
            "Level 5",
            "Level 6",
            "Level 7",
            "Level 8"});
            this.lstLevels.Location = new System.Drawing.Point(64, 32);
            this.lstLevels.Name = "lstLevels";
            this.lstLevels.Size = new System.Drawing.Size(104, 108);
            this.lstLevels.Sorted = true;
            this.lstLevels.TabIndex = 13;
            this.lstLevels.SelectedIndexChanged += new System.EventHandler(this.lstLevels_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Level";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dungeon";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Scale";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(64, 144);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Draw Style";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmbDungeons
            // 
            this.cmbDungeons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDungeons.FormattingEnabled = true;
            this.cmbDungeons.Location = new System.Drawing.Point(64, 8);
            this.cmbDungeons.Name = "cmbDungeons";
            this.cmbDungeons.Size = new System.Drawing.Size(104, 21);
            this.cmbDungeons.TabIndex = 3;
            this.cmbDungeons.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1051, 419);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Imagemap";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 413);
            this.textBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stuffToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1059, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stuffToolStripMenuItem
            // 
            this.stuffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.exportAllToolStripMenuItem,
            this.showWorldToolStripMenuItem});
            this.stuffToolStripMenuItem.Name = "stuffToolStripMenuItem";
            this.stuffToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.stuffToolStripMenuItem.Text = "Stuff";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exportAllToolStripMenuItem.Text = "Export All";
            this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.exportAllToolStripMenuItem_Click);
            // 
            // showWorldToolStripMenuItem
            // 
            this.showWorldToolStripMenuItem.Name = "showWorldToolStripMenuItem";
            this.showWorldToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.showWorldToolStripMenuItem.Text = "Show World";
            this.showWorldToolStripMenuItem.Click += new System.EventHandler(this.showWorldToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 475);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "U4 Mapper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlPartyPositions.ResumeLayout(false);
            this.pnlPartyPositions.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbDungeons;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stuffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWorldToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstLevels;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstRooms;
        private System.Windows.Forms.Panel pnlPartyPositions;
        private System.Windows.Forms.RadioButton rbWest;
        private System.Windows.Forms.RadioButton rbSouth;
        private System.Windows.Forms.RadioButton rbEast;
        private System.Windows.Forms.RadioButton rbNorth;
        private System.Windows.Forms.CheckBox cbTrigger4;
        private System.Windows.Forms.CheckBox cbTrigger3;
        private System.Windows.Forms.CheckBox cbTrigger2;
        private System.Windows.Forms.CheckBox cbTrigger1;
        private System.Windows.Forms.CheckBox cbMonsters;
        private System.Windows.Forms.CheckBox cbParty;
    }
}

