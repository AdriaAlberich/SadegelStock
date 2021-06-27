namespace SadegelStock
{
    partial class TextInput
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnInput = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(5, 5);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(361, 20);
            this.txtInput.TabIndex = 0;
            // 
            // btnInput
            // 
            this.btnInput.AccessibleName = "Button";
            this.btnInput.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnInput.Location = new System.Drawing.Point(5, 30);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(361, 28);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "Acceptar";
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // TextInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 63);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TextInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private Syncfusion.WinForms.Controls.SfButton btnInput;
    }
}