using System;
using System.Linq;
using System.Text;

namespace CeasarCipherEncryptorSolution
{
    public class Program
    {
        public static string CaesarCypherEncryptor(string str, int key)
        {
            var i = 0;
            var alphaNum = Enumerable.Range('a', 'z' - 'a' + 1).Select(arg => (char)arg).ToDictionary(c => c, c => i++);
            var numAlpha = alphaNum.ToDictionary(arg => arg.Value, arg => arg.Key);
            var res = new StringBuilder();
            foreach (var c in str)
                res.Append(numAlpha[(alphaNum[c] + key) % alphaNum.Count]);

            return res.ToString();;
        }
    }
}
