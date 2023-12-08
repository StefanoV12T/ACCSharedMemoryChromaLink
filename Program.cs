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

        static void Main(string[] args)
        {
            SampleApp sampleApp = new SampleApp();
            sampleApp.Start();
           
            if (sampleApp.GetInitResult() == RazerErrors.RZRESULT_SUCCESS)
            {
                bool supportsStreaming = ChromaAnimationAPI.CoreStreamSupportsStreaming();

                int selectedIndex = 1;

                byte platform = 0;

                sampleApp.ExecuteItem(selectedIndex, supportsStreaming, platform);

                Thread.Sleep(1);                
            }            
        }
    }
}
