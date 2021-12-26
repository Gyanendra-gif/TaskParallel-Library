using System;
using System.Threading.Tasks;

namespace TaskParallel_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Task Parallel Program");
            Config config = new Config();
            String[] words = config.CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");
            #region ParallelTasks
            Parallel.Invoke(
                   () =>
                   {
                       Console.WriteLine("Begin First Task ...");
                       config.GetLongestWord(words);
                   },
                   () =>
                   {
                       Console.WriteLine("Begin Second Task ...");
                       config.GetMostCommonWords(words);
                   },
                   () =>
                   {
                       Console.WriteLine("Begin Third Task ...");
                       config.GetCountForWord(words, "sleep");
                   }
                );
            Console.WriteLine("Returned From Parallel.Invoke");
            #endregion
        }
    }
}
