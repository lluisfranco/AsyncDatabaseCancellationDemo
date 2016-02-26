namespace AsyncDatabaseCancellationDemo
{
    partial class Form1
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
            this.customersList = new System.Windows.Forms.ListBox();
            this.customerIdLabel = new System.Windows.Forms.Label();
            this.customerAmountLabel = new System.Windows.Forms.Label();
            this.requestsListBox = new System.Windows.Forms.ListBox();
            this.clearListLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // customersList
            // 
            this.customersList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.customersList.FormattingEnabled = true;
            this.customersList.IntegralHeight = false;
            this.customersList.Location = new System.Drawing.Point(13, 13);
            this.customersList.Name = "customersList";
            this.customersList.Size = new System.Drawing.Size(331, 238);
            this.customersList.TabIndex = 0;
            // 
            // customerIdLabel
            // 
            this.customerIdLabel.AutoSize = true;
            this.customerIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerIdLabel.Location = new System.Drawing.Point(361, 13);
            this.customerIdLabel.Name = "customerIdLabel";
            this.customerIdLabel.Size = new System.Drawing.Size(42, 26);
            this.customerIdLabel.TabIndex = 1;
            this.customerIdLabel.Text = "#Id";
            // 
            // customerAmountLabel
            // 
            this.customerAmountLabel.AutoSize = true;
            this.customerAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerAmountLabel.Location = new System.Drawing.Point(361, 53);
            this.customerAmountLabel.Name = "customerAmountLabel";
            this.customerAmountLabel.Size = new System.Drawing.Size(100, 26);
            this.customerAmountLabel.TabIndex = 2;
            this.customerAmountLabel.Text = "#Amount";
            // 
            // requestsListBox
            // 
            this.requestsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requestsListBox.BackColor = System.Drawing.SystemColors.Control;
            this.requestsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.requestsListBox.FormattingEnabled = true;
            this.requestsListBox.IntegralHeight = false;
            this.requestsListBox.Location = new System.Drawing.Point(366, 104);
            this.requestsListBox.Name = "requestsListBox";
            this.requestsListBox.Size = new System.Drawing.Size(352, 147);
            this.requestsListBox.TabIndex = 3;
            // 
            // clearListLinkLabel
            // 
            this.clearListLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearListLinkLabel.AutoSize = true;
            this.clearListLinkLabel.Location = new System.Drawing.Point(688, 88);
            this.clearListLinkLabel.Name = "clearListLinkLabel";
            this.clearListLinkLabel.Size = new System.Drawing.Size(30, 13);
            this.clearListLinkLabel.TabIndex = 4;
            this.clearListLinkLabel.TabStop = true;
            this.clearListLinkLabel.Text = "clear";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 261);
            this.Controls.Add(this.clearListLinkLabel);
            this.Controls.Add(this.requestsListBox);
            this.Controls.Add(this.customerAmountLabel);
            this.Controls.Add(this.customerIdLabel);
            this.Controls.Add(this.customersList);
            this.Name = "Form1";
            this.Text = "Customers Amount Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox customersList;
        private System.Windows.Forms.Label customerIdLabel;
        private System.Windows.Forms.Label customerAmountLabel;
        private System.Windows.Forms.ListBox requestsListBox;
        private System.Windows.Forms.LinkLabel clearListLinkLabel;
    }
}

