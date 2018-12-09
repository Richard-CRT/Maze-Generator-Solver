using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MazeGeneratorSolver
{
    public partial class GridCell : UserControl
    {
        private bool northWall = true;
        private bool enableRedraw = true;
        public bool EnableDelay = true;
        public bool NorthWall
        {
            get
            {
                return northWall;
            }
            set
            {
                northWall = value;
                Visited = true;
                Redraw();
            }
        }

        private bool eastWall = true;
        public bool EastWall
        {
            get
            {
                return eastWall;
            }
            set
            {
                eastWall = value;
                Visited = true;
                Redraw();
            }
        }

        private bool southWall = true;
        public bool SouthWall
        {
            get
            {
                return southWall;
            }
            set
            {
                southWall = value;
                Visited = true;
                Redraw();
            }
        }

        private bool westWall = true;
        public bool WestWall
        {
            get
            {
                return westWall;
            }
            set
            {
                westWall = value;
                Visited = true;
                Redraw();
            }
        }

        private bool visited = false;

        public bool Visited
        {
            get
            {
                return visited;
            }
            private set
            {
                visited = value;
            }
        }

        private SolveStatus solveStatus = SolveStatus.NotVisited;
        public SolveStatus SolveStatus
        {
            get
            {
                return solveStatus;
            }
            set
            {
                if (solveStatus != SolveStatus.StartEnd || value == SolveStatus.NotVisited)
                {
                    solveStatus = value;
                    if (EnableDelay)
                    {
                        RedrawDelay();
                    }
                    else
                    {
                        Redraw();
                    }
                }
            }
        }

        public GridCell()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public void Redraw()
        {
            if (enableRedraw)
            {
                this.Refresh();
            }
        }

        public void RedrawDelay()
        {
            if (enableRedraw)
            {
                this.Refresh();
                int delay = (this.Parent.Parent as FormMaze).TrackBarDelay.Value;
                if (delay > 0)
                {
                    Thread.Sleep(delay);
                }
            }
        }

        public void Reset()
        {
            enableRedraw = false;

            this.SolveStatus = SolveStatus.NotVisited;

            this.NorthWall = true;
            this.EastWall = true;
            this.SouthWall = true;
            this.WestWall = true;

            enableRedraw = true;

            this.Visited = false;

            // This is only needed if the maze generator doesn't visit every cell
            //this.Redraw();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen gridPen = new Pen(Color.Black, 1))
            using (SolidBrush incorrectSolveCell = new SolidBrush(Color.Red))
            using (SolidBrush correctSolveCell = new SolidBrush(Color.SkyBlue))
            using (SolidBrush visitedSolveCell = new SolidBrush(Color.Yellow))
            using (SolidBrush startEndCell = new SolidBrush(Color.DeepSkyBlue))
            {
                Point topLeft = new Point(0, 0);
                Point topRight = new Point(this.Size.Width - 1, 0);
                Point bottomLeft = new Point(0, this.Size.Height - 1);
                Point bottomRight = new Point(this.Size.Width - 1, this.Size.Height - 1);

                Rectangle cellRect = new Rectangle(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X + 1, bottomRight.Y - topLeft.Y + 1);

                if (this.SolveStatus == SolveStatus.StartEnd)
                {
                    e.Graphics.FillRectangle(startEndCell, cellRect);
                }
                else if (this.SolveStatus == SolveStatus.Correct)
                {
                    e.Graphics.FillRectangle(correctSolveCell, cellRect);
                }
                else if (this.SolveStatus == SolveStatus.Incorrect)
                {
                    e.Graphics.FillRectangle(incorrectSolveCell, cellRect);
                }
                else if (this.SolveStatus == SolveStatus.Visited)
                {
                    e.Graphics.FillRectangle(visitedSolveCell, cellRect);
                }

                if (this.NorthWall)
                {
                    e.Graphics.DrawLine(gridPen, topLeft, topRight);
                }
                if (this.EastWall)
                {
                    e.Graphics.DrawLine(gridPen, topRight, bottomRight);
                }
                if (this.SouthWall)
                {
                    e.Graphics.DrawLine(gridPen, bottomRight, bottomLeft);
                }
                if (this.WestWall)
                {
                    e.Graphics.DrawLine(gridPen, bottomLeft, topLeft);
                }
            }
        }
    }
}
