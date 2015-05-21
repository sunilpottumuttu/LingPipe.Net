using com.aliasi.tokenizer;
using sys = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sysio = System.IO;
using java.util;
using com.aliasi.classify;
using com.aliasi.util;
using java.io;

namespace LingPipeOnDotNetDemos
{
    public class UnitTest1
    {
        public void Run()
        {
            TokenizerFactory tokFactory = IndoEuropeanTokenizerFactory.INSTANCE;
            tokFactory = new LowerCaseTokenizerFactory(tokFactory);
            tokFactory = new WhitespaceNormTokenizerFactory(tokFactory);
            string text = sysio.File.ReadAllText(@"DataFiles\input.txt");
            Set stopWords = new java.util.HashSet();
            stopWords.add("the");
            stopWords.add("is");
            tokFactory = new StopTokenizerFactory(tokFactory, stopWords);
            Tokenizer tokenizer = tokFactory.tokenizer(text.ToCharArray(), 0, text.Length);
            string token = null;
            while ((token = tokenizer.nextToken()) != null)
            {
                sys.Console.WriteLine("Token:'" + token + "'");
                sys.Console.WriteLine("WhiteSpace:'" + tokenizer.nextWhitespace() + "'");
            }
            sys.Console.ReadLine();
        }
    }
}
