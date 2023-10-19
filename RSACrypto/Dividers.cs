using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSACrypto
{
    /// <summary>
    /// Модуль, позволяющий работать с натуральными числами и их делителями
    /// </summary>
    public static class Dividers
    {
        /// <summary>
        /// Определяет, является ли натуральное число d
        /// делителем натурального числа n
        /// </summary>
        /// <param name="n">Проверяемое число в диапозоне от 1 до Int.MaxValue</param>
        /// <param name="d">Проверяемый делитель в диапозоне от 1 до Int.MaxValue</param>
        /// <returns>
        /// True: n - делитель d,
        /// False: n - не делитель d
        /// </returns>
        public static bool IsDivider(long n, long d)
        {
            return n % d == 0;
        }

        /// <summary>
        /// Находит разложение натурального числа на простые делители и их степени
        /// </summary>
        /// <param name="n">Проверяемое натуральное число от 2 до Int.MaxValue</param>
        /// <returns>
        /// Кортеж, состоящий из двух массивов:
        /// массив целочисленных положительных делителей
        /// и массив целочисленных положительных степеней соответсвующих делителей
        /// </returns>
        public static (long[], long[]) Factorize(long n)
        {

            List<long> dividers = new List<long>();
            List<long> powers = new List<long>();
            long[] primes = AllPrimes(2, n);
            long i = 0;
            int k = 0;
            while (n > 1)
            {
                if (n % primes[i] == 0)
                {
                    dividers.Add(primes[i]);
                    powers.Add(0);
                    while (n % primes[i] == 0)
                    {
                        powers[k]++;
                        n /= primes[i];
                    }
                    k++;
                }
                i++;
            }
            return (dividers.ToArray(), powers.ToArray());
        }

        /// <summary>
        /// Проверяет, является ли данное натуральное число простым
        /// </summary>
        /// <param name="n">Проверяемое натуральное число в диапозоне от 1 до Int.MaxValue</param>
        /// <returns>
        /// True: число простое
        /// False: число составное
        /// </returns>
        public static bool IsPrime(long n)
        {
            return AllDividers(n).Length == 2;
        }
        /// <summary>
        /// Получает список всех натуральных делителей
        /// данного натурального числа
        /// </summary>
        /// <param name="n">
        /// Натуральное число, список делителей которого необходимо получить,
        /// в диапозоне от 1 до Int.MaxValue
        /// </param>
        /// <returns>Массив всех делителей числа</returns>
        public static long[] AllDividers(long n)
        {
            List<long> result = new List<long>();

            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (Dividers.IsDivider(n, i))
                {
                    result.Add(i);
                    result.Add(n / i);
                }
            }


            return result.Distinct().ToArray();
        }
        /// <summary>
        /// Находит все простые числа на отрезке 
        /// от данного натурального d 
        /// до данного натурального n
        /// с помощью метода решета Эратосфена,
        /// </summary>
        /// <param name="d">
        /// Начало проверяемого отрезка,
        /// натуральное число от 2 до Int.MaxValue
        /// </param>
        /// <param name="n">
        /// Конец проверяемого отрезка,
        /// натуральное число от n до Int.MaxValue,
        /// </param>
        /// <returns>Массив простых чисел на отрезке [d; n]</returns>
        public static long[] AllPrimes(long d, long n)
        {
            List<long> numbers = new List<long>();
            bool[] isNotPrime = new bool[n + 1];
            for (int j = 2; j * j <= n; j++)
            {
                if (!isNotPrime[j])
                    for (int i = j * j; i <= n; i += j)
                        isNotPrime[i] = true;
            }
            long start = d >= 2 ? d : 2;
            for (long i = start; i <= n; i++)
                if (!isNotPrime[i])
                    numbers.Add(i);
            return numbers.ToArray();
        }
        /// <summary>
        /// Находит все простые числа на отрезке 
        /// от данного натурального d 
        /// до данного натурального n
        /// методом перебора
        /// </summary>
        /// <param name="d">
        /// Начало проверяемого отрезка,
        /// натуральное число от 1 до Int.MaxValue
        /// </param>
        /// <param name="n">
        /// Конец проверяемого отрезка,
        /// натуральное число от n до Int.MaxValue
        /// </param>
        /// <returns>Массив простых чисел на отрезке</returns>
        public static long[] AllPrimesByCheckingAll(long d, long n)
        {
            List<long> numbers = new List<long>();

            for (long i = d; i <= n; i++)
            {
                if (IsPrime(n))
                    numbers.Add(n);
            }

            return numbers.ToArray();
        }
        /// <summary>
        /// Находит на заданном отрезке количество чисел 
        /// со строго определенным количеством небазовых делителей
        /// </summary>
        /// <param name="amountOfDividers">
        /// Заданное целое количество делителей,
        /// </param>
        /// <param name="start">
        /// Начало проверяемого отрезка,
        /// натуральное число от 1 до Int.MaxValue</param>
        /// <param name="end">
        /// Конец проверяемого отрезка,
        /// натуральное число от start до Int.MaxValue
        /// </param>
        /// <returns>
        /// Массив чисел, находящихся на данном отрезке,
        /// с определенным количеством делителей
        /// </returns>
        public static long[] FindNumsWithDividers(long amountOfDividers, long start, long end)
        {
            if (amountOfDividers == 3)
                return Dividers.FindNumsWithThreeDividers(start, end);

            List<long> list = new List<long>();
            for (long k = start; k < end; k++)
            {
                long[] divider = AllDividers(k);
                if (divider.Length == amountOfDividers + 2)
                    list.Add(k);
            }
            return list.ToArray();
        }
        /// <summary>
        /// Находит на заданном отрезке количество чисел 
        /// с ровно тремя небазовыми делителями
        /// </summary>
        /// <param name="start">
        /// Начало проверяемого отрезка,
        /// натуральное число от 1 до Int.MaxValue</param>
        /// <param name="end">
        /// Конец проверяемого отрезка,
        /// натуральное число от start до Int.MaxValue
        /// </param>
        /// <returns>
        /// Массив чисел, находящихся на данном отрезке,
        /// с ровно тремя небазовыми делителями
        /// </returns>
        public static long[] FindNumsWithThreeDividers(long start, long end)
        {
            List<long> list = new();
            foreach (long i in AllPrimes(start, (long)(Math.Sqrt(Math.Sqrt(end))) + 1))
            {
                long sqare = i * i;
                long fourth = sqare * sqare;
                list.Add(fourth);
            }
            return list.ToArray();
        }
    }
}
