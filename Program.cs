using ChromaSDK;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;

namespace CSharp_SampleApp
{
    class Program
    {

        const int MAX_ITEMS = 1;

        static void PrintLegend(SampleApp app, int selectedIndex, bool supportsStreaming, byte platform)
        {


            Console.WriteLine("C# CHROMA SAMPLE APP");
            Console.WriteLine("Use `UP` and `DOWN` arrows to select an animation and press `ENTER` to execute.");
            if (supportsStreaming)
            {
                Console.Write("Use `P` to switch streaming platforms. ");
            }
            Console.WriteLine("Use `ESC` to QUIT.");

            int startIndex = 1;

            for (int index = startIndex; index <= MAX_ITEMS; ++index)
            {
                if (index == selectedIndex)
                {
                    Console.Write("[*] ");
                }
                else
                {
                    Console.Write("[ ] ");
                }
                Console.Write("{0, 8}", app.GetEffectName(index, platform));

                if (index > 0)
                {
                    if ((index % 4) == 0)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("\t\t");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press ENTER to play selection.");
        }

        static void Main(string[] args)
        {
            SampleApp sampleApp = new SampleApp();
            sampleApp.Start();
           
            if (sampleApp.GetInitResult() == RazerErrors.RZRESULT_SUCCESS)
            {
                int startIndex = 1;

                bool supportsStreaming = ChromaAnimationAPI.CoreStreamSupportsStreaming();



                int selectedIndex = 1;

                byte platform = 0;

                DateTime inputTimer = DateTime.MinValue;

                while (true)
                {
                    if (inputTimer < DateTime.Now)
                    {
                        Console.Clear();
                        PrintLegend(sampleApp, selectedIndex, supportsStreaming, platform);
                        inputTimer = DateTime.Now + TimeSpan.FromMilliseconds(100);
                    }
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (selectedIndex > startIndex)
                        {
                            --selectedIndex;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (selectedIndex < MAX_ITEMS)
                        {
                            ++selectedIndex;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (keyInfo.Key == ConsoleKey.P)
                    {
                        platform = (byte)((platform + 1) % 4); //PC, AMAZON LUNA, MS GAME PASS, NVIDIA GFN
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        
                        sampleApp.ExecuteItem(selectedIndex, supportsStreaming, platform);
                    }
                    Thread.Sleep(1);
                }

                sampleApp.OnApplicationQuit();

            }

            Console.WriteLine("{0}", "C# Chroma Sample App [EXIT]");
            
        }
    }
}
