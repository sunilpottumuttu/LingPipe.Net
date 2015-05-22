using clrsystem = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.classify;
using java.io;

namespace LingPipeOnDotNetDemos
{
    public class Util
    {

        public static Classification consoleInputPrintClassification(BaseClassifier classifier, string input)
        {
            Classification classification = classifier.classify(input);
            return classification;
        }

        public static void ConsoleInputBestCategory(BaseClassifier classifier)
        {
            while (true)
            {
                clrsystem.Console.WriteLine("\nType a string to be classified. " + " Emptystring to quit.");
                string data = clrsystem.Console.ReadLine();
                if (data.Equals(""))
                {
                    return;
                }

                Classification classification = consoleInputPrintClassification(classifier, data);
                clrsystem.Console.WriteLine("Best Category: " + classification.bestCategory());
            }
        }

        

    }
}
