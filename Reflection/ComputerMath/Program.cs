using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMath
{
    // С использованием LINQ Expressions напишите метод, который бы дифференцировал лямбда-выражения от одной double-переменной, 
    // состоящие из операторов сложения, умножения, скобок и функции Math.Sin. Результат работы метода должен быть скомпилированным делегатом.
    class Program
    {
        public static Expression<Func<double, double>> Differentiate(Expression expression)
        {
            if (expression is ConstantExpression)
                return x => 0;

            if (expression is ParameterExpression)
                return x => 1;

            if (expression is LambdaExpression)
                return Differentiate(((LambdaExpression)expression).Body);

            if (expression is BinaryExpression)
            {
                if (((BinaryExpression)expression).NodeType != ExpressionType.Add || ((BinaryExpression)expression).NodeType != ExpressionType.Multiply)
                    throw new Exception("lambda can consists only of addiction, multiply and sine");

                if (((BinaryExpression)expression).NodeType == ExpressionType.Add)
                {
                    return 
                        Expression.Lambda<Func<double, double>>(
                            Expression.Add(
                               Differentiate(((BinaryExpression)expression).Left),
                               Differentiate(((BinaryExpression)expression).Right)
                            ), 
                            Expression.Parameter(typeof(double), "x")
                        );
                }

                if (((BinaryExpression)expression).NodeType == ExpressionType.Multiply)
                {
                    return
                        Expression.Lambda<Func<double, double>>(
                            Expression.Add(
                                Expression.Multiply(
                                    Differentiate(((BinaryExpression)expression).Left).Body,
                                    ((BinaryExpression)expression).Right
                                ),
                                Expression.Multiply(
                                    ((BinaryExpression)expression).Left,
                                    Differentiate(((BinaryExpression)expression).Right).Body
                                )
                            ),
                            Expression.Parameter(typeof(double), "x")
                        );
                }
            }

            if (expression is MethodCallExpression)
            {
                if (((MethodCallExpression)expression).Method.Name != "sin")
                    throw new Exception("lambda can consists only of addiction, multiply and sine");
                
                return
                    Expression.Lambda<Func<double, double>>(
                        Expression.Multiply(
                            Differentiate(((MethodCallExpression)expression).Arguments[0]),
                            Expression.Call(typeof(Math).GetMethod("cos"), ((MethodCallExpression)expression).Arguments[0])
                        ),
                        Expression.Parameter(typeof(double), "x")
                    );
            }

            throw new Exception("lambda can consists only of addiction, multiply and sine");
        }
    }
}
