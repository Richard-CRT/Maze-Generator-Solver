using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorSolver
{
    public partial class Maze
    {
        List<BreadthFirstStep> BreadthQueue = new List<BreadthFirstStep>();

        private bool BreadthNorthScan(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].NorthWall && entryWall != Direction.North)
            {
                int nx = x;
                int ny = y - 1;

                BreadthQueue.Add(new BreadthFirstStep(Direction.South, nx, ny));
            }
            return false;
        }

        private bool BreadthEastScan(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].EastWall && entryWall != Direction.East)
            {
                int nx = x + 1;
                int ny = y;

                BreadthQueue.Add(new BreadthFirstStep(Direction.West, nx, ny));
            }
            return false;
        }

        private bool BreadthSouthScan(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].SouthWall && entryWall != Direction.South)
            {
                int nx = x;
                int ny = y + 1;

                BreadthQueue.Add(new BreadthFirstStep(Direction.North, nx, ny));
            }
            return false;
        }

        private bool BreadthWestScan(Direction entryWall, int x, int y)
        {
            if (!grid[y][x].WestWall && entryWall != Direction.West)
            {
                int nx = x - 1;
                int ny = y;

                BreadthQueue.Add(new BreadthFirstStep(Direction.East, nx, ny));
            }
            return false;
        }

        private void BreadthFirstSolve(Direction StartWall)
        {
            BreadthQueue = new List<BreadthFirstStep>();
            BreadthQueue.Add(new BreadthFirstStep(StartWall, StartX, StartY));

            int finishedIteration = -1;

            for (int i = 0; i < BreadthQueue.Count; i++)
            {
                BreadthFirstStep step = BreadthQueue[i];

                if (step.X == EndX && step.Y == EndY)
                {
                    grid[step.Y][step.X].SolveStatus = SolveStatus.Correct;
                    finishedIteration = i;
                    break;
                }

                grid[step.Y][step.X].SolveStatus = SolveStatus.Visited;

                Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
                Shuffle(directions);

                foreach (Direction direction in directions)
                {
                    switch (direction)
                    {
                        case Direction.North:
                            BreadthNorthScan(step.EntryWall, step.X, step.Y);
                            break;
                        case Direction.East:
                            BreadthEastScan(step.EntryWall, step.X, step.Y);
                            break;
                        case Direction.South:
                            BreadthSouthScan(step.EntryWall, step.X, step.Y);
                            break;
                        case Direction.West:
                            BreadthWestScan(step.EntryWall, step.X, step.Y);
                            break;
                    }
                }
            }

            if (finishedIteration != -1) // if it's -1 there was no end...
            {
                BreadthFirstStep iterationStep = BreadthQueue[finishedIteration];

                while (iterationStep.X != StartX || iterationStep.Y != StartY)
                {
                    grid[iterationStep.Y][iterationStep.X].SolveStatus = SolveStatus.Correct;
                    switch (iterationStep.EntryWall)
                    {
                        case Direction.North:
                            iterationStep = breadthFindStepFromCoordinates(iterationStep.X, iterationStep.Y - 1);
                            break;
                        case Direction.East:
                            iterationStep = breadthFindStepFromCoordinates(iterationStep.X + 1, iterationStep.Y);
                            break;
                        case Direction.South:
                            iterationStep = breadthFindStepFromCoordinates(iterationStep.X, iterationStep.Y + 1);
                            break;
                        case Direction.West:
                            iterationStep = breadthFindStepFromCoordinates(iterationStep.X - 1, iterationStep.Y);
                            break;
                    }
                }
            }



            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    if (grid[y][x].SolveStatus == SolveStatus.Visited)
                    {
                        grid[y][x].EnableDelay = false;
                        grid[y][x].SolveStatus = SolveStatus.Incorrect;
                        grid[y][x].EnableDelay = true;
                    }
                }
            }
        }

        private BreadthFirstStep breadthFindStepFromCoordinates(int x, int y)
        {
            foreach (BreadthFirstStep breadFirstStep in BreadthQueue)
            {
                if (breadFirstStep.X == x && breadFirstStep.Y == y)
                {
                    return breadFirstStep;
                }
            }
            return null;
        }
    }

    public class BreadthFirstStep
    {
        public int X;
        public int Y;
        public Direction EntryWall;

        public BreadthFirstStep(Direction entryWall, int x, int y)
        {
            X = x;
            Y = y;
            EntryWall = entryWall;
        }
    }
}
