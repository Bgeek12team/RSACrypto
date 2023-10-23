using RSACrypto.DividersProject;

namespace RSACrypto
{
    /// <summary>
    /// Класс, предоставляющий возможность хранить одно поле - 
    /// значение ключа
    /// </summary>
    public class Key
    {
        /// <summary>
        /// Поле - значение ключа
        /// </summary>
        private MyBigInteger n;
        /// <summary>
        /// Конструктор, позволяющий создать экземпляр класса на основе данного значения ключа
        /// </summary>
        /// <param name="n">Значение ключа n </param>
        public Key(MyBigInteger n)
        {
            this.n = n;
        }
        /// <summary>
        /// Возвращает значение ключа
        /// </summary>
        /// <returns>N - значение ключа</returns>
        public MyBigInteger getN()
        {
            return n;
        }

        /// <summary>
        /// Позволяет получить строку, отображающую основные сведения
        /// о текущем экземпляре ключа
        /// </summary>
        /// <returns>
        /// Строка, отображающая текущее n-значение ключа
        /// </returns>
        public override string ToString()
        {
            return $"[{n}]";
        }
    }
    /// <summary>
    /// Класс, хранящий в себе данные, необходимые для создания открытого ключа:
    /// значение открытой экспоненты и значение ключа
    /// </summary>
    public class PublicKey : Key
    {
        /// <summary>
        /// Значение октрытой экспоненты
        /// </summary>
        private MyBigInteger publicExp;
        /// <summary>
        /// Конструктор, позволяющий создать экземпляр класса на основе
        /// данного значения открытой экспоненты и значения ключа n
        /// </summary>
        /// <param name="n">Значение ключа n </param>
        /// <param name="publicExp">Значение открытой экспоненты </param>
        public PublicKey(MyBigInteger n, MyBigInteger publicExp) : base(n)
        {
            this.publicExp = publicExp;
        }
        /// <summary>
        /// Позволяет получить значение открытой экспоненты
        /// данного открытого ключа
        /// </summary>
        /// <returns>Значение открытой экспоненты</returns>
        public MyBigInteger getPublicExp()
        {
            return this.publicExp;
        }
        /// <summary>
        /// Позволяет получить строку, отображающую основные сведения
        /// о текущем экземпляре ключа
        /// </summary>
        /// <returns>
        /// Строка, отображающая текущее n-значение ключа,
        /// а также значение открытой экспоненты
        /// </returns>
        public override string ToString()
        {
            return $"[n: {this.getN()}, public exp: {getPublicExp()}]";
        }
    }
    /// <summary>
    /// Класс, хранящий в себе данные, необходимые для создания открытого ключа:
    /// значение закрытой экспоненты и значение ключа
    /// </summary>
    public class PrivateKey : Key
    {
        /// <summary>
        /// Значение закрытой экспоненты
        /// </summary>
        private MyBigInteger privateExp;
        /// <summary>
        /// Конструктор, позволяющий создать экземпляр класса на основе
        /// данного значения открытой экспоненты и значения ключа n
        /// </summary>
        /// <param name="n">Значение ключа n </param>
        /// <param name="privateExp">Значение закрытой экспоненты </param>
        public PrivateKey(MyBigInteger n, MyBigInteger privateExp) : base(n)
        {
            this.privateExp = privateExp;
        }
        /// <summary>
        /// Позволяет получить значение закрытой экспоненты
        /// данного открытого ключа
        /// </summary>
        /// <returns>Значение открытой экспоненты</returns>
        public MyBigInteger getPrivateExp()
        {
            return this.privateExp;
        }
        /// <summary>
        /// Позволяет получить строку, отображающую основные сведения
        /// о текущем экземпляре ключа
        /// </summary>
        /// <returns>
        /// Строка, отображающая текущее n-значение ключа,
        /// а также значение закрытой экспоненты
        /// </returns>
        public override string ToString()
        {
            return $"[n: {this.getN()}, private exp: {getPrivateExp()}]";
        }
    }
    /// <summary>
    /// Класс, позволяющий хранить сообщение, состоящее из одного символа
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Символ - значение сообщения
        /// </summary>
        private char message;
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса
        /// на основе символа
        /// </summary>
        /// <param name="message">Символ - сообщение</param>
        public Message(char message)
        {
            this.message = message;
        }
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса
        /// на основе числа в формате Int64
        /// </summary>
        /// <param name="message">Код символа в формате Int64</param>
        public Message(long message)
        {
            this.message = (char)message;
        }
        /// <summary>
        /// Конструктор, позволяющий создавать экземпляр класса
        /// на основе числа в формате Int32
        /// </summary>
        /// <param name="message">Код символа в формате Int32</param>
        public Message(MyBigInteger message)
        {
            this.message = (char)message;
        }
        /// <summary>
        /// Позволяет получить код сообщения в формате Int32
        /// </summary>
        /// <returns>Код сообщения в формате Int32</returns>
        public long getMessage()
        {
            return this.message;
        }
        /// <summary>
        /// Позволяет получить строку, содержающую один символ - данное сообщение
        /// </summary>
        /// <returns>
        /// Строка, состоящая из одно символа - текущего символа
        /// </returns>
        public override string ToString()
        {
            return message.ToString();
        }

    }

}