using System;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticProgressionApp
{
    public class ArithmeticProgression
    {
        public double A0 { get; set; }
        public double D { get; set; }
        public int N { get; set; }

        public ArithmeticProgression(double a0, double d, int n)
        {
            A0 = a0;
            D = d;
            N = n;
        }

        public double GetNthTerm(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentOutOfRangeException(nameof(index));

            return A0 + index * D;
        }

        public double SumProgression()
        {
            return N * (2 * A0 + (N - 1) * D) / 2.0;
        }

        public List<double> GetAllTerms()
        {
            var terms = new List<double>();
            for (int i = 0; i < N; i++)
            {
                terms.Add(GetNthTerm(i));
            }
            return terms;
        }

        public double[] GetAllTermsArray()
        {
            return GetAllTerms().ToArray();
        }

        public override string ToString()
        {
            var terms = GetAllTerms();
            var termsString = string.Join(", ", terms.Select(t => t.ToString("F2")));

            return $"Арифметична прогресія: a₀={A0}, d={D}, n={N}\n" +
                   $"Члени: {termsString}\n" +
                   $"Сума: {SumProgression():F2}";
        }

        public bool Contains(double value)
        {
            if (Math.Abs(D) < double.Epsilon)
            {
                return Math.Abs(value - A0) < double.Epsilon;
            }

            double position = (value - A0) / D;
            return position >= 0 && position < N && Math.Abs(position - Math.Round(position)) < double.Epsilon;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.WriteLine("=== Калькулятор арифметичної прогресії ===");
            
            double a0 = GetDoubleInput("Введіть перший член прогресії (a₀): ");
            double d = GetDoubleInput("Введіть різницю прогресії (d): ");
            int n = GetIntInput("Введіть кількість членів (n): ");
            
            var progression = new ArithmeticProgression(a0, d, n);
            
            Console.WriteLine("\n" + progression);
            
            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
        
        static double GetDoubleInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double result))
                {
                    return result;
                }
                Console.WriteLine("Помилка! Введіть правильне число.");
            }
        }
        
        static int GetIntInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
                {
                    return result;
                }
                Console.WriteLine("Помилка! Введіть додатне ціле число.");
            }
        }
    }
}