using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_engineering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("You're about to create triangle via 1 of 3 methods:\n1. By using 3 sides.\n2. By using 2 sides and angle between them.\n3. By using 2 angles and side between them.\nEnter a number of method:");
            String Str = Console.ReadLine();
            while (int.Parse(Str) < 1 || int.Parse(Str) > 3)
            {
                Console.Write("Wrong input. Choose number 1 of 3 methods:");
                Str = Console.ReadLine();
            }
            Triangle Triangle;
            double[] Data = new double[3];
            Console.WriteLine("Enter 3 numbers. 1 per string. It can be integer or double.");
            Data[0] = Convert.ToDouble(Console.ReadLine());
            Data[1] = Convert.ToDouble(Console.ReadLine());
            Data[2] = Convert.ToDouble(Console.ReadLine());
            switch (Str)
            {
                case "1":
                    Triangle = Triangle.CreateTriangleFrom3Sides(Data[0], Data[1], Data[2]);
                    Console.WriteLine(Triangle.GetTriangleArea());
                    break;
                case "2":
                    Triangle = Triangle.CreateTriangleFrom2SidesAndAngle(Data[0], Data[1], Data[2]);
                    Console.WriteLine(Triangle.GetTriangleArea());
                    break;
                case "3":
                    Triangle = Triangle.CreateTriangleFromSideAnd2Angles(Data[0], Data[1], Data[2]);
                    Console.WriteLine(Triangle.GetTriangleArea());
                    break;
                default:
                    break;
            }
        }
    }
}
