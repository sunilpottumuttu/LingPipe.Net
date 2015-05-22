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
    /// Getting confidence estimates from a classifier
    /// </summary>
    public class Example2
    {
        public void Run()
        {
            string classifierPath = "models/3LangId.LMClassifier";
#pragma warning disable
            JointClassifier classifier = (JointClassifier)AbstractExternalizable.readObject(new File(classifierPath));
#pragma warning restore

            string sentense = "The rain in Spain falls mainly on the plain.";
            Classification  classification = Util.consoleInputPrintClassification(classifier, sentense);
            clrsystem.Console.WriteLine(classification);


        }
    }
}
