using RSACrypto.DividersProject;
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
        public static bool IsDivider(MyBigInteger n, MyBigInteger d)
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
        public static (MyBigInteger[], MyBigInteger[]) Factorize(MyBigInteger n)
        {

            List<MyBigInteger> dividers = new List<MyBigInteger>();
            List<MyBigInteger> powers = new List<MyBigInteger>();
            MyBigInteger[] primes = AllPrimes(new(2), n);
            long i = 0;
            int k = 0;
            while (n > 1)
            {
                if (n % primes[i] == 0)
                {
                    dividers.Add(primes[i]);
                    powers.Add(new(0));
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
        public static bool IsPrime(MyBigInteger n)
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
        public static MyBigInteger[] AllDividers(MyBigInteger n)
        {
            List<MyBigInteger> result = new List<MyBigInteger>();

            for (MyBigInteger i = new(1); i <= MyBigInteger.Sqrt(n); i++)
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
        public static MyBigInteger[] AllPrimes(MyBigInteger d, MyBigInteger n)
        {
            List<MyBigInteger> numbers = new List<MyBigInteger>();
            bool[] isNotPrime = new bool[(int)n + 1];
            for (int j = 2; j * j <= n; j++)
            {
                if (!isNotPrime[j])
                    for (int i = j * j; i <= n; i += j)
                        isNotPrime[i] = true;
            }
            MyBigInteger start = d >= 2 ? d : new MyBigInteger(2);
            for (MyBigInteger i = start; i <= n; i++)
                if (!isNotPrime[(int)i])
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
        public static MyBigInteger[] AllPrimesByCheckingAll(MyBigInteger d, MyBigInteger n)
        {
            List<MyBigInteger> numbers = new List<MyBigInteger>();

            for (MyBigInteger i = d; i <= n; i++)
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
        public static MyBigInteger[] FindNumsWithDividers(long amountOfDividers, MyBigInteger start, MyBigInteger end)
        {
            if (amountOfDividers == 3)
                return Dividers.FindNumsWithThreeDividers(start, end);

            List<MyBigInteger> list = new List<MyBigInteger>();
            for (MyBigInteger k = start; k < end; k++)
            {
                MyBigInteger[] divider = AllDividers(k);
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
        public static MyBigInteger[] FindNumsWithThreeDividers(MyBigInteger start, MyBigInteger end)
        {
            List<MyBigInteger> list = new();
            foreach (MyBigInteger i in AllPrimes(start, (MyBigInteger.Sqrt(MyBigInteger.Sqrt(end))) + 1))
            {
                MyBigInteger sqare = i * i;
                MyBigInteger fourth = sqare * sqare;
                list.Add(fourth);
            }
            return list.ToArray();
        }
    }
}
