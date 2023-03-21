namespace RemoveFiles
{
    partial class CSP
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
            this.txtOut = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtCSPText = new System.Windows.Forms.TextBox();
            this.btnShowCSP = new System.Windows.Forms.Button();
            this.btnCSPText = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(154, 270);
            this.txtOut.Margin = new System.Windows.Forms.Padding(4);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOut.Size = new System.Drawing.Size(831, 239);
            this.txtOut.TabIndex = 4;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(154, 13);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(831, 239);
            this.txtInput.TabIndex = 3;
            // 
            // txtCSPText
            // 
            this.txtCSPText.Location = new System.Drawing.Point(154, 527);
            this.txtCSPText.Margin = new System.Windows.Forms.Padding(4);
            this.txtCSPText.Multiline = true;
            this.txtCSPText.Name = "txtCSPText";
            this.txtCSPText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCSPText.Size = new System.Drawing.Size(831, 239);
            this.txtCSPText.TabIndex = 5;
            // 
            // btnShowCSP
            // 
            this.btnShowCSP.Location = new System.Drawing.Point(30, 270);
            this.btnShowCSP.Name = "btnShowCSP";
            this.btnShowCSP.Size = new System.Drawing.Size(75, 23);
            this.btnShowCSP.TabIndex = 6;
            this.btnShowCSP.Text = "CSP";
            this.btnShowCSP.UseVisualStyleBackColor = true;
            this.btnShowCSP.Click += new System.EventHandler(this.btnShowCSP_Click);
            // 
            // btnCSPText
            // 
            this.btnCSPText.Location = new System.Drawing.Point(30, 527);
            this.btnCSPText.Name = "btnCSPText";
            this.btnCSPText.Size = new System.Drawing.Size(75, 23);
            this.btnCSPText.TabIndex = 7;
            this.btnCSPText.Text = "CSPText";
            this.btnCSPText.UseVisualStyleBackColor = true;
            this.btnCSPText.Click += new System.EventHandler(this.btnCSPText_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(30, 13);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 8;
            this.btnClearAll.Text = "btnClearAll";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // CSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 765);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnCSPText);
            this.Controls.Add(this.btnShowCSP);
            this.Controls.Add(this.txtCSPText);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.txtInput);
            this.Name = "CSP";
            this.Text = "CSP";
            this.Load += new System.EventHandler(this.CSP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtCSPText;
        private System.Windows.Forms.Button btnShowCSP;
        private System.Windows.Forms.Button btnCSPText;
        private System.Windows.Forms.Button btnClearAll;
    }
}