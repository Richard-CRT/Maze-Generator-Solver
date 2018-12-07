using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorSolver
{
    public partial class Maze
    {
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
    }
}