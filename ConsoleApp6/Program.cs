using System;

namespace Lab05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("   ЛАБОРАТОРНА РОБОТА №5 (Варіант 6)");
            Console.WriteLine("   Тема: Програмування циклічних алгоритмів");
            Console.WriteLine("==================================================\n");

            // -----------------------------------------------------------------
            // РІВЕНЬ А: Табулювання функції y = x^2 - 4x + 3
            // -----------------------------------------------------------------
            Console.WriteLine("--- РІВЕНЬ А: Табулювання функції y = x^2 - 4x + 3 ---");

            // 1. Введення вихідних даних із перевіркою коректності
            double a = ReadDouble("Введіть ліву межу відрізка (a): ");
            double b = ReadDouble("Введіть праву межу відрізка (b): ");

            if (a > b)
            {
                Console.WriteLine("Зауваження: ліва межа a була більшою за b. Значення поміняно місцями.");
                double temp = a;
                a = b;
                b = temp;
            }

            double h;
            do
            {
                h = ReadDouble("Введіть крок h (h > 0): ");
                if (h <= 0)
                {
                    Console.WriteLine("Помилка: крок h повинен бути більшим за нуль!");
                }
            } while (h <= 0);

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine($"| {"x",10} | {"y = x^2 - 4x + 3",18} | {"Примітка",12} |");
            Console.WriteLine("--------------------------------------------------");

            // 2. Основний цикл (версія FOR)
            int stepCount = (int)Math.Floor((b - a) / h) + 1;
            int negativeCount = 0; // Лічильник від'ємних значень

            for (int i = 0; i < stepCount; i++)
            {
                double x = a + i * h;

                // Запобігаємо виходу за межу через точність double
                if (x > b + 1e-9) break;

                double y = x * x - 4 * x + 3;
                string note = "";

                if (y < 0)
                {
                    note = "y < 0 (-)";
                    negativeCount++;
                }

                Console.WriteLine($"| {x,10:F2} | {y,18:F4} | {note,-12} |");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Усього точок: {stepCount}, з них від'ємних: {negativeCount}\n");

            // 3. Друга версія основного циклу (версія WHILE)
            Console.WriteLine("--- Демонстрація другої версії циклу (WHILE) ---");
            double currentX = a;
            int stepCounterWhile = 0;

            while (currentX <= b + 1e-9)
            {
                double y = currentX * currentX - 4 * currentX + 3;
                stepCounterWhile++;
                currentX += h;
            }
            Console.WriteLine($"Цикл WHILE успішно відпрацював. Оброблено точок: {stepCounterWhile}\n");

            // -----------------------------------------------------------------
            // РІВЕНЬ Б: Малювання квадрата n x n вкладеними циклами
            // -----------------------------------------------------------------
            Console.WriteLine("==================================================");
            Console.WriteLine("--- РІВЕНЬ Б: Малювання квадрата n x n ---");

            int n;
            do
            {
                n = ReadInt("Введіть розмір сторони квадрата n (від 3 до 20): ");
                if (n < 3 || n > 20)
                {
                    Console.WriteLine("Помилка: n має бути в межах від 3 до 20!");
                }
            } while (n < 3 || n > 20);

            Console.WriteLine($"\nКвадрат розміром {n}x{n}:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Правило 1: Головна (i == j) та побічна (i + j == n - 1) діагоналі
                    if (i == j || i + j == n - 1)
                    {
                        Console.Write("#");
                    }
                    // Правило 2: Межа квадрата (перший/останній рядок або стовпець)
                    else if (i == 0 || i == n - 1 || j == 0 || j == n - 1)
                    {
                        Console.Write("*");
                    }
                    // Правило 3: Усі інші внутрішні клітинки
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nРоботу завершено. Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }

        /// <summary>
        /// Метод для безпечного введення дійсного числа (double)
        /// </summary>
        static double ReadDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Помилка! Введіть коректне число.");
            }
        }

        /// <summary>
        /// Метод для безпечного введення цілого числа (int)
        /// </summary>
        static int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Помилка! Введіть ціле число.");
            }
        }
    }
}