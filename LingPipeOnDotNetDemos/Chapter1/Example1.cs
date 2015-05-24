using clrsystem = System;
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
    /// Deserializing and running a classifier
    /// </summary>
    public class Example1
    {
        public void Run()
        {
            string classifierPath = Util.GetRequiredFilesDirectory() + "models/3LangId.LMClassifier";
            clrsystem.Console.WriteLine("Loading " + classifierPath);
            File serializedClassifier = new File(classifierPath);
#pragma warning disable
            BaseClassifier classifier = (BaseClassifier)AbstractExternalizable.readObject(serializedClassifier);
#pragma warning restore

            string japaneseSentence = "彗星は、太陽系小天体のうち主に氷や塵などでできており、太陽に近づいて一時的な大気である";
            {
                Classification classification = Util.consoleInputPrintClassification(classifier, japaneseSentence);
                clrsystem.Console.WriteLine(classification.bestCategory());
            }

            string englishSentence = "The rain in Spain falls mainly on the plain.";
            {
                Classification classification = Util.consoleInputPrintClassification(classifier, englishSentence);
                clrsystem.Console.WriteLine(classification.bestCategory());
            }

            string spanishSentence = "la lluvia en España cae principalmente en el llano.";
            {
                Classification classification = Util.consoleInputPrintClassification(classifier, spanishSentence);
                clrsystem.Console.WriteLine(classification.bestCategory());
            }

        }
    }
}
