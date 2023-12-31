using ChromaSDK;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;

using System.Xml;


using Microsoft.Office.Interop.Excel;

namespace CSharp_SampleApp
{
    class Program
    {


        XmlDocument doc = new XmlDocument();
        XmlTextWriter writer = new XmlTextWriter("file.xml", null);

        //writer.Formatting = Formatting.Indented;
        //writer.WriteStartDocument();
        //writer.WriteStartElement("root");
        //writer.WriteStartElement("element");
        //writer.WriteString("testo");
        //writer.WriteEndElement();
        //writer.WriteEndElement();
        //writer.WriteEndDocument();
        //writer.Close();
        //doc.Save("file.xml");
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
