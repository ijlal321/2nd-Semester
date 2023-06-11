using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pointGame
{
    class GameObject
    {
        char[,] Shape = new char[1, 3] { { '-', '-', '-' } };
        Point StartingPoint = new Point();
        Boundary Premises = new Boundary();
        string Direction = "LeftToRight";
        string currentPartolPosition = "LeftToRight";
        int projectileStep = 1;

        public GameObject()
        {

        }

        public GameObject(Point StartingPoint)
        {
            this.StartingPoint = StartingPoint;
        }

        public GameObject(char[,] Shape, Point StartingPoint, Boundary Premises, string Direction)
        {
            this.StartingPoint = StartingPoint;
            this.Shape = Shape;
            this.Premises = Premises;
            this.Direction = Direction;
        }

        public void draw()
        {
            Console.SetCursorPosition(StartingPoint.getX(), StartingPoint.getY());
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.Write(Shape[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void erase()
        {
            Console.SetCursorPosition(StartingPoint.getX(), StartingPoint.getY());
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public void move()
        {
            if (Direction == "LeftToRight")
            {
                LeftToRight();
            }
            else if (Direction == "RightToLeft")
            {
                RightToLeft();
            }
            else if (Direction == "Patrol")
            {
                if (currentPartolPosition == "LeftToRight")
                {
                    if (LeftToRight() == false)
                    {
                        currentPartolPosition = "RightToLeft";
                    }
                }
                else if (currentPartolPosition == "RightToLeft")
                {
                    if (RightToLeft() == false)
                    {
                        currentPartolPosition = "LeftToRight";
                    }
                }


            }
            else if (Direction == "Diagonal")
            {
                if ((StartingPoint.getX() + Shape.GetLength(1)) < Premises.TopRight.getX())     // checking x axis
                {
                    if ((StartingPoint.getY() + Shape.GetLength(0)) < Premises.BottomRight.getY())     // checking Y axis
                    {
                        StartingPoint.setX(StartingPoint.getX() + 1);
                        StartingPoint.setY(StartingPoint.getY() + 1);
                    }
                }

                    

            }
            else if (Direction == "Projectile")
            {
                if (projectileStep <= 12)
                {
                    if (projectileStep <= 5)
                    {
                        StartingPoint.setX(StartingPoint.getX() + 1);
                        StartingPoint.setY(StartingPoint.getY() - 1);
                    }
                    else if (projectileStep <= 7)
                    {
                        StartingPoint.setX(StartingPoint.getX() + 1);
                    }
                    else if (projectileStep <= 11)
                    {
                        StartingPoint.setX(StartingPoint.getX() + 1);
                        StartingPoint.setY(StartingPoint.getY() + 1);
                    }
                    projectileStep += 1;
                }



            }
        }

        public bool LeftToRight()
        {
            if ((StartingPoint.getX() + Shape.GetLength(1)) <  Premises.TopRight.getX())
            {
                StartingPoint.setX(StartingPoint.getX() + 1);
                return true;
            }
            return false;
        }

        public bool RightToLeft()
        {
            if (StartingPoint.getX() > Premises.TopLeft.getX())
            {
                StartingPoint.setX(StartingPoint.getX() - 1);
                return true;
            }
            return false;
        }






    }
}
