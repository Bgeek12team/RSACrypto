using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSACrypto
{

    /// <summary>
    /// Класс, позволяющий осуществлять зашировку сообщений, представленных строками
    /// С помощью шифрования Цезаря
    /// </summary>
    public class StringEncryptorCaesar
    {
        /// <summary>
        /// Поле - сдвиг
        /// </summary>
        private MyBigInteger k;
        /// <summary>
        /// Полк - шифруемое сообщение
        /// </summary>
        private string message;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса на основе данных
        /// сдвига и сообщения
        /// </summary>
        /// <param name="k">Сдвиг</param>
        /// <param name="message">Сообщение в формате строки</param>
        public StringEncryptorCaesar(MyBigInteger k, string message)
        {
            this.message = message;
            this.k = k;
        }
        /// <summary>
        /// Позволяет зашифровать сообщение методом шифрования Цезаря
        /// </summary>
        /// <returns>Шифруемое сообщение в формате строки</returns>
        public string Encrypt()
        {
            StringBuilder encryptedMessage = new StringBuilder();
            foreach (char character in message.ToCharArray())
            {
                char c = (char)(character + k);
                encryptedMessage.Append(c);
            }
            return encryptedMessage.ToString().Trim();
        }
    }

    /// <summary>
    /// Класс, позволяющий осуществлять расшифровку сообщений,
    /// зашифрованных с помощью шифра Цезаря
    /// </summary>
    public class StringDecryptorCaesar
    {
        /// <summary>
        /// Поле - сдвиг в шифре Цезаря
        /// </summary>
        private MyBigInteger offset;
        /// <summary>
        /// Поле - расшировываемое сообщение
        /// </summary>
        private string encryptedMessage;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса на основе данных
        /// закрытого ключа и сообщения
        /// </summary>
        /// <param name="offset">Cдвиг в шифре Цезаря</param>
        /// <param name="message">Зашифрованное сообщение</param>
        public StringDecryptorCaesar(MyBigInteger offset, string encryptedMessage)
        {
            this.encryptedMessage = encryptedMessage;
            this.offset = offset;
        }
        /// <summary>
        /// Позволяет расшифровать зашифрованное сообщение
        /// </summary>
        /// <returns>Расшифровываемое сообщение</returns>
        public string Decrypt()
        {
            StringBuilder decryptedMessage = new StringBuilder();

            foreach (char c in encryptedMessage)
            {
                decryptedMessage.Append((char)(c - offset));
            }
            return decryptedMessage.ToString();
        }
    }

    /// <summary>
    /// Класс, позволяющий зашифровывыать и расшифровыывать строку
    /// </summary>
    public class CryptoProcessCaesar
    {
        /// <summary>
        /// Строка, которую шифруем
        /// </summary>
        private string message;
        /// <summary>
        /// Сдвиг в шифре Цезаря
        /// </summary>
        private MyBigInteger offset;

        public CryptoProcessCaesar(string message, MyBigInteger offset)
        {
            this.message = message;
            this.offset = offset;
        }
        /// <summary>
        /// Позволяет шифровать сроку
        /// </summary>
        /// <returns></returns>
        public string encrypt()
        {
            StringEncryptorCaesar SE = new StringEncryptorCaesar(offset, message);
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
        /// Позволяет  выводить сдвиг
        /// </summary>
        /// <returns></returns>
        public string showOffset()
        {
            return offset.ToString();
        }

        /// <summary>
        /// Позволяет расшифровывать зашифрованную строку
        /// </summary>
        /// <returns></returns> 
        public string decrypt()
        {
            StringDecryptorCaesar SD = new StringDecryptorCaesar(offset, encrypt());
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
    }

    /// <summary>
    /// Класс, позволяющий осуществлять зашировку сообщений методом перестановки
    /// </summary>
}
