using clrsystem =System;
using clrio = System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.classify;
using com.aliasi.util;
using java.io;

namespace LingPipeOnDotNetDemos.Chapter1
{
    /// <summary>
    /// Applying a classifier to a .csv file
    /// </summary>
    public class Example3
    {
        public void Run()
        {
            string inputPath = "cookbook/data/disney.csv";
            string classifierPath = "cookbook/models/3LangId.LMClassifier";
            File serializedClassifier = new File(classifierPath);
#pragma warning disable
            BaseClassifier classifier = (BaseClassifier)AbstractExternalizable.readObject(serializedClassifier);
#pragma warning restore
            List<string> lines = clrio.File.ReadAllLines(inputPath).ToList().Skip(1).ToList();

            foreach (string line in lines)
            {
                string tweet = line.Split(new char[] { ','})[3];
                Classification classification = Util.consoleInputPrintClassification(classifier, line);
                clrsystem.Console.WriteLine("input text:- " + tweet);
                clrsystem.Console.WriteLine("best classified language :-" + classification.bestCategory());
            }
        }
    }
}
