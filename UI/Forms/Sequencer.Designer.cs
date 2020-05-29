namespace Zynzezizer_cs
{
    partial class Sequencer
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
            this.tb_BPM = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_BPM = new System.Windows.Forms.Label();
            this.lb_Notes = new System.Windows.Forms.ListBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nud_Length = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_StartBeat = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Octave = new System.Windows.Forms.Label();
            this.tb_Octave = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Note = new System.Windows.Forms.ComboBox();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_CurrentBeat = new System.Windows.Forms.Label();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_BPM)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_StartBeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Octave)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_BPM
            // 
            this.tb_BPM.AutoSize = false;
            this.tb_BPM.Location = new System.Drawing.Point(48, 12);
            this.tb_BPM.Maximum = 240;
            this.tb_BPM.Minimum = 60;
            this.tb_BPM.Name = "tb_BPM";
            this.tb_BPM.Size = new System.Drawing.Size(414, 28);
            this.tb_BPM.TabIndex = 1;
            this.tb_BPM.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_BPM.Value = 120;
            this.tb_BPM.ValueChanged += new System.EventHandler(this.tb_BPM_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "BPM";
            // 
            // lbl_BPM
            // 
            this.lbl_BPM.AutoSize = true;
            this.lbl_BPM.Location = new System.Drawing.Point(468, 12);
            this.lbl_BPM.Name = "lbl_BPM";
            this.lbl_BPM.Size = new System.Drawing.Size(25, 13);
            this.lbl_BPM.TabIndex = 3;
            this.lbl_BPM.Text = "120";
            // 
            // lb_Notes
            // 
            this.lb_Notes.FormattingEnabled = true;
            this.lb_Notes.Location = new System.Drawing.Point(419, 46);
            this.lb_Notes.Name = "lb_Notes";
            this.lb_Notes.Size = new System.Drawing.Size(225, 147);
            this.lb_Notes.TabIndex = 4;
            this.lb_Notes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lb_Notes_SelectedIndexChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(486, 199);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 5;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(567, 199);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(75, 23);
            this.btn_Remove.TabIndex = 6;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Note";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.nud_Length);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.nud_StartBeat);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbl_Octave);
            this.panel1.Controls.Add(this.tb_Octave);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cb_Note);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(15, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 147);
            this.panel1.TabIndex = 8;
            // 
            // nud_Length
            // 
            this.nud_Length.Location = new System.Drawing.Point(120, 108);
            this.nud_Length.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Length.Name = "nud_Length";
            this.nud_Length.Size = new System.Drawing.Size(120, 20);
            this.nud_Length.TabIndex = 14;
            this.nud_Length.ValueChanged += new System.EventHandler(this.nud_Length_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Length in beats";
            // 
            // nud_StartBeat
            // 
            this.nud_StartBeat.Location = new System.Drawing.Point(119, 82);
            this.nud_StartBeat.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_StartBeat.Name = "nud_StartBeat";
            this.nud_StartBeat.Size = new System.Drawing.Size(120, 20);
            this.nud_StartBeat.TabIndex = 12;
            this.nud_StartBeat.ValueChanged += new System.EventHandler(this.nud_StartBeat_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Starts on beat";
            // 
            // lbl_Octave
            // 
            this.lbl_Octave.AutoSize = true;
            this.lbl_Octave.Location = new System.Drawing.Point(246, 36);
            this.lbl_Octave.Name = "lbl_Octave";
            this.lbl_Octave.Size = new System.Drawing.Size(13, 13);
            this.lbl_Octave.TabIndex = 10;
            this.lbl_Octave.Text = "0";
            // 
            // tb_Octave
            // 
            this.tb_Octave.AutoSize = false;
            this.tb_Octave.Location = new System.Drawing.Point(119, 25);
            this.tb_Octave.Maximum = 7;
            this.tb_Octave.Name = "tb_Octave";
            this.tb_Octave.Size = new System.Drawing.Size(121, 24);
            this.tb_Octave.TabIndex = 9;
            this.tb_Octave.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_Octave.ValueChanged += new System.EventHandler(this.tb_Octave_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Octave";
            // 
            // cb_Note
            // 
            this.cb_Note.FormattingEnabled = true;
            this.cb_Note.Items.AddRange(new object[] {
            "A",
            "A#",
            "B",
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#"});
            this.cb_Note.Location = new System.Drawing.Point(119, 55);
            this.cb_Note.Name = "cb_Note";
            this.cb_Note.Size = new System.Drawing.Size(121, 21);
            this.cb_Note.TabIndex = 8;
            this.cb_Note.SelectedIndexChanged += new System.EventHandler(this.cb_Note_SelectedIndexChanged);
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(15, 199);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(75, 23);
            this.btn_Play.TabIndex = 9;
            this.btn_Play.Text = "Play";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(96, 199);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 10;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "currently on beat number:";
            // 
            // lbl_CurrentBeat
            // 
            this.lbl_CurrentBeat.AutoSize = true;
            this.lbl_CurrentBeat.Location = new System.Drawing.Point(341, 209);
            this.lbl_CurrentBeat.Name = "lbl_CurrentBeat";
            this.lbl_CurrentBeat.Size = new System.Drawing.Size(13, 13);
            this.lbl_CurrentBeat.TabIndex = 12;
            this.lbl_CurrentBeat.Text = "0";
            // 
            // btn_Down
            // 
            this.btn_Down.Location = new System.Drawing.Point(455, 199);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(25, 23);
            this.btn_Down.TabIndex = 13;
            this.btn_Down.Text = "v";
            this.btn_Down.UseVisualStyleBackColor = true;
            // 
            // btn_Up
            // 
            this.btn_Up.Location = new System.Drawing.Point(424, 199);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(25, 23);
            this.btn_Up.TabIndex = 14;
            this.btn_Up.Text = "^";
            this.btn_Up.UseVisualStyleBackColor = true;
            // 
            // Sequencer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 241);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.lbl_CurrentBeat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Play);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lb_Notes);
            this.Controls.Add(this.lbl_BPM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_BPM);
            this.Name = "Sequencer";
            this.Text = "Sequencer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sequencer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tb_BPM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_StartBeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Octave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tb_BPM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_BPM;
        private System.Windows.Forms.ListBox lb_Notes;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nud_Length;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_StartBeat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Octave;
        private System.Windows.Forms.TrackBar tb_Octave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Note;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_CurrentBeat;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
    }
}