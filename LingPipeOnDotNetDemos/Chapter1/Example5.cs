using com.aliasi.util;
using java.io;
using clrsystem = System;
using clrio = System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.classify;
using java.lang;

namespace LingPipeOnDotNetDemos.Chapter1
{
    [System.ComponentModel.Description("Training your own language model classifier")]    
    public class Example5
    {
        public void Run()
        {
            string inputPath = Util.GetRequiredFilesDirectory() + "data/disney_e_n.csv";
            List<string[]> annotatedData = Util.readAnnotatedCsvRemoveHeader(inputPath);
            string[] categories = Util.getCategories(annotatedData);
            int maxCharNGram = 3;
            DynamicLMClassifier classifier = DynamicLMClassifier.createNGramBoundary(categories.ToArray(), maxCharNGram);

            foreach (var item in annotatedData)
            {
                string truth = item[Util.ANNOTATION_OFFSET];
                string text = item[Util.TEXT_OFFSET];
                Classification classification = new Classification(truth);
                Classified classified = new Classified(text, classification);
                //classifier.handle(classified);
                int count = 1;
                classifier.train(truth, text, count);
            }

            string s1 = "So it goes.";
            Util.consoleInputPrintClassification(classifier, s1);

            string s2 = "El Jardín de senderos que se bifurcan";
            Util.consoleInputPrintClassification(classifier, s2);

            string s3 = "Borge’s The Garden of the Forking Paths:";
            Util.consoleInputPrintClassification(classifier, s3);
        }
    }
}
