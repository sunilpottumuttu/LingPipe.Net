using clrsystem =System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.tokenizer;
using java.util;

namespace LingPipeOnDotNetDemos.ExampleSet2
{
    public class Example3
    {
        /// <summary>
        /// Combining tokenizers – stop word tokenizers
        /// </summary>
        public void Run()
        {
            var input = "the quick brown fox is jumping";
            TokenizerFactory tokFactory = IndoEuropeanTokenizerFactory.INSTANCE;
            tokFactory = new LowerCaseTokenizerFactory(tokFactory);

            Set stopWords = new HashSet();
            stopWords.add("the");
            stopWords.add("of");
            stopWords.add("to");
            stopWords.add("is");
            tokFactory = new StopTokenizerFactory(tokFactory, stopWords);

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
