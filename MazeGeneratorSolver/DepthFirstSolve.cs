using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorSolver
{
    public partial class Maze
    {
        private bool DepthFirstSolve(Direction entryWall, int x, int y)
        {
            return DepthFirstSolveRecurse(entryWall, x, y);
        }

        private bool DepthNorthCheck(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].NorthWall && entryWall != Direction.North)
            {
                int nx = x;
                int ny = y - 1;

                if (DepthFirstSolveRecurse(Direction.South, nx, ny))
                {
                    grid[y][x].SolveStatus = SolveStatus.Correct;
                    return true;
                }
            }
            return false;
        }

        private bool DepthEastCheck(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].EastWall && entryWall != Direction.East)
            {
                int nx = x + 1;
                int ny = y;

                if (DepthFirstSolveRecurse(Direction.West, nx, ny))
                {
                    grid[y][x].SolveStatus = SolveStatus.Correct;
                    return true;
                }
            }
            return false;
        }

        private bool DepthSouthCheck(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].SouthWall && entryWall != Direction.South)
            {
                int nx = x;
                int ny = y + 1;

                if (DepthFirstSolveRecurse(Direction.North, nx, ny))
                {
                    grid[y][x].SolveStatus = SolveStatus.Correct;
                    return true;
                }
            }
            return false;
        }

        private bool DepthWestCheck(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].WestWall && entryWall != Direction.West)
            {
                int nx = x - 1;
                int ny = y;

                if (DepthFirstSolveRecurse(Direction.East, nx, ny))
                {
                    grid[y][x].SolveStatus = SolveStatus.Correct;
                    return true;
                }
            }
            return false;
        }

        private bool DepthFirstSolveRecurse(Direction entryWall, int x, int y)
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
                        if (DepthNorthCheck(entryWall, x, y))
                        {
                            return true;
                        }
                        break;
                    case Direction.East:
                        if (DepthEastCheck(entryWall, x, y))
                        {
                            return true;
                        }
                        break;
                    case Direction.South:
                        if (DepthSouthCheck(entryWall, x, y))
                        {
                            return true;
                        }
                        break;
                    case Direction.West:
                        if (DepthWestCheck(entryWall, x, y))
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
    }
}
