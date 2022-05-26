using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesisUI
{
    public class Line
    {
        private Point start;
        private Point end;

        public Point getStart()
        {
            return this.start;
        }
        public Point getEnd()
        {
            return this.end;
        }
        public void setStart(Point p)
        {
            this.start = p;
        }
        public void setEnd(Point p)
        {
            this.end = p;
        }
    }

    struct LineUnderMouse
    {
        public int lineIndex;
        public int pointNum; //start = 0, end = 1
    }

    public partial class UserControl1 : UserControl
    {
        Line l1 = new Line();
        Point p = new Point(10,15);
        // l1.setStart(p);
        List<Line> lines = new List<Line>();
        bool IsMouseDown = false;
        LineUnderMouse LineUnderMouse = new LineUnderMouse();
        public UserControl1()
        {
            InitializeComponent();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            IsMouseDown = true;
            Point MouseDownPos = e.Location;
            
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                IsMouseDown = false;
                LineUnderMouse.lineIndex = -1;
                LineUnderMouse.pointNum = -1;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(IsMouseDown == true && LineUnderMouse.lineIndex != -1)
            {
                if(LineUnderMouse.pointNum == 0)
                {
                    lines[LineUnderMouse.lineIndex].setStart(e.Location);
                } 
                else if (LineUnderMouse.pointNum == 1)
                {
                    lines[LineUnderMouse.lineIndex].setEnd(e.Location);
                }
            }
        }

        public bool IsLinePoint(Point point)
        {
            for (int i = 0; i < lines.Count(); ++i)
            {
                Console.WriteLine(lines[i]);
                if (lines[i].getStart() == point)
                {
                    LineUnderMouse.lineIndex = i;
                    LineUnderMouse.pointNum = 0;
                }
                else if (lines[i].getEnd() == point)
                {
                    LineUnderMouse.lineIndex = i;
                    LineUnderMouse.pointNum = 1;
                }
            }

            return true;
        }
    }
}
