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
    [System.ComponentModel.Description("Getting confidence estimates from a classifier")]
    public class Example2
    {
        public void Run()
        {
            string classifierPath = Util.GetRequiredFilesDirectory() + "models/3LangId.LMClassifier";
#pragma warning disable
            JointClassifier classifier = (JointClassifier)AbstractExternalizable.readObject(new File(classifierPath));
#pragma warning restore

            string sentense = "The rain in Spain falls mainly on the plain.";
            Util.consoleInputPrintClassification(classifier, sentense);
            //clrsystem.Console.WriteLine(classification);


        }
    }
}
