using System;
using System.Threading;

namespace KFU_4th_lesson
{
    internal class Program
    {
        static bool ValueInArray(int[] array, int value)
        {
            foreach (int item in array) {
                if (item == value) return true;
            }
            return false;
        }
        static void PrintArray(int[] array)
        {
            foreach (int item in array) {
            Console.Write(item + " ");
            }
        }
        static void Less1()
        {
            Console.WriteLine("Задание 1:");
            Random rnd = new Random();
            int[] values = new int [20];

            for (int i = 0; i < 20; i++)
            {
                values[i] = rnd.Next();  
            }

            PrintArray(values);
            Console.WriteLine("\nВведите два числа из данного массива: ");

            if (int.TryParse(Console.ReadLine(), out int numberOne) && int.TryParse(Console.ReadLine(), out int numberTwo))
            {
                if (ValueInArray(values, numberOne) && ValueInArray(values, numberTwo))
                {
                    (values[Array.IndexOf(values, numberOne)], values[Array.IndexOf(values, numberTwo)]) = (values[Array.IndexOf(values, numberTwo)], values[Array.IndexOf(values, numberOne)]);
                    Console.WriteLine($"\nПолученный массив в результате работы программы:");
                    PrintArray(values);
                } else {
                    Console.WriteLine("Некорректный ввод. Введите два числа из массива!");
                }
            } else
            {
                Console.WriteLine("Некорректный ввод. Введите два числовых значения из массива!");
            }
            
        }
        static void MethodForLess(ref int prod, out int sum, out double avg, params int[] array)
        {
            sum = 0;
            avg = 0;

            foreach (int el in array)
            {
                sum += el;
                prod *= el;
            }

            avg = (double)sum / array.Length;
        }
        static void Less2()
        {
            Console.WriteLine("\nЗадание 2:");
            int[] values = new int[7];
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Введите число {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int val))
                {
                    values[i] = val;
                }
                else {
                    i--;
                }
            }

            int sum, prod = 1;
            double avg;
            MethodForLess(ref prod, out sum, out avg, values);

            Console.WriteLine($"Сумма элементов массива: {sum}");
            Console.WriteLine($"Произведение элементов массива: {prod}");
            Console.WriteLine($"Среднее арифметическое в массиве: {avg}");
        }
        static void DrawNumber(int number)
        {
            string[] digits = {
            "###\n# #\n# #\n# #\n###",  
            " # \n## \n # \n # \n###",
            "###\n  #\n###\n#  \n###",
            "###\n  #\n###\n  #\n###",
            "# #\n# #\n###\n  #\n  #",
            "###\n#  \n###\n  #\n###",
            "###\n#  \n###\n# #\n###",
            "###\n  #\n  #\n  #\n  #",
            "###\n# #\n###\n# #\n###",  
            "###\n# #\n###\n  #\n###"  
        };

            Console.WriteLine(digits[number]);
        }
        static void Less3()
        {
            Console.WriteLine("\nЗадание 3:\nВведите число от 0 до 9 или exit(закрыть) для завершения работы консоли");
            bool flag = true;
            while (flag)
            {
                string inputValue = Console.ReadLine();
                if (inputValue.ToLower() == "exit" || inputValue.ToLower() == "закрыть")
                {
                    flag = false;
                }
                else
                {
                    try
                    {
                        if (byte.TryParse(inputValue, out byte valueChar))
                        {
                            if (0 <= valueChar && valueChar <= 9)
                            {
                                DrawNumber(valueChar);
                                flag = false;
                            }
                            else
                            {
                                throw new FormatException("Некорректный ввод. Введите цифру от 0 до 9.");
                            }
                        }
                        else
                        {
                            throw new FormatException("Некорректный ввод. Введите цифру от 0 до 9.");  
                            
                        }
                    }catch(FormatException e) {
                        Console.BackgroundColor = ConsoleColor.Red;                       
                        Console.WriteLine(e.Message);
                        Thread.Sleep(3000);
                        Console.ResetColor();
                        flag = false;
                    }
                }
                
            }
        }
        enum TheLevelOfGrouchiness
        {
            None,
            Low,
            Medium,
            High,
            VeryHigh,
            Impossible
        }
        struct Ded {
            public string Name;
            public TheLevelOfGrouchiness Grouchiness;
            public string[] Phrases;
            public byte Bruises;

            public Ded(string Name, TheLevelOfGrouchiness Grouchiness, string[] Phrases, byte Bruises)
            {
                this.Name = Name;
                this.Grouchiness = Grouchiness;
                this.Phrases = Phrases;
                this.Bruises = 0;
            }

            public int ScanDedPhrases(params string[] badPhrases)
            {
                byte qty = 0;
                foreach (string phrase in Phrases) {
                    foreach (string el in badPhrases)
                    {
                        if (phrase.Contains(el)) qty++;                           
                    }
                }
                Bruises += qty;
                return qty;
            }
        }
        static void Less4()
        {
            Console.WriteLine("\nЗадание 5: ");
            string[] phrase1 = { "Проститутки", "Гады" };
            string[] phrase2 = { "Паршивцы", "Негодяи", "Оболтусы" };
            string[] phrase3 = { "Бараны", "Мудаки", "Невоспитанные", "Гандоны", "Чепуха" };
            string[] phrase4 = { "Козлы", "Безобразие", "Паскуда", "Бездарь"};
            string[] phrase5 = { };

            Ded[] ded = new Ded[5];
            ded[0] = new Ded { Name = "Петр", Grouchiness = TheLevelOfGrouchiness.None, Phrases = phrase5 };
            ded[1] = new Ded { Name = "Семен", Grouchiness = TheLevelOfGrouchiness.Impossible, Phrases = phrase3};
            ded[2] = new Ded { Name = "Антон", Grouchiness = TheLevelOfGrouchiness.High, Phrases = phrase2};
            ded[3] = new Ded { Name = "Геннадий", Grouchiness = TheLevelOfGrouchiness.VeryHigh, Phrases = phrase4};
            ded[4] = new Ded { Name = "Аркадий", Grouchiness = TheLevelOfGrouchiness.Medium, Phrases = phrase1 };

            string[] badPprases = { "Проститутки", "Паршивцы", "Бараны", "Козлы", "Паскуда", "Гандоны" };
            Console.WriteLine($"{ded[0].Name} получил {ded[0].ScanDedPhrases(badPprases)} фингал(ов). Текущее количество синяков: {ded[0].Bruises}");
            Console.WriteLine($"{ded[1].Name} получил {ded[1].ScanDedPhrases(badPprases)} фингал(ов). Текущее количество синяков: {ded[1].Bruises}");
            Console.WriteLine($"{ded[2].Name} получил {ded[2].ScanDedPhrases(badPprases)} фингал(ов). Текущее количество синяков: {ded[2].Bruises}");
            Console.WriteLine($"{ded[3].Name} получил {ded[3].ScanDedPhrases(badPprases)} фингал(ов). Текущее количество синяков: {ded[3].Bruises}");
            Console.WriteLine($"{ded[4].Name} получил {ded[4].ScanDedPhrases(badPprases)} фингал(ов). Текущее количество синяков: {ded[4].Bruises}");

        }
        static void Main(string[] args)
        {
            Less1();
            Less2();
            Less3();
            Less4();
        }
    }
}
