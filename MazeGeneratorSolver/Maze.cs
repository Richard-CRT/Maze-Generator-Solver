using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorSolver
{
    public enum Direction { Entry, North, East, South, West };
    public enum SolveStatus { NotVisited, Visited, Incorrect, Correct, StartEnd };
    public enum MazeGenerationAlgorithm { RecursiveBacktracking, Kruskals };
    public enum MazeSolverAlgorithm { DepthFirst, BreadthFirst };

    public partial class Maze : UserControl
    {
        private const int gridCellSize = 20;
        public const int GridWidth = 90; // 90
        public const int GridHeight = 40; // 40

        private int StartX;
        private int StartY;
        private int EndX;
        private int EndY;

        private bool SolveRun = false;

        private Random rng = new Random();

        List<List<GridCell>> grid = new List<List<GridCell>>();

        public int RedVisited = 0;
        public int WhiteVisited = 0;
        public int Solutions = 0;

        public Maze()
        {
            InitializeComponent();
        }

        private void Maze_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();

            this.Size = new Size(gridCellSize * GridWidth, gridCellSize * GridHeight);

            for (int y = 0; y < GridHeight; y++)
            {
                List<GridCell> row = new List<GridCell>();
                for (int x = 0; x < GridWidth; x++)
                {
                    GridCell GridCell = new GridCell();
                    GridCell.Size = new Size(gridCellSize, gridCellSize);
                    GridCell.Location = new Point(x * gridCellSize, y * gridCellSize);
                    row.Add(GridCell);
                    this.Controls.Add(GridCell);
                }
                grid.Add(row);
            }
        }

        public void GenerateMaze(MazeGenerationAlgorithm algorithm)
        {
            StartX = rng.Next(0, GridWidth);
            StartY = rng.Next(0, GridHeight);

            EndX = rng.Next(0, GridWidth);
            EndY = rng.Next(0, GridHeight);

            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    grid[y][x].Reset();
                }
            }

            switch (algorithm)
            {
                case MazeGenerationAlgorithm.RecursiveBacktracking:
                    carve_passages_from(StartX, StartY);
                    break;
                case MazeGenerationAlgorithm.Kruskals:
                    KruskalGenerate();
                    break;
            }

            grid[StartY][StartX].SolveStatus = SolveStatus.StartEnd;
            grid[EndY][EndX].SolveStatus = SolveStatus.StartEnd;

            SolveRun = false;

            //grid[0][0].WestWall = false;
            //grid[GridHeight - 1][GridWidth - 1].EastWall = false;
        }

        public void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        public void SolveMaze(MazeSolverAlgorithm algorithm)
        {
            if (grid.Count > 0 && grid[0].Count > 0)
            {
                if (SolveRun)
                {
                    for (int y = 0; y < GridHeight; y++)
                    {
                        for (int x = 0; x < GridWidth; x++)
                        {
                            if ((x != StartX || y != StartY) && (x != EndX || y != EndY))
                            {
                                grid[y][x].EnableDelay = false;
                                grid[y][x].SolveStatus = SolveStatus.NotVisited;
                                grid[y][x].EnableDelay = true;
                            }
                        }
                    }
                }

                switch (algorithm)
                {
                    case MazeSolverAlgorithm.DepthFirst:
                        DepthFirstSolve(Direction.Entry, StartX, EndX);
                        break;
                    case MazeSolverAlgorithm.BreadthFirst:
                        BreadthFirstSolve(Direction.Entry);
                        break;
                }
            }

            SolveRun = true;
            Solutions++;
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    if (grid[y][x].SolveStatus == SolveStatus.Incorrect)
                    {
                        RedVisited++;
                    }
                    else if (grid[y][x].SolveStatus == SolveStatus.NotVisited)
                    {
                        WhiteVisited++;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
