using RSACrypto;

namespace uTests
{
    [TestClass]
    public class RSACryptoTests
    {
        [TestMethod]
        public void evalModularExpTest()
        {
            int expected = 8;

            int result = Convert.ToInt32(Ariphmetics.ModularExp(5, 3, 13));

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void primeNumbGenTest()
        {
            int primeNumber = Convert.ToInt32(PrimeNumberGenerator.generatePrimeNumber(100, 3000));
            bool result = Dividers.IsPrime(primeNumber);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void genPrivateKeyTest()
        {
            var keyGen = new RSAKeyGenerator(3, 7);
            int expected = 5;

            int privateExp = Convert.ToInt32(keyGen.generatePrivateExp());

            Assert.AreEqual(expected, privateExp);   
        }
        [TestMethod]
        public void cryptoTest()
        {
            string testMessage = "hello world";
            var cp = new CryptoProcessRSA(testMessage);

            string decrypted = cp.decrypt();

            Assert.AreEqual(testMessage, decrypted);
        }
        [TestMethod()]
        public void calcEulerFuncTest()
        {
            int p = 17, q = 23;
            long expected = 352;
            RSAKeyGenerator keyG = new RSAKeyGenerator(p, q);

            long EulerF = keyG.calcEulerFunc();
            Assert.AreEqual(expected, EulerF);
        }
        
        [TestMethod]
        public void isDividerTest()
        {
            int n = 50;
            int d = 2;
            bool result = Dividers.IsDivider(n, d);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void isPrimeTest_True()
        {
            int numb = 7;
            bool actual = Dividers.IsPrime(numb);
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void isPrimeTest_Fasle()
        {
            int numb = 10;
            bool actual = Dividers.IsPrime(numb);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void allDividersTest()
        {
            int n = 50;

            long[] expected = { 1, 2, 5, 10, 25, 50 };
            long[] actual = Dividers.AllDividers(n);
          
            Array.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void allPrimeTest()
        {
            long[] expected = { 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
            long[] actual = Dividers.AllPrimes(12, 50);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}