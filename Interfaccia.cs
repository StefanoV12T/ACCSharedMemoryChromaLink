using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemetry_ACC_with_razer_Chroma;

namespace CSharp_SampleApp
{
    public partial class Interfaccia : Form
    {
        bool Chroma_On = false;
        Telemetry telemetry = new Telemetry();
        public Interfaccia()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
            //this.BackColor = this.button1.BackColor;
            //this.TransparencyKey = this.ACC_Telemetry.BackColor;
        }
        private void Chroma_ON_CheckedChanged(object sender, EventArgs e)
        {
            Chroma_On = true;
        }
        private void ACC_Telemetry_Click(object sender, EventArgs e)
        {
            if (Chroma_On)
            {
                telemetry.ChromaOnTrue();
                telemetry.Chroma_APPINFO();
            }
            telemetry.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
