namespace A_EstrellaV2
{
    partial class UIAlgoritmo
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
            lbResponse = new Label();
            SuspendLayout();
            // 
            // lbResponse
            // 
            lbResponse.AutoSize = true;
            lbResponse.Location = new Point(268, 56);
            lbResponse.Name = "lbResponse";
            lbResponse.Size = new Size(38, 15);
            lbResponse.TabIndex = 0;
            lbResponse.Text = "label1";
            // 
            // UIAlgoritmo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbResponse);
            Name = "UIAlgoritmo";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbResponse;
    }
}
