using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace LingPipeOnDotNetDemos
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Console.WindowWidth = 150;
            Console.WindowHeight = 50;

            string[] lstNameSpaces = new string[]
            {
                "LingPipeOnDotNetDemos.Chapter1",
                 "LingPipeOnDotNetDemos.Chapter2"
            };

            Console.WriteLine("Getting List of Classes.....");

            var listOfClasses = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where((type)=>type.IsDefined(typeof(DescriptionAttribute),false)) //get the classes where description attribute is defined
                .ToList()
                .Where(t => lstNameSpaces.Contains(t.Namespace))
                .Select((x, index) => new
                {
                    SNo = index + 1
                    ,Details= x
                })
                .ToList();

            foreach (var item in listOfClasses)
            {
                DescriptionAttribute da = (DescriptionAttribute)item.Details.GetCustomAttribute(typeof(DescriptionAttribute));
                string description = da.Description;
                //Console.WriteLine(item.SNo.ToString() + "." + item.Details.Namespace + "  " + item.Details.Name + "(" + description + ")");
                Console.WriteLine(item.SNo.ToString() + "." + description + "   (" + item.Details.Namespace + "  " + item.Details.Name + ")" );
            }
            for (; ; )
            {
                Console.WriteLine("\nEnter the SNo To Execute(Ctrl+c To Exit):-");
                string inputSno = Console.ReadLine();
                var filtered = listOfClasses.Where((i) => (i.SNo.ToString() == inputSno)).First();

                Object obj = Assembly.GetExecutingAssembly().CreateInstance(filtered.Details.Namespace + "." + filtered.Details.Name);
                MethodInfo runMethod = obj.GetType().GetMethod("Run");
                runMethod.Invoke(obj, null);

                Console.WriteLine("Finished Executing........ ");
                Console.ReadLine();
            }

        }
    }
}
