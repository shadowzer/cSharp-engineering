using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_engineering
{
    public class Triangle
    {
        private double[] Sides = new double[3];
        private double Area;

        private Triangle(double side1, double side2, double side3)
        {
            Sides[0] = side1;
            Sides[1] = side2;
            Sides[2] = side3;
            CalcTriangleArea();
        }

        private void CalcTriangleArea()
        {
            double Semiperimeter = (Sides[0] + Sides[1] + Sides[2]) / 2;
            Area = Math.Sqrt(Semiperimeter * (Semiperimeter - Sides[0]) * (Semiperimeter - Sides[1]) * (Semiperimeter - Sides[2]));
        }

        public double GetTriangleArea()
        {
            return Area;
        }

        private static bool IsCorrectSides(double side1, double side2, double side3)
        {
            if (side1 > 0 && side2 > 0 && side3 > 0 && side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1)
                return true;
            else
                return false;
        }

        public static Triangle CreateTriangleFrom3Sides(double side1, double side2, double side3)
        {
            if (IsCorrectSides(side1, side2, side3))
                return new Triangle(side1, side2, side3);
            else
                throw new Exception("There is no triangle with these sides."); //DONE
        }

        public static double CalcSideFrom2SidesAndAngle(double side1, double side2, double angle)
        {
            if (angle > 0 && angle < 180)
                return Math.Sqrt(side1 * side1 + side2 * side2 - 2 * side1 * side2 * Math.Cos(angle * Math.PI / 180));
            else
                throw new Exception("There is no side in the triangle like that."); //DONE
        }

        public static Triangle CreateTriangleFrom2SidesAndAngle(double side1, double side2, double angle)
        {
            if (IsCorrectSides(side1, side2, CalcSideFrom2SidesAndAngle(side1, side2, angle)))
                return new Triangle(side1, side2, CalcSideFrom2SidesAndAngle(side1, side2, angle));
            else
                throw new Exception("There is no triangle with these sides and angle."); //DONE
        }

        public static double CalcSideFromSideAnd2Angles(double side, double angle1, double angle2)
        {
            if (angle1 > 0 && angle1 < 180 && angle2 > 0 && angle2 < 180 && ((angle1 + angle2) < 180) && side > 0)
            {
                return side * Math.Sin(angle1 * Math.PI / 180) / Math.Sin((180 - angle1 - angle2) * Math.PI / 180);
            }
            else
                throw new Exception("There is no side in the triangle with these angles and side.");
        }

        public static Triangle CreateTriangleFromSideAnd2Angles(double side, double angle1, double angle2)
        {
            if (IsCorrectSides(CalcSideFromSideAnd2Angles(side, angle1, angle2), CalcSideFromSideAnd2Angles(side, angle2, angle1), side) && angle1 > 0 && angle1 < 180 && angle2 > 0 && angle2 < 180 && (angle1 + angle2) < 180)
            {
                double side1 = CalcSideFromSideAnd2Angles(side, angle1, angle2);
                double side2 = CalcSideFromSideAnd2Angles(side, angle2, angle1);
                return new Triangle(side1, side2, side);
            }
            else
                throw new Exception("There is no triangle with these angles and side."); //DONE
        }
    }
}
