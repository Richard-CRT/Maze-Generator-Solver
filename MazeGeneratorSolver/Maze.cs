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

    public partial class Maze : UserControl
    {
        private const int gridCellSize = 20;
        private const int GridWidth = 90;
        private const int GridHeight = 40;

        private int StartX;
        private int StartY;
        private int EndX;
        private int EndY;

        private bool SolveRun = false;

        private Random rng = new Random();

        List<List<GridCell>> grid = new List<List<GridCell>>();

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

        public void GenerateMaze()
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

            carve_passages_from(StartX, StartY);

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

        private void carve_passages_from(int x, int y)
        {
            Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
            Shuffle(directions);

            foreach (Direction direction in directions)
            {
                int nx, ny;
                switch (direction)
                {
                    case Direction.North:
                        nx = x;
                        ny = y - 1;

                        if (ny >= 0 && !grid[ny][nx].Visited)
                        {
                            grid[y][x].NorthWall = false;
                            grid[ny][nx].SouthWall = false;
                            carve_passages_from(nx, ny);
                        }

                        break;
                    case Direction.East:
                        nx = x + 1;
                        ny = y;

                        if (nx < GridWidth && !grid[ny][nx].Visited)
                        {
                            grid[y][x].EastWall = false;
                            grid[ny][nx].WestWall = false;
                            carve_passages_from(nx, ny);
                        }

                        break;
                    case Direction.South:
                        nx = x;
                        ny = y + 1;

                        if (ny < GridHeight && !grid[ny][nx].Visited)
                        {
                            grid[y][x].SouthWall = false;
                            grid[ny][nx].NorthWall = false;
                            carve_passages_from(nx, ny);
                        }

                        break;
                    case Direction.West:
                        nx = x - 1;
                        ny = y;

                        if (nx >= 0 && !grid[ny][nx].Visited)
                        {
                            grid[y][x].WestWall = false;
                            grid[ny][nx].EastWall = false;
                            carve_passages_from(nx, ny);
                        }

                        break;
                    default:
                        // should never be here
                        nx = x;
                        ny = y;
                        break;
                }
            }
        }

        public void SolveMaze()
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
                                grid[y][x].SolveStatus = SolveStatus.NotVisited;
                            }
                        }
                    }
                }

                solve(Direction.Entry, StartX, StartY);
            }

            SolveRun = true;
        }

        private bool NorthCheck(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].NorthWall && entryWall != Direction.North)
            {
                int nx = x;
                int ny = y - 1;

                if (solve(Direction.South, nx, ny))
                {
                    grid[y][x].SolveStatus = SolveStatus.Correct;
                    return true;
                }
            }
            return false;
        }

        private bool EastCheck(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].EastWall && entryWall != Direction.East)
            {
                int nx = x + 1;
                int ny = y;

                if (solve(Direction.West, nx, ny))
                {
                    grid[y][x].SolveStatus = SolveStatus.Correct;
                    return true;
                }
            }
            return false;
        }

        private bool SouthCheck(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].SouthWall && entryWall != Direction.South)
            {
                int nx = x;
                int ny = y + 1;

                if (solve(Direction.North, nx, ny))
                {
                    grid[y][x].SolveStatus = SolveStatus.Correct;
                    return true;
                }
            }
            return false;
        }

        private bool WestCheck(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].WestWall && entryWall != Direction.West)
            {
                int nx = x - 1;
                int ny = y;

                if (solve(Direction.East, nx, ny))
                {
                    grid[y][x].SolveStatus = SolveStatus.Correct;
                    return true;
                }
            }
            return false;
        }

        private bool solve(Direction entryWall, int x, int y)
        {
            grid[y][x].SolveStatus = SolveStatus.Visited;
            if (x == EndX && y == EndY)
            {
                grid[y][x].SolveStatus = SolveStatus.Correct;
                return true;
            }

            Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
            Shuffle(directions);


            foreach (Direction direction in directions)
            {
                switch (direction)
                {
                    case Direction.North:
                        if (NorthCheck(entryWall, x, y))
                        {
                            return true;
                        }
                        break;
                    case Direction.East:
                        if (EastCheck(entryWall, x, y))
                        {
                            return true;
                        }
                        break;
                    case Direction.South:
                        if (SouthCheck(entryWall, x, y))
                        {
                            return true;
                        }
                        break;
                    case Direction.West:
                        if (WestCheck(entryWall, x, y))
                        {
                            return true;
                        }
                        break;
                }
            }

            // deadend
            grid[y][x].SolveStatus = SolveStatus.Incorrect;
            return false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
