using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorSolver
{
    public partial class Maze
    {
        private void KruskalGenerate()
        {
            Tree[,] trees = new Tree[GridHeight, GridWidth];
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    trees[y, x] = new Tree();
                }
            }

            List<KruskalStep> steps = new List<KruskalStep>();
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth - 1; x++)
                {
                    KruskalStep newStep = new KruskalStep();
                    newStep.x = x;
                    newStep.y = y;
                    newStep.edge = Direction.East;
                    steps.Add(newStep);
                }
            }

            for (int y = 0; y < GridHeight - 1; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    KruskalStep newStep = new KruskalStep();
                    newStep.x = x;
                    newStep.y = y;
                    newStep.edge = Direction.South;
                    steps.Add(newStep);
                }
            }

            KruskalStep[] stepsArray = steps.ToArray();
            Shuffle<KruskalStep>(stepsArray);

            for (int i = 0; i < stepsArray.Length; i++)
            {
                KruskalStep edge = stepsArray[i];
                int nx = edge.x;
                int ny = edge.y;

                switch (edge.edge)
                {
                    case Direction.East:
                        nx = edge.x + 1;
                        ny = edge.y;

                        break;
                    case Direction.South:
                        nx = edge.x;
                        ny = edge.y + 1;
                        break;
                }

                if (!trees[edge.y, edge.x].Connected(trees[ny, nx]))
                {
                    trees[edge.y, edge.x].Connect(trees[ny, nx]);

                    switch (edge.edge)
                    {
                        case Direction.East:
                            grid[edge.y][edge.x].EastWall = false;
                            grid[ny][nx].WestWall = false;
                            break;
                        case Direction.South:
                            grid[edge.y][edge.x].SouthWall = false;
                            grid[ny][nx].NorthWall = false;
                            break;
                    }
                }
            }
        }
    }

    public class Tree
    {
        public Tree parent = null;

        public Tree Root
        {
            get
            {
                if (parent == null)
                {
                    return this;
                }
                else
                {
                    return parent.Root;
                }
            }
        }

        public bool Connected(Tree otherTree)
        {
            return (this.Root == otherTree.Root);
        }

        public void Connect(Tree otherTree)
        {
            otherTree.Root.parent = this;
        }
    }

    public class KruskalStep
    {
        public int x;
        public int y;
        public Direction edge;
    }
}
