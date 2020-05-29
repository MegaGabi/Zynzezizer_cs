namespace Zynzezizer_cs
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pianoRollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synthesizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequencerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1227, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pianoRollToolStripMenuItem,
            this.synthesizerToolStripMenuItem,
            this.sequencerToolStripMenuItem});
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.controlsToolStripMenuItem.Text = "Controls";
            // 
            // pianoRollToolStripMenuItem
            // 
            this.pianoRollToolStripMenuItem.Name = "pianoRollToolStripMenuItem";
            this.pianoRollToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pianoRollToolStripMenuItem.Text = "Piano roll";
            this.pianoRollToolStripMenuItem.Click += new System.EventHandler(this.pianoRollToolStripMenuItem_Click);
            // 
            // synthesizerToolStripMenuItem
            // 
            this.synthesizerToolStripMenuItem.Name = "synthesizerToolStripMenuItem";
            this.synthesizerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.synthesizerToolStripMenuItem.Text = "Synthesizer";
            this.synthesizerToolStripMenuItem.Click += new System.EventHandler(this.synthesizerToolStripMenuItem_Click);
            // 
            // sequencerToolStripMenuItem
            // 
            this.sequencerToolStripMenuItem.Name = "sequencerToolStripMenuItem";
            this.sequencerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sequencerToolStripMenuItem.Text = "Sequencer";
            this.sequencerToolStripMenuItem.Click += new System.EventHandler(this.sequencerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 698);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Zynzezizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pianoRollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem synthesizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequencerToolStripMenuItem;
    }
}

