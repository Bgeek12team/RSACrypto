using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSACrypto
{


    /// <summary>
    /// Класс, позволяющий осуществлять шифрование сообщений
    /// методом перестановки
    /// </summary>
    public class StringEncryptorTransposition
    {
        /// <summary>
        /// Поле - ключ шифрования
        /// </summary>
        private int[] encKey;
        /// <summary>
        /// Полк - шифруемое сообщение
        /// </summary>
        private string message;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса на основе данных
        /// ключа шифрования и сообщения
        /// </summary>
        /// <param name="encKey">Ключ шифрования</param>
        /// <param name="message">Сообщение в формате строки</param>
        public StringEncryptorTransposition(int[] encKey, string message)
        {
            this.message = message;
            this.encKey = encKey;
        }
        /// <summary>
        /// Позволяет зашифровать сообщение методом шифрования Цезаря
        /// </summary>
        /// <returns>Шифруемое сообщение в формате строки</returns>
        public string Encrypt()
        {
            while (message.Length % encKey.Length != 0)
            {
                message += " ";
            }
            StringBuilder encryptedMessage = new StringBuilder();
            string temp = "";
            for (int i = 0; i < message.Length; i++)
            {
                temp += message[i];
                if (temp.Length == encKey.Length)
                {
                    for (int j = 0; j < temp.Length; j++)
                    {
                        encryptedMessage.Append(temp[encKey[j] - 1]);
                    }
                    temp = "";
                }
            }
            return encryptedMessage.ToString();
        }
    }

    /// <summary>
    /// Класс, позволяющий осуществлять расшифровку сообщений,
    /// зашифрованных методом перестановки
    /// </summary>
    public class StringDecryptorTransposition
    {
        /// <summary>
        /// Поле - ключ дешифрования
        /// </summary>
        private int[] decKey;
        /// <summary>
        /// Поле - расшировываемое сообщение
        /// </summary>
        private string encryptedMessage;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса на основе данных
        /// закрытого ключа и сообщения
        /// </summary>
        /// <param name="decKey">Ключ дешифрования</param>
        /// <param name="message">Зашифрованное сообщение</param>
        public StringDecryptorTransposition(int[] decKey, string encryptedMessage)
        {
            this.encryptedMessage = encryptedMessage;
            this.decKey = decKey;
        }
        /// <summary>
        /// Позволяет расшифровать зашифрованное сообщение
        /// </summary>
        /// <returns>Расшифровываемое сообщение</returns>
        public string Decrypt()
        {
            StringBuilder decryptedMessage = new StringBuilder();
            string temp = "";
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                temp += encryptedMessage[i];
                if (temp.Length == decKey.Length)
                {
                    for (int j = 0; j < temp.Length; j++)
                    {
                        decryptedMessage.Append(temp[decKey[j]]);
                    }
                    temp = "";
                }
            }
            return decryptedMessage.ToString();
        }
    }

    /// <summary>
    /// Класс, позволяющий зашифровывыать и расшифровыывать строку
    /// </summary>
    public class CryptoProcessTransposition
    {
        /// <summary>
        /// Строка, которую шифруем
        /// </summary>
        private string message;
        /// <summary>
        /// Ключ, которым зашифровано сообщение
        /// </summary>
        private int[] encKey;
        /// <summary>
        /// Ключ, которым зашифровано сообщение
        /// </summary>
        private int[] decKey;

        public CryptoProcessTransposition(string message, string encKey)
        {
            this.message = message;
            this.encKey = new int[encKey.Length];
            for (int i = 0; i < encKey.Length; i++)
            {
                this.encKey[i] = int.Parse(encKey[i].ToString());
            }
            this.decKey = new int[encKey.Length];
            for (int i = 0; i < encKey.Length; i++)
            {
                this.decKey[this.encKey[i] - 1] = i;
            }
        }
        /// <summary>
        /// Позволяет шифровать сроку
        /// </summary>
        /// <returns></returns>
        public string encrypt()
        {
            StringEncryptorTransposition SE = new StringEncryptorTransposition(encKey, message);
            string EncMsg = SE.Encrypt();
            return EncMsg.ToString();
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
        /// Позволяет  выводить ключ шифрования
        /// </summary>
        /// <returns></returns>
        public string showEncKey()
        {
            string res = "";
            foreach (int i in encKey)
            {
                res += i.ToString();
            }
            return res;
        }
        /// <summary>
        /// Позволяет  выводить ключ дешифрования
        /// </summary>
        /// <returns></returns>
        public string showDecKey()
        {
            string res = "";
            foreach (int i in decKey)
            {
                res += (i + 1).ToString();
            }
            return res;
        }
        /// <summary>
        /// Позволяет расшифровывать зашифрованную строку
        /// </summary>
        /// <returns></returns> 
        public string decrypt()
        {
            StringDecryptorTransposition SD = new StringDecryptorTransposition(decKey, encrypt());
            string DecMsg = SD.Decrypt();
            return DecMsg.ToString();
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
}
