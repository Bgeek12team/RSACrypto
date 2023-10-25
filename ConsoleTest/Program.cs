using RSACrypto;
namespace ConsoleTest
{
    public static class Program
    {
        public static void Main()
        {

            string MessageS = "hello";

            //  long p, q;
            //p = PrimeNumberGenerator.generatePrimeNumber(10, 30);
            // q = PrimeNumberGenerator.generatePrimeNumber(10, 30);


            //          KeyGenerator keyGenerator = new KeyGenerator(p, q);
            //
            //        PublicKey pK1 = new PublicKey(keyGenerator.calcModule(), keyGenerator.generatePublicExp());
            //      PrivateKey prK1 = new PrivateKey(keyGenerator.calcModule(), keyGenerator.generatePrivateExp());

            //wont be in final proj
            //    if (p == q) // мда... да, да...
            //   {
            //     Console.WriteLine("unlucky try harder");
            //   return;
            //        }

            //      StringEncryptor SEnc = new StringEncryptor(pK1, MessageS);
            //    String encSMsg = SEnc.Encrypt();

            //  StringDecryptor DecS = new StringDecryptor(prK1, encSMsg);
            // String SentSMsg = DecS.Decrypt();


            //    Console.WriteLine(keyGenerator.ToString());

            //  Console.WriteLine("Orig: " + MessageS);
            // Console.WriteLine("Enc: " + encSMsg);
            // Console.WriteLine("Dec: " + SentSMsg);

            CryptoProcessRSA CP = new CryptoProcessRSA(MessageS);
            MyBigInteger a = new MyBigInteger("8748937912341234142431323213212141212");
            MyBigInteger b = new MyBigInteger("174312341321132132243123");

            Console.WriteLine(a % b);

        }
    }
}