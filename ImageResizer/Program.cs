using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output");
            List<long> timeli = new List<long>();
            for (int i = 0; i < 8; i++)
            {
                long time = Program.Doit(sourcePath, destinationPath);
                timeli.Add(time);
            }
            Console.WriteLine($"平均花費時間: {timeli.Average()} ms");
        }

        static long Doit(string sourcePath, string destinationPath)
        {
            
            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var tt = imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            tt.Wait();
            sw.Stop();

            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");
            return sw.ElapsedMilliseconds;
        }
    }
}
