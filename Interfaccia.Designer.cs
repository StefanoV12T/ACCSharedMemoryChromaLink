namespace CSharp_SampleApp
{
    partial class Interfaccia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interfaccia));
            this.Chroma_ON = new System.Windows.Forms.CheckBox();
            this.ACC_Telemetry = new System.Windows.Forms.Button();
            this.ImageBackGround = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // Chroma_ON
            // 
            this.Chroma_ON.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.Chroma_ON, "Chroma_ON");
            this.Chroma_ON.Name = "Chroma_ON";
            this.Chroma_ON.UseVisualStyleBackColor = false;
            this.Chroma_ON.CheckedChanged += new System.EventHandler(this.Chroma_ON_CheckedChanged);
            // 
            // ACC_Telemetry
            // 
            this.ACC_Telemetry.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACC_Telemetry.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.ACC_Telemetry, "ACC_Telemetry");
            this.ACC_Telemetry.Name = "ACC_Telemetry";
            this.ACC_Telemetry.UseVisualStyleBackColor = false;
            this.ACC_Telemetry.Click += new System.EventHandler(this.ACC_Telemetry_Click);
            // 
            // ImageBackGround
            // 
            resources.ApplyResources(this.ImageBackGround, "ImageBackGround");
            this.ImageBackGround.Name = "ImageBackGround";
            this.ImageBackGround.TabStop = false;
            // 
            // Interfaccia
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.Controls.Add(this.Chroma_ON);
            this.Controls.Add(this.ACC_Telemetry);
            this.Controls.Add(this.ImageBackGround);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "Interfaccia";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.ImageBackGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox Chroma_ON;
        private System.Windows.Forms.Button ACC_Telemetry;
        private System.Windows.Forms.PictureBox ImageBackGround;
    }
}