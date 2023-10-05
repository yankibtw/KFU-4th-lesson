using System;

namespace Tumakov
{
    internal class Program
    {
        static double MaxValue(double firstNumber, double secondNumber)
        {
            return firstNumber > secondNumber ? firstNumber : secondNumber;
        }
        static void Less1()
        {
            Console.WriteLine("Упражнение 5.1\nВведите, пожалуйста, два числовых значения: ");
            if (double.TryParse(Console.ReadLine(), out double firstNumber) && double.TryParse(Console.ReadLine(), out double secondNumber))
            {
                Console.WriteLine($"Максимальное из двух введеных чисел: {MaxValue(firstNumber, secondNumber)}\n");
            }
            else
            {
                Console.WriteLine("Данные введены некорректно. Пожалуйста, введите 2 числовых значения!\n");
            }
        }
        static void SwapValues(ref double first, ref double second)
        {
            (first, second) = (second, first);
        }
        static void Less2()
        {
            Console.WriteLine("Упражнение 5.2\nВведите два числа: ");
            if (double.TryParse(Console.ReadLine(), out double firstNumber) && double.TryParse(Console.ReadLine(), out double secondNumber))
            {
                Console.WriteLine($"Ваши числа до обмена: {firstNumber}, {secondNumber}");
                SwapValues(ref firstNumber, ref secondNumber);
                Console.WriteLine($"Ваши числа после обмена: {firstNumber}, {secondNumber}\n");
            }
            else
            {
                Console.WriteLine("Данные введены некорректно. Пожалуйста, введите 2 числовых значения!\n");
            }
        }
        static bool Factorial(int value, out long result)
        {
            result = 1;
            try
            {
                checked {
                    for(int i = 2; i <= value; i++)
                    {
                        result *= i;
                    }    
                }
                return true;
            }
            catch (OverflowException ) {
                return false;
            }
        }
        static void Less3()
        {
            Console.WriteLine("Упражнение 5.3\nВведите число, факториал которого Вам нужно найти: ");
            if (int.TryParse(Console.ReadLine(), out int value)){
                if (Factorial(value, out long result))
                {
                    Console.WriteLine($"Факториал числа {value} равен {result}\n");
                } else
                {
                    Console.WriteLine("Возникло переполнение!Введите значение поменьше!\n");
                }
            } else
            {
                Console.WriteLine("Данные введены некорректно. Пожалуйста, введите числовое значение!\n");
            }
        }
        static long FactorialForLess4(int value)
        { 
            return value == 1 ? 1 : value * FactorialForLess4(value - 1);
        }
        static void Less4()
        {
            Console.WriteLine("Упраждение 5.4\nВведите число для которого нужно найти факториал: ");
            if (int.TryParse(Console.ReadLine(), out int value) && FactorialForLess4(value) != 0)
            {
                Console.WriteLine($"Факториал числа {value} равен {FactorialForLess4(value)}\n");
            }
            else if (FactorialForLess4(value) == 0)
            {
                Console.WriteLine("Пожалуйста, введите числовое значение поменьше!\n");
            }
            else
            {
                Console.WriteLine("Данные введены некорректно. Пожалуйста, введите числовое значение!\n");
            }
        }
        static int NOD(int first, int second)
        {
            int maxValue = 0; 
            for (int i = 1; i <= first; i++)
            {
                if (second % i == 0 && first % i == 0 && i > maxValue)
                {
                     maxValue = i;
                } 
            }
            return maxValue;
        }
        static int NOD(int first, int second, int third) {
            int maxValue = 0;
            for (int i = 1; i <= first; i++)
            {
                if (second % i == 0 && first % i == 0 && third % i == 0 && i > maxValue)
                {
                    maxValue = i;
                }
            }
            return maxValue;
        }
        static void Less5()
        {
            Console.WriteLine("Домашнее задание 5.1\nВведите три числовых значения");
            if(int.TryParse(Console.ReadLine(), out int firstValue) && int.TryParse(Console.ReadLine(), out int secondValue) && int.TryParse(Console.ReadLine(), out int thirdValue))
            {
                Console.WriteLine($"Наибольший общий делитель для чисел {firstValue}, {secondValue} и {thirdValue} равен {NOD(firstValue, secondValue, thirdValue)}");
                Console.WriteLine($"Наибольший общий делитель для чисел {firstValue} и {secondValue} равен {NOD(firstValue, secondValue)}");
                Console.WriteLine($"Наибольший общий делитель для чисел {secondValue} и {thirdValue} равен {NOD(thirdValue, secondValue)}");
            } else
            {
                Console.WriteLine("Данные введены некорректно. Пожалуйста, введите числовые значения!\n");
            }
        }
        static long Fibonacci(int value)
        {
            return value == 1 || value == 2 ? 1 : Fibonacci(value - 1) + Fibonacci(value - 2);
        }
        static void Less6()
        {
            Console.WriteLine("\nДомашнее задание 5.2\nВведите номер n числа ряда Фибоначчи: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                Console.WriteLine($"Номеру {value} соотвествует значение {Fibonacci(value)}");
            }
            else
            {
                Console.WriteLine("Данные введены некорректно. Пожалуйста, введите числовое значение!\n");
            }
        }
        static void Main(string[] args)
        {
            Less1();
            Less2();
            Less3();
            Less4();
            Less5();
            Less6();
        }
    }
}
