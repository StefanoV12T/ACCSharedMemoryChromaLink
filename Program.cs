using ChromaSDK;
using Telemetry_ACC_with_razer_Chroma.Refer;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Telemetry_ACC_with_razer_Chroma
{
    class Program
    {
         
        static void Main(string[] args)
        {
           
            Telemetry telemetry = new Telemetry();
            telemetry.Start();
           
            if (telemetry.GetInitResult() == RazerErrors.RZRESULT_SUCCESS)
            {
                bool supportsStreaming = ChromaAnimationAPI.CoreStreamSupportsStreaming();

                int selectedIndex = 1;

                byte platform = 0;

                telemetry.ExecuteItem(selectedIndex, supportsStreaming, platform);

                Thread.Sleep(1);
            }
            
           




        }
    }
}
