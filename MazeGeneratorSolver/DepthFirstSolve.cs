using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorSolver
{
    public partial class Maze
    {
        private bool NorthCheck(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].NorthWall && entryWall != Direction.North)
            {
                int nx = x;
                int ny = y - 1;

                if (DepthFirstSolve(Direction.South, nx, ny))
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

                if (DepthFirstSolve(Direction.West, nx, ny))
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

                if (DepthFirstSolve(Direction.North, nx, ny))
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

                if (DepthFirstSolve(Direction.East, nx, ny))
                {
                    grid[y][x].SolveStatus = SolveStatus.Correct;
                    return true;
                }
            }
            return false;
        }

        private bool DepthFirstSolve(Direction entryWall, int x, int y)
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
    }
}
