using clrsystem = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.tokenizer;

namespace LingPipeOnDotNetDemos.Chapter2
{
    /// <summary>
    /// Combining tokenizers – lowercase tokenizer
    /// </summary>
    public class Example2
    {
        public void Run()
        {
            var input = "This is an UPPERCASE word and these are numbers 1 2 3 4.5.";
            TokenizerFactory tokFactory = new IndoEuropeanTokenizerFactory();
            tokFactory = new LowerCaseTokenizerFactory(tokFactory);
            tokFactory = new WhitespaceNormTokenizerFactory(tokFactory);


            Tokenizer tokenizer = tokFactory.tokenizer(input.ToCharArray(), 0, input.Length);
           
            string token = null;
            while ((token = tokenizer.nextToken()) != null)
            {
                clrsystem.Console.WriteLine("token " + token);
                clrsystem.Console.WriteLine("whitespace " + tokenizer.nextWhitespace());
            }

        }
    }
}
