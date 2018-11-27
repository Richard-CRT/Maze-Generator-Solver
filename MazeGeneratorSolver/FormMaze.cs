using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorSolver
{
    public partial class FormMaze : Form
    {
        public FormMaze()
        {
            InitializeComponent();
        }

        async Task waitForSolution()
        {
            await Task.Delay(1000);
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            ButtonGenerate.Enabled = false;
            ButtonSolve.Enabled = false;
            TrackBarDelay.Enabled = false;
            /*
            while (true)
            {
                Maze.GenerateMaze();
                Maze.SolveMaze();
                await waitForSolution();
            }
            */
            Maze.GenerateMaze();
            ButtonGenerate.Enabled = true;
            ButtonSolve.Enabled = true;
            TrackBarDelay.Enabled = true;
        }

        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            ButtonGenerate.Enabled = false;
            ButtonSolve.Enabled = false;
            TrackBarDelay.Enabled = false;
            Maze.SolveMaze();
            ButtonGenerate.Enabled = true;
            ButtonSolve.Enabled = true;
            TrackBarDelay.Enabled = true;
        }
    }
}
