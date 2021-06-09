
namespace ResourceWriterTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labId = new System.Windows.Forms.Label();
            this.labPw = new System.Windows.Forms.Label();
            this.btnEn = new System.Windows.Forms.Button();
            this.btnKo = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labId
            // 
            resources.ApplyResources(this.labId, "labId");
            this.labId.Name = "labId";
            // 
            // labPw
            // 
            resources.ApplyResources(this.labPw, "labPw");
            this.labPw.Name = "labPw";
            // 
            // btnEn
            // 
            resources.ApplyResources(this.btnEn, "btnEn");
            this.btnEn.Name = "btnEn";
            this.btnEn.UseVisualStyleBackColor = true;
            this.btnEn.Click += new System.EventHandler(this.btnEn_Click);
            // 
            // btnKo
            // 
            resources.ApplyResources(this.btnKo, "btnKo");
            this.btnKo.Name = "btnKo";
            this.btnKo.UseVisualStyleBackColor = true;
            this.btnKo.Click += new System.EventHandler(this.btnKo_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnKo);
            this.Controls.Add(this.btnEn);
            this.Controls.Add(this.labPw);
            this.Controls.Add(this.labId);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.Label labPw;
        private System.Windows.Forms.Button btnEn;
        private System.Windows.Forms.Button btnKo;
        private System.Windows.Forms.Button button3;
    }
}

