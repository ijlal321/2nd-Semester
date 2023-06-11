using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pointGame
{
    class Point
    {
        int x;
        int y;

        public Point()
        {

        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public int getY()
        {
            return this.y;
        }

        public int getX()
        {
            return this.x;
        }
    }
}
