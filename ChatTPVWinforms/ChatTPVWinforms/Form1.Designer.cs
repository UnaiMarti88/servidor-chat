namespace ChatTPVWinforms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer osagaiak = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (osagaiak != null))
            {
                osagaiak.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Diseinatzaileak sortutako kodea

        private void InitializeComponent()
        {
            this.lstMezuak = new System.Windows.Forms.ListBox();
            this.txtMezuak = new System.Windows.Forms.TextBox();
            this.btnBidali = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMezuak
            // 
            this.lstMezuak.FormattingEnabled = true;
            this.lstMezuak.ItemHeight = 16;
            this.lstMezuak.Location = new System.Drawing.Point(12, 12);
            this.lstMezuak.Name = "lstMezuak";
            this.lstMezuak.Size = new System.Drawing.Size(560, 260);
            this.lstMezuak.TabIndex = 0;
            // 
            // txtMezuak
            // 
            this.txtMezuak.Location = new System.Drawing.Point(12, 280);
            this.txtMezuak.Name = "txtMezuak";
            this.txtMezuak.Size = new System.Drawing.Size(460, 22);
            this.txtMezuak.TabIndex = 1;
            // 
            // btnBidali
            // 
            this.btnBidali.Location = new System.Drawing.Point(480, 279);
            this.btnBidali.Name = "btnBidali";
            this.btnBidali.Size = new System.Drawing.Size(92, 23);
            this.btnBidali.TabIndex = 2;
            this.btnBidali.Text = "Bidali";
            this.btnBidali.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 321);
            this.Controls.Add(this.btnBidali);
            this.Controls.Add(this.txtMezuak);
            this.Controls.Add(this.lstMezuak);
            this.Name = "Form1";
            this.Text = "TPV Txat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMezuak;
        private System.Windows.Forms.TextBox txtMezuak;
        private System.Windows.Forms.Button btnBidali;
    }
}
