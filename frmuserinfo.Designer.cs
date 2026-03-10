namespace projet19dvld
{
    partial class frmuserinfo
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
            this.ctrlusercard1 = new projet19dvld.ctrlusercard();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlusercard1
            // 
            this.ctrlusercard1.Location = new System.Drawing.Point(8, 8);
            this.ctrlusercard1.Name = "ctrlusercard1";
            this.ctrlusercard1.Size = new System.Drawing.Size(886, 465);
            this.ctrlusercard1.TabIndex = 0;
            this.ctrlusercard1.Load += new System.EventHandler(this.Ctrlusercard1_Load);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::projet19dvld.Properties.Resources.cross_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(768, 512);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // frmuserinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 584);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlusercard1);
            this.Name = "frmuserinfo";
            this.Text = "frmuserinfo";
            this.Load += new System.EventHandler(this.Frmuserinfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlusercard ctrlusercard1;
        private System.Windows.Forms.Button btnClose;
    }
}