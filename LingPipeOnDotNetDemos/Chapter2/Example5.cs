using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.aliasi.lm;
using com.aliasi.spell;

namespace LingPipeOnDotNetDemos.Chapter2
{
    [System.ComponentModel.Description("Finding words for languages without white spaces")]      
    public class Example5
    {
        public void Run()
        {
            int nGram = 5;
            NGramProcessLM lm = new NGramProcessLM(nGram);
            WeightedEditDistance spaceInsertingEditDistance = CompiledSpellChecker.TOKENIZING;
            TrainSpellChecker trainer = new TrainSpellChecker(lm, spaceInsertingEditDistance);
            //todo... need to complete
        }
    }
}
