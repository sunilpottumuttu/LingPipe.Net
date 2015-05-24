using clrsystem = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.tokenizer;

namespace LingPipeOnDotNetDemos.Chapter2
{
    [System.ComponentModel.Description("Introduction to tokenizer factories – finding words in a character stream")]        
    public class Example1
    {
        public void Run()
        {
            TokenizerFactory tokFactory = new IndoEuropeanTokenizerFactory();
            //IndoEuropeanTokenizerFactory.INSTANCE;

            var sentenceToTokenize = "It's no use growing older if you only learn new ways of misbehaving yourself.";
            Tokenizer tokenizer = tokFactory.tokenizer(sentenceToTokenize.ToCharArray(), 0, sentenceToTokenize.Length);
            string token = null;
            while ((token = tokenizer.nextToken()) != null)
            {
                clrsystem.Console.WriteLine("Token " + token);
                clrsystem.Console.WriteLine("WhiteSpace " + tokenizer.nextWhitespace());
            }
            
        }
    }
}
