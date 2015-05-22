using clrsystem = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.tokenizer;

namespace LingPipeOnDotNetDemos.Chapter2
{
    /// <summary>
    /// Modifying tokenizer factories
    /// </summary>
    public class Example4
    {

        public void Run()
        {
            TokenizerFactory tokFactory = IndoEuropeanTokenizerFactory.INSTANCE;
            tokFactory = new LowerCaseTokenizerFactory(tokFactory);
            tokFactory = new Rot13TokenizerFactory(tokFactory);

            string input = "Move along, nothing to see here.";
            Tokenizer tokenizer = tokFactory.tokenizer(input.ToCharArray(), 0, input.Length);
            StringBuilder sb = new StringBuilder();
            string token = null;
            while ((token = tokenizer.nextToken()) != null)
            {
                sb.Append(token);
                sb.Append(tokenizer.nextWhitespace());
            }

            clrsystem.Console.WriteLine("Modified Output " + sb.ToString());

        }
    }


    public class Rot13TokenizerFactory : ModifyTokenTokenizerFactory
    {
        public Rot13TokenizerFactory(TokenizerFactory f):base(f)
        {
        }

        public override string modifyToken(string token)
        {
            return rot13(token);
        }

        public string rot13(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c >= 'a' && c <= 'm')
                { c += (char)13; }
                else if (c >= 'A' && c <= 'M')
                { c += (char)13; }
                else if (c >= 'n' && c <= 'z')
                { c -= (char)13; }
                else if (c >= 'N' && c <= 'Z')
                { c -= (char)13; }
                sb.Append(c);
            }
            return sb.ToString();
        }

    }
}
