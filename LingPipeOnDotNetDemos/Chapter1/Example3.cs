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
            string inputPath = Util.GetRequiredFilesDirectory() + "data/disney.csv";
            string classifierPath = Util.GetRequiredFilesDirectory() + "models/3LangId.LMClassifier";
            File serializedClassifier = new File(classifierPath);
#pragma warning disable
            BaseClassifier classifier = (BaseClassifier)AbstractExternalizable.readObject(serializedClassifier);
#pragma warning restore
            List<string[]> lines = Util.readCsvRemoveHeader(inputPath);//clrio.File.ReadAllLines(inputPath).ToList().Skip(1).ToList();

            foreach (string[] line in lines)
            {
                string text = line[Util.TEXT_OFFSET];
                Classification classification = classifier.classify(text);
                clrsystem.Console.WriteLine("input text:- " + text);
                clrsystem.Console.WriteLine("best classified language :-" + classification.bestCategory());
            }
        }
    }
}
