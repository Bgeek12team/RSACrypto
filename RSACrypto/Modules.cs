using RSACrypto.DividersProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSACrypto
{
    /// <summary>
    /// Модуль, позволяющий осуществлять эффективные арифметические действия
    /// </summary>
    public static class Ariphmetics
    {
        /// <summary>
        /// Функция, позволяющая выполнять быстрее возведение в степень по модулю
        /// </summary>
        /// <param name="num">Число, над которым будет выполняться операция</param>
        /// <param name="pow">Число, в степень которого будет возводиться num</param>
        /// <param name="mod">
        /// Модуль, по которому будет 
        /// осуществляться возведение в степень
        /// </param>
        /// <returns>Число-результат модульной экспоненциации</returns>
        public static MyBigInteger ModularExp(MyBigInteger num, MyBigInteger pow, MyBigInteger mod)
        {
            if (pow == 0)
                return new(1);
            MyBigInteger z = ModularExp(num, pow / 2, mod);
            if (pow % 2 == 0)
                return (z * z) % mod;
            else
                return ((num % mod) * ((z * z) % mod)) % mod;
        }
    }
    /// <summary>
    /// Модуль, позволяющий осуществлять генерацию простых чисел
    /// </summary>
    public static class PrimeNumberGenerator
    {
        /// <summary>
        /// Функция, позволяющая создавать простое число в данном диапозоне
        /// </summary>
        /// <param name="from">
        /// Число - начало диапозона, в котором осуществляется генерация
        /// </param>
        /// <param name="until">
        /// Число - конец диапозона, в котором осуществляется генерация
        /// </param>
        /// <returns>Случайное простое число в данном диапозоне</returns>
        public static MyBigInteger generatePrimeNumber(MyBigInteger from, MyBigInteger until)
        {
            Random random = new Random();
            MyBigInteger[] primes = Dividers.AllPrimes(from, until);
            return primes[random.Next(primes.Length)];
        }
    }
}
