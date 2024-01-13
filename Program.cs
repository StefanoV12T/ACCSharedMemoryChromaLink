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
            bool Chroma_On=true;
            Telemetry telemetry = new Telemetry();
            
            if (Chroma_On)
                {
                telemetry.ChromaOnTrue();
                telemetry.Chroma_APPINFO();
                }
            telemetry.Start();
        }
    }
}
