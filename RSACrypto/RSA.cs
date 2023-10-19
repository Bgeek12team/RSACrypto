using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RSACrypto
{
    /// <summary>
    /// Класс, предоставляющий возможность генерировать 
    /// ключи для ассиметричного шифрования
    /// </summary>
    public class RSAKeyGenerator
    {
        /// <summary>
        /// Константа - общепринятое значение открытой экспоненты,
        /// равное 2^16 + 1
        /// </summary>
        public const int PUBLIC_EXP = 65537;
        /// <summary>
        /// Простое число p, использующееся для генерации ключей
        /// </summary>
        private long p;
        /// <summary>
        /// Простое число q, использующееся для генерации ключей
        /// </summary>
        private long q;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр данного объекта,
        /// на основе данных значений простых чисел p и q
        /// </summary>
        /// <param name="p">
        /// Простое число p, использующееся для генерации ключей
        /// </param>
        /// <param name="q">
        /// Простое число q, использующееся для генерации ключей
        /// </param>
        public RSAKeyGenerator(long p, long q)
        {
            this.p = p;
            this.q = q;
        }
        /// <summary>
        /// Функция, позволяющая высчитать модуль для данных ключей
        /// </summary>
        /// <returns>
        /// Модуль - произведение простых чисел p и q
        /// </returns>

        public long calcModule()
        {
            return p * q;
        }
        /// <summary>
        /// Функция, позволяющая высчитать значение функции Эйлера
        /// </summary>
        /// <returns>
        /// Значение функции Эйлера - произведение простых чисел,
        /// уменьшенных на единицу
        /// </returns>
        public long calcEulerFunc()
        {
            return (p - 1) * (q - 1);
        }
        /// <summary>
        /// Позволяет получить значение открытой экспоненты
        /// </summary>
        /// <returns>Значение открытой экспоненты</returns>

        public long generatePublicExp()
        {
            return PUBLIC_EXP;
        }
        /// <summary>
        /// Позволяет получить значение закрытой экспоненты
        /// </summary>
        /// <returns>Значение закрытой экспоненты</returns>
        public long generatePrivateExp()
        {
            long e = generatePublicExp();
            long fi = calcEulerFunc();
            long d = Extendedgcd(e, fi).x;
            if (d < 0)
                return d + fi;
            else return d;
        }
        /// <summary>
        /// Функция, позволяющая получить значение наибольшего общего делителя чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>
        /// Кортеж, состоящий из 3 чисел:
        /// НОД первого и второго числа,
        /// первое число,
        /// второе число
        /// </returns>
        private (long gcd, long x, long y) Extendedgcd(long a, long b)
        {
            long gcd, x, y, x1, y1;
            if (b == 0) return (a, 1, 0);
            (gcd, x1, y1) = Extendedgcd(b, a % b);
            x = y1;
            y = x1 - (a / b) * y1;
            return (gcd, x, y);
        }
        /// <summary>
        /// Возвращает данные о текущем объекте в формате строки
        /// </summary>
        /// <returns>
        /// Данные о текущем объекте:
        /// значения p, q, модуль, Эйлерова функция,
        /// открытая и закрытая экспоненты
        /// </returns>
        public override string ToString()
        {
            return
                $"p: {p};\n" +
                $"q: {q};\n" +
                $"module: {calcModule()};\n" +
                $"euler function value: {calcEulerFunc()};\n" +
                $"public exponent: {generatePublicExp()};\n" +
                $"private exponent: {generatePrivateExp()};\n";
        }
    }
    /// <summary>
    /// Класс, позволяющий осуществлять зашифровку сообщений методом RSA
    /// </summary>
    public class RSAEncryptor
    {
        /// <summary>
        /// Поле - открытый ключ
        /// </summary>
        private PublicKey publicKey;
        /// <summary>
        /// Поле - шифруемое сообщение
        /// </summary>
        private Message message;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса на основе данных
        /// открытого ключа и сообщения
        /// </summary>
        /// <param name="publicKey">Открытый ключ, с помощью которого шифруется сообщения</param>
        /// <param name="message">Шифруемое сообщение</param>
        public RSAEncryptor(PublicKey publicKey, Message message)
        {
            this.message = message;
            this.publicKey = publicKey;
        }
        /// <summary>
        /// Позволяет зашифровать сообщение методом RSA
        /// </summary>
        /// <returns>Зашифрованное сообщение</returns>
        public Message encrypt()
        {
            return
            new Message(
                Ariphmetics.ModularExp(message.getMessage(),
                    publicKey.getPublicExp(),
                    publicKey.getN()
                    )
                );
        }
    }
    /// <summary>
    /// Класс, позволяющий осуществлять расшифровку сообщений,
    /// зашифрованных методом RSA
    /// </summary>
    public class RSADecryptor
    {
        /// <summary>
        /// Поле - закрытый ключ
        /// </summary>
        private PrivateKey privateKey;
        /// <summary>
        /// Поле - расшировываемое сообщение
        /// </summary>
        private Message encryptedMessage;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса на основе данных
        /// закрытого ключа и сообщения
        /// </summary>
        /// <param name="privateKey">Закрытый ключ, с помощью которого зашифровано сообщение</param>
        /// <param name="message">Зашифрованное сообщение</param>
        public RSADecryptor(PrivateKey privateKey, Message message)
        {
            this.privateKey = privateKey;
            this.encryptedMessage = message;
        }
        /// <summary>
        /// Позволяет расшифровать зашифрованное сообщение
        /// </summary>
        /// <returns>Расшифровываемое сообщение</returns>
        public Message decrypt()
        {
            return
                new Message(
                    Ariphmetics.ModularExp(
                        encryptedMessage.getMessage(),
                        privateKey.getPrivateExp(),
                        privateKey.getN()
                        )
                        );
        }

    }
    /// <summary>
    /// Класс, позволяющий осуществлять расшировку сообщений, представленных строками
    /// </summary>
    public class RSAStringEncryptor
    {
        /// <summary>
        /// Поле - открытый ключ
        /// </summary>
        private PublicKey publicKey;
        /// <summary>
        /// Шифруемое сообщение
        /// </summary>
        private string message;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса на основе данных
        /// открытого ключа и сообщения
        /// </summary>
        /// <param name="publicKey">Открытый ключ</param>
        /// <param name="message">Сообщение в формате строки</param>
        public RSAStringEncryptor(PublicKey publicKey, string message)
        {
            this.message = message;
            this.publicKey = publicKey;
        }
        /// <summary>
        /// Позволяет зашифровать сообщение методом RSA
        /// </summary>
        /// <returns>Шифруемое сообщение в формате строки</returns>
        public string Encrypt()
        {
            StringBuilder encryptedMessage = new StringBuilder();

            foreach (char character in message.ToCharArray())
            {
                long charValue = (long)character;
                long encryptedCharValue = Ariphmetics.ModularExp(charValue, publicKey.getPublicExp(), publicKey.getN());
                encryptedMessage.Append(encryptedCharValue).Append(" ");
            }

            return encryptedMessage.ToString().Trim();
        }
    }
    /// <summary>
    /// Класс, позволяющий осуществлять расшифровку сообщений,
    /// зашифрованных методом RSA
    /// </summary>
    public class RSAStringDecryptor
    {
        /// <summary>
        /// Поле - закрытый ключ
        /// </summary>
        private PrivateKey privateKey;
        /// <summary>
        /// Поле - расшировываемое сообщение
        /// </summary>
        private string encryptedMessage;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса на основе данных
        /// закрытого ключа и сообщения
        /// </summary>
        /// <param name="privateKey">Закрытый ключ, с помощью которого зашифровано сообщение</param>
        /// <param name="message">Зашифрованное сообщение</param>
        public RSAStringDecryptor(PrivateKey privateKey, string encryptedMessage)
        {
            this.encryptedMessage = encryptedMessage;
            this.privateKey = privateKey;
        }
        /// <summary>
        /// Позволяет расшифровать зашифрованное сообщение
        /// </summary>
        /// <returns>Расшифровываемое сообщение</returns>
        public string Decrypt()
        {
            StringBuilder decryptedMessage = new StringBuilder();
            string[] encryptedValues = encryptedMessage.Split(' ');

            foreach (string encryptedValue in encryptedValues)
            {
                if (!string.IsNullOrWhiteSpace(encryptedValue))
                {
                    long encryptedCharValue = long.Parse(encryptedValue);
                    long decryptedCharValue = Ariphmetics.ModularExp(encryptedCharValue, privateKey.getPrivateExp(), privateKey.getN());
                    char decryptedChar = (char)decryptedCharValue;
                    decryptedMessage.Append(decryptedChar);
                }
            }

            return decryptedMessage.ToString();
        }
    }
    /// <summary>
    /// Класс, позволяющий зашифровывыать и расшифровыывать строку
    /// </summary>

    public class CryptoProcessRSA
    {
        /// <summary>
        /// Строка, которую шифруем
        /// </summary>
        private string message;
        /// <summary>
        /// Начало отрезка, на котором мы выбираем простые числа
        /// </summary>
        const int from = 100;
        /// <summary>
        /// Конец отрезка, для выбора простых чисел
        /// </summary>
        const int to = 3000;

        long p;
        long q;
        /// <summary>
        /// Генерация открытого и закрытого ключа
        /// </summary>
        RSAKeyGenerator keyGenerator;
        PublicKey pK1;
        PrivateKey prK1;

        public CryptoProcessRSA(string message)
        {
            this.message = message;
            p = PrimeNumberGenerator.generatePrimeNumber(from, to);
            q = PrimeNumberGenerator.generatePrimeNumber(from, to);
            keyGenerator = new RSAKeyGenerator(p, q);
            pK1 = new PublicKey(keyGenerator.calcModule(), keyGenerator.generatePublicExp());
            prK1 = new PrivateKey(keyGenerator.calcModule(), keyGenerator.generatePrivateExp());
        }
        /// <summary>
        /// Позволяет шифровать сроку
        /// </summary>
        /// <returns></returns>
        public string encrypt()
        {
            RSAStringEncryptor SE = new RSAStringEncryptor(pK1, message);
            string EncMsg = SE.Encrypt();
            return EncMsg.ToString().Trim();
        }
        /// <summary>
        /// Позволяет выводить изначальную строку
        /// </summary>
        /// <returns></returns>
        public string showMsg()
        {
            return message;
        }
        /// <summary>
        /// Позволяет  выводить закрытый ключ
        /// </summary>
        /// <returns></returns>
        public string showPrivateKey()
        {
            return prK1.ToString();
        }
        /// <summary>
        /// Позволяет выводить открытый ключ
        /// </summary>
        /// <returns></returns>
        public string showPublicKey()
        {
            return pK1.ToString();
        }
        /// <summary>
        /// Позволяет расшифровывать зашифрованную строку
        /// </summary>
        /// <returns></returns> 
        public string decrypt()
        {
            RSAStringDecryptor SD = new RSAStringDecryptor(prK1, encrypt());
            string DecMsg = SD.Decrypt();
            return DecMsg.ToString().Trim();
        }
        /// <summary>
        /// Выводит зашифрованную строку
        /// </summary>
        /// <returns></returns>
        public string showEncrypt()
        {
            return encrypt().ToString().Trim();
        }
        /// <summary>
        /// Выводит расшифрованную строку
        /// </summary>
        /// <returns></returns>
        public string showDecrypt()
        {
            return decrypt().ToString().Trim();
        }
        /// <summary>
        /// Получает генератор ключей, приведенный к строке
        /// </summary>
        /// <returns>Строка, содержащая данные о генераторе ключей</returns>
        public string showKeyGen()
        {
            return keyGenerator.ToString();
        }
    }

}