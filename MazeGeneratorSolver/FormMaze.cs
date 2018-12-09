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
            ButtonGenerate.Enabled = true;
            ButtonSolve.Enabled = true;
            TrackBarDelay.Enabled = true;
            GroupBoxGenerationMethod.Enabled = true;
            await Task.Delay(1000);
            ButtonGenerate.Enabled = false;
            ButtonSolve.Enabled = false;
            TrackBarDelay.Enabled = false;
            GroupBoxGenerationMethod.Enabled = false;
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            ButtonGenerate.Enabled = false;
            ButtonSolve.Enabled = false;
            TrackBarDelay.Enabled = false;
            GroupBoxGenerationMethod.Enabled = false;

            /*
            while (true)
            {
                MazeGenerationAlgorithm generationAlgorithm;
                if (RadioButtonRecursiveBacktracking.Checked)
                {
                    generationAlgorithm = MazeGenerationAlgorithm.RecursiveBacktracking;
                }
                else
                {
                    generationAlgorithm = MazeGenerationAlgorithm.Kruskals;
                }
                Maze.GenerateMaze(generationAlgorithm);

                MazeSolverAlgorithm solverAlgorithm;
                if (RadioButtonDepthFirst.Checked)
                {
                    solverAlgorithm = MazeSolverAlgorithm.DepthFirst;
                }
                else
                {
                    solverAlgorithm = MazeSolverAlgorithm.BreadthFirst;
                }
                Maze.SolveMaze(solverAlgorithm);

                int count = Maze.GridWidth * Maze.GridHeight;

                double averageWhite = (double)Maze.WhiteVisited / Maze.Solutions;
                double averageRed = (double)Maze.RedVisited / Maze.Solutions;

                LabelStats.Text = String.Format("   White: {0}   % White: {1}   Red: {2}   % Red: {3}", Maze.WhiteVisited, (averageWhite / count) * 100, Maze.RedVisited, (averageRed / count) * 100);
                await waitForSolution();
            }
            */

            MazeGenerationAlgorithm algorithm;
            if (RadioButtonRecursiveBacktracking.Checked)
            {
                algorithm = MazeGenerationAlgorithm.RecursiveBacktracking;
            }
            else
            {
                algorithm = MazeGenerationAlgorithm.Kruskals;
            }
            Maze.GenerateMaze(algorithm);

            ButtonGenerate.Enabled = true;
            ButtonSolve.Enabled = true;
            TrackBarDelay.Enabled = true;
            GroupBoxGenerationMethod.Enabled = true;
        }

        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            ButtonGenerate.Enabled = false;
            ButtonSolve.Enabled = false;
            TrackBarDelay.Enabled = false;

            MazeSolverAlgorithm algorithm;
            if (RadioButtonDepthFirst.Checked)
            {
                algorithm = MazeSolverAlgorithm.DepthFirst;
            }
            else
            {
                algorithm = MazeSolverAlgorithm.BreadthFirst;
            }
            Maze.SolveMaze(algorithm);

            ButtonGenerate.Enabled = true;
            ButtonSolve.Enabled = true;
            TrackBarDelay.Enabled = true;
        }
    }
}
