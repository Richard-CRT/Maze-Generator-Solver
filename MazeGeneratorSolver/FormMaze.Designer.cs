namespace MazeGeneratorSolver
{
    partial class FormMaze
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
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.ButtonSolve = new System.Windows.Forms.Button();
            this.TrackBarDelay = new System.Windows.Forms.TrackBar();
            this.Maze = new MazeGeneratorSolver.Maze();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonGenerate.Location = new System.Drawing.Point(12, 818);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(397, 40);
            this.ButtonGenerate.TabIndex = 1;
            this.ButtonGenerate.Text = "Generate";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // ButtonSolve
            // 
            this.ButtonSolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSolve.Location = new System.Drawing.Point(928, 818);
            this.ButtonSolve.Name = "ButtonSolve";
            this.ButtonSolve.Size = new System.Drawing.Size(397, 40);
            this.ButtonSolve.TabIndex = 2;
            this.ButtonSolve.Text = "Solve";
            this.ButtonSolve.UseVisualStyleBackColor = true;
            this.ButtonSolve.Click += new System.EventHandler(this.ButtonSolve_Click);
            // 
            // TrackBarDelay
            // 
            this.TrackBarDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TrackBarDelay.Location = new System.Drawing.Point(416, 818);
            this.TrackBarDelay.Maximum = 200;
            this.TrackBarDelay.Name = "TrackBarDelay";
            this.TrackBarDelay.Size = new System.Drawing.Size(506, 45);
            this.TrackBarDelay.TabIndex = 3;
            // 
            // Maze
            // 
            this.Maze.BackColor = System.Drawing.Color.White;
            this.Maze.Location = new System.Drawing.Point(12, 12);
            this.Maze.Name = "Maze";
            this.Maze.Size = new System.Drawing.Size(1800, 800);
            this.Maze.TabIndex = 0;
            // 
            // FormMaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1825, 864);
            this.Controls.Add(this.TrackBarDelay);
            this.Controls.Add(this.ButtonSolve);
            this.Controls.Add(this.ButtonGenerate);
            this.Controls.Add(this.Maze);
            this.Name = "FormMaze";
            this.Text = "Maze";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Maze Maze;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.Button ButtonSolve;
        public System.Windows.Forms.TrackBar TrackBarDelay;
    }
}

