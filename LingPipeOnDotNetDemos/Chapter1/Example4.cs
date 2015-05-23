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
    /// <summary>
    /// Evaluation of classifiers – the confusion matrix
    /// </summary>
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
            //read the csv file by skipping the top row(header)
            //and get the rows that has some value in 'TRUTH' column
            List<CSV> csvList = clrio.File.ReadAllLines(inputPath)
                .ToList()
                .Skip(1)
                .Select(line => line.Split(','))
                .Where(r => r[2].ToString() != "")
                .Select(r => new CSV() { SCORE = r[0], GUESS = r[1], TRUTH = r[2], TEXT = r[3] }).ToList<CSV>();

            //baseclassifierevaluator expects string array
            string[] categories = csvList.Select(i => i.TRUTH).ToArray<string>();

            bool storeInputs = false;
            BaseClassifierEvaluator evaluator = new BaseClassifierEvaluator(classifier, categories, storeInputs);

            foreach (var item in csvList)
            {
                string truth = item.TRUTH;
                string text = item.TEXT;
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

        public class CSV
        {
            public string SCORE { get; set; }
            public string GUESS { get; set; }
            public string TRUTH { get; set; }
            public string TEXT { get; set; }
        }


    }
}
