using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pointGame
{
    class Boundary
    {
        public Point TopLeft = new Point(0,0);
        public Point BottomLeft = new Point(0, 90);
        public Point TopRight = new Point(90,0);
        public Point BottomRight = new Point(90, 90);

        public Boundary()
        {

        }

        public Boundary(Point TopLeft, Point BottomLeft, Point TopRight, Point BottomRight)
        {
            this.TopLeft = TopLeft;
            this.BottomLeft = BottomLeft;
            this.TopRight = TopRight;
            this.BottomRight = BottomRight;
        }


    }
}
