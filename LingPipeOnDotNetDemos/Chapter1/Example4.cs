using clrsystem = System;
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
    [System.ComponentModel.Description("Evaluation of classifiers – the confusion matrix")]
    public class Example4
    {
        public void Run()
        {
            string inputPath = Util.GetRequiredFilesDirectory() + "data/disney_e_n.csv";
            string classifierPath = Util.GetRequiredFilesDirectory() + "models/1LangId.LMClassifier";
            File serializedClassifier = new File(classifierPath);
#pragma warning disable
            BaseClassifier classifier = (BaseClassifier)AbstractExternalizable.readObject(serializedClassifier);
#pragma warning restore

            List<string[]> rows = Util.readAnnotatedCsvRemoveHeader(inputPath);
            string[] categories = Util.getCategories(rows);
            
            bool storeInputs = false;
            BaseClassifierEvaluator evaluator = new BaseClassifierEvaluator(classifier, categories, storeInputs);

            foreach (var row in rows)
            {
                string truth = row[Util.ANNOTATION_OFFSET];
                string text = row[Util.TEXT_OFFSET];
                Classification classification = new Classification(truth);
                Classified classified = new Classified(text, classification);
                evaluator.handle(classified);
            }
            

            //print confusion matrix
            ConfusionMatrix confMatrix = evaluator.confusionMatrix();
            StringBuilder sb = new StringBuilder();
		    string[] labels = confMatrix.categories();
		    int[][] outcomes = confMatrix.matrix();
		    sb.Append("reference\\response\n");
		    sb.Append("          \\");
            
            for(int i =0;i<labels.Length;i++)
            {
                sb.Append(labels[i]);
            }

		    for (int i = 0; i< outcomes.Length; ++ i) 
            {
			    sb.Append("\n         " + labels[i] + " ");
			    for (int j = 0; j < outcomes[i].Length; ++j) 
                {
				    sb.Append(outcomes[i][j] + ",");
			    }
		    }
            clrsystem.Console.WriteLine(sb.ToString());
        }
    }
}
