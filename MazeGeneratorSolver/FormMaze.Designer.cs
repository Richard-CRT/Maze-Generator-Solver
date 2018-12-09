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
            this.LabelStats = new System.Windows.Forms.Label();
            this.Maze = new MazeGeneratorSolver.Maze();
            this.GroupBoxGenerationMethod = new System.Windows.Forms.GroupBox();
            this.RadioButtonKruskals = new System.Windows.Forms.RadioButton();
            this.RadioButtonRecursiveBacktracking = new System.Windows.Forms.RadioButton();
            this.GroupBoxSolveMethod = new System.Windows.Forms.GroupBox();
            this.RadioButtonBreadthFirst = new System.Windows.Forms.RadioButton();
            this.RadioButtonDepthFirst = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarDelay)).BeginInit();
            this.GroupBoxGenerationMethod.SuspendLayout();
            this.GroupBoxSolveMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonGenerate.Location = new System.Drawing.Point(12, 818);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(243, 40);
            this.ButtonGenerate.TabIndex = 1;
            this.ButtonGenerate.Text = "Generate";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // ButtonSolve
            // 
            this.ButtonSolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSolve.Location = new System.Drawing.Point(876, 818);
            this.ButtonSolve.Name = "ButtonSolve";
            this.ButtonSolve.Size = new System.Drawing.Size(248, 40);
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
            this.TrackBarDelay.Size = new System.Drawing.Size(354, 45);
            this.TrackBarDelay.TabIndex = 3;
            this.TrackBarDelay.TickFrequency = 4;
            // 
            // LabelStats
            // 
            this.LabelStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelStats.Location = new System.Drawing.Point(1143, 818);
            this.LabelStats.Name = "LabelStats";
            this.LabelStats.Size = new System.Drawing.Size(670, 37);
            this.LabelStats.TabIndex = 4;
            this.LabelStats.Text = "Values";
            this.LabelStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Maze
            // 
            this.Maze.BackColor = System.Drawing.Color.White;
            this.Maze.Location = new System.Drawing.Point(12, 12);
            this.Maze.Name = "Maze";
            this.Maze.Size = new System.Drawing.Size(1000, 600);
            this.Maze.TabIndex = 0;
            // 
            // GroupBoxGenerationMethod
            // 
            this.GroupBoxGenerationMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBoxGenerationMethod.Controls.Add(this.RadioButtonKruskals);
            this.GroupBoxGenerationMethod.Controls.Add(this.RadioButtonRecursiveBacktracking);
            this.GroupBoxGenerationMethod.Location = new System.Drawing.Point(263, 813);
            this.GroupBoxGenerationMethod.Name = "GroupBoxGenerationMethod";
            this.GroupBoxGenerationMethod.Size = new System.Drawing.Size(147, 45);
            this.GroupBoxGenerationMethod.TabIndex = 5;
            this.GroupBoxGenerationMethod.TabStop = false;
            // 
            // RadioButtonKruskals
            // 
            this.RadioButtonKruskals.AutoSize = true;
            this.RadioButtonKruskals.Location = new System.Drawing.Point(6, 25);
            this.RadioButtonKruskals.Name = "RadioButtonKruskals";
            this.RadioButtonKruskals.Size = new System.Drawing.Size(67, 17);
            this.RadioButtonKruskals.TabIndex = 6;
            this.RadioButtonKruskals.Text = "Kruskal\'s";
            this.RadioButtonKruskals.UseVisualStyleBackColor = true;
            // 
            // RadioButtonRecursiveBacktracking
            // 
            this.RadioButtonRecursiveBacktracking.AutoSize = true;
            this.RadioButtonRecursiveBacktracking.Checked = true;
            this.RadioButtonRecursiveBacktracking.Location = new System.Drawing.Point(6, 7);
            this.RadioButtonRecursiveBacktracking.Name = "RadioButtonRecursiveBacktracking";
            this.RadioButtonRecursiveBacktracking.Size = new System.Drawing.Size(139, 17);
            this.RadioButtonRecursiveBacktracking.TabIndex = 0;
            this.RadioButtonRecursiveBacktracking.TabStop = true;
            this.RadioButtonRecursiveBacktracking.Text = "Recursive Backtracking";
            this.RadioButtonRecursiveBacktracking.UseVisualStyleBackColor = true;
            // 
            // GroupBoxSolveMethod
            // 
            this.GroupBoxSolveMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBoxSolveMethod.Controls.Add(this.RadioButtonBreadthFirst);
            this.GroupBoxSolveMethod.Controls.Add(this.RadioButtonDepthFirst);
            this.GroupBoxSolveMethod.Location = new System.Drawing.Point(776, 813);
            this.GroupBoxSolveMethod.Name = "GroupBoxSolveMethod";
            this.GroupBoxSolveMethod.Size = new System.Drawing.Size(94, 45);
            this.GroupBoxSolveMethod.TabIndex = 6;
            this.GroupBoxSolveMethod.TabStop = false;
            // 
            // RadioButtonBreadthFirst
            // 
            this.RadioButtonBreadthFirst.AutoSize = true;
            this.RadioButtonBreadthFirst.Location = new System.Drawing.Point(6, 25);
            this.RadioButtonBreadthFirst.Name = "RadioButtonBreadthFirst";
            this.RadioButtonBreadthFirst.Size = new System.Drawing.Size(84, 17);
            this.RadioButtonBreadthFirst.TabIndex = 6;
            this.RadioButtonBreadthFirst.Text = "Breadth First";
            this.RadioButtonBreadthFirst.UseVisualStyleBackColor = true;
            // 
            // RadioButtonDepthFirst
            // 
            this.RadioButtonDepthFirst.AutoSize = true;
            this.RadioButtonDepthFirst.Checked = true;
            this.RadioButtonDepthFirst.Location = new System.Drawing.Point(6, 7);
            this.RadioButtonDepthFirst.Name = "RadioButtonDepthFirst";
            this.RadioButtonDepthFirst.Size = new System.Drawing.Size(76, 17);
            this.RadioButtonDepthFirst.TabIndex = 0;
            this.RadioButtonDepthFirst.TabStop = true;
            this.RadioButtonDepthFirst.Text = "Depth First";
            this.RadioButtonDepthFirst.UseVisualStyleBackColor = true;
            // 
            // FormMaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1825, 864);
            this.Controls.Add(this.GroupBoxSolveMethod);
            this.Controls.Add(this.GroupBoxGenerationMethod);
            this.Controls.Add(this.LabelStats);
            this.Controls.Add(this.TrackBarDelay);
            this.Controls.Add(this.ButtonSolve);
            this.Controls.Add(this.ButtonGenerate);
            this.Controls.Add(this.Maze);
            this.Name = "FormMaze";
            this.Text = "Maze";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarDelay)).EndInit();
            this.GroupBoxGenerationMethod.ResumeLayout(false);
            this.GroupBoxGenerationMethod.PerformLayout();
            this.GroupBoxSolveMethod.ResumeLayout(false);
            this.GroupBoxSolveMethod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Maze Maze;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.Button ButtonSolve;
        public System.Windows.Forms.TrackBar TrackBarDelay;
        private System.Windows.Forms.Label LabelStats;
        private System.Windows.Forms.GroupBox GroupBoxGenerationMethod;
        private System.Windows.Forms.RadioButton RadioButtonKruskals;
        private System.Windows.Forms.RadioButton RadioButtonRecursiveBacktracking;
        private System.Windows.Forms.GroupBox GroupBoxSolveMethod;
        private System.Windows.Forms.RadioButton RadioButtonBreadthFirst;
        private System.Windows.Forms.RadioButton RadioButtonDepthFirst;
    }
}

