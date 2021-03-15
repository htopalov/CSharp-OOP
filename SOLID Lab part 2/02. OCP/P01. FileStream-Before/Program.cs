using System;
using System.Threading;

namespace P01._FileStream_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            ISentable file = new File();
            ISentable music = new Music();
            Progress fileProgress = new Progress(file);
            Progress musicProgress = new Progress(music);
            file.Length = 500;
            music.Length = 500;
            while (file.Length > file.Sent)
            {
                file.Sent += 10;
                music.Sent += 10;
                Console.WriteLine($"{fileProgress.CurrentPercent()} % file sent");
                Console.WriteLine($"{musicProgress.CurrentPercent()} % music sent");
                Thread.Sleep(600);
            }

           
            
        }
    }
}
