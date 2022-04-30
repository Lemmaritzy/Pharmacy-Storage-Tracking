using System.ComponentModel;

namespace Pharmacy_Storage_Tracking.forms
{
    partial class ilacsil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.deletetext = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "id";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // deletetext
            // 
            this.deletetext.Location = new System.Drawing.Point(90, 25);
            this.deletetext.Mask = "00000";
            this.deletetext.Name = "deletetext";
            this.deletetext.Size = new System.Drawing.Size(80, 38);
            this.deletetext.TabIndex = 20;
            this.deletetext.ValidatingType = typeof(int);
            // 
            // ilacsil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 139);
            this.Controls.Add(this.deletetext);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (162)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ilacsil";
            this.ShowIcon = false;
            this.Text = "İlaç Sil";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MaskedTextBox deletetext;

        //private System.Windows.Forms.MaskedTextBox textBox1;

        //private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;

        #endregion
    }
}