using ChromaSDK;
using Telemetry_ACC_with_razer_Chroma.Refer;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SampleApp;

namespace Telemetry_ACC_with_razer_Chroma
{
    class Program
    {      
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Interfaccia());
        }
    }
}
