namespace BK_Driver
{
    partial class BK_Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Cmd_Open = new System.Windows.Forms.Button();
            this.Cmd_Close = new System.Windows.Forms.Button();
            this.Cmd_Exit = new System.Windows.Forms.Button();
            this.Cmd_Write = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRead = new System.Windows.Forms.TextBox();
            this.Cmd_Read = new System.Windows.Forms.Button();
            this.Cmd_ONOFF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(276, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Cmd_Open
            // 
            this.Cmd_Open.Enabled = false;
            this.Cmd_Open.Location = new System.Drawing.Point(12, 52);
            this.Cmd_Open.Name = "Cmd_Open";
            this.Cmd_Open.Size = new System.Drawing.Size(107, 42);
            this.Cmd_Open.TabIndex = 2;
            this.Cmd_Open.Text = "Open";
            this.Cmd_Open.UseVisualStyleBackColor = true;
            this.Cmd_Open.Click += new System.EventHandler(this.Cmd_Open_Click);
            // 
            // Cmd_Close
            // 
            this.Cmd_Close.Enabled = false;
            this.Cmd_Close.Location = new System.Drawing.Point(181, 52);
            this.Cmd_Close.Name = "Cmd_Close";
            this.Cmd_Close.Size = new System.Drawing.Size(107, 42);
            this.Cmd_Close.TabIndex = 3;
            this.Cmd_Close.Text = "Close";
            this.Cmd_Close.UseVisualStyleBackColor = true;
            this.Cmd_Close.Click += new System.EventHandler(this.Cmd_Close_Click);
            // 
            // Cmd_Exit
            // 
            this.Cmd_Exit.Location = new System.Drawing.Point(321, 380);
            this.Cmd_Exit.Name = "Cmd_Exit";
            this.Cmd_Exit.Size = new System.Drawing.Size(97, 42);
            this.Cmd_Exit.TabIndex = 4;
            this.Cmd_Exit.Text = "Exit";
            this.Cmd_Exit.UseVisualStyleBackColor = true;
            this.Cmd_Exit.Click += new System.EventHandler(this.Cmd_Exit_Click);
            // 
            // Cmd_Write
            // 
            this.Cmd_Write.Enabled = false;
            this.Cmd_Write.Location = new System.Drawing.Point(181, 136);
            this.Cmd_Write.Name = "Cmd_Write";
            this.Cmd_Write.Size = new System.Drawing.Size(107, 42);
            this.Cmd_Write.TabIndex = 5;
            this.Cmd_Write.Text = "Write";
            this.Cmd_Write.UseVisualStyleBackColor = true;
            this.Cmd_Write.Click += new System.EventHandler(this.Cmd_Write_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Write:";
            // 
            // txtSend
            // 
            this.txtSend.Enabled = false;
            this.txtSend.Location = new System.Drawing.Point(53, 148);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(122, 20);
            this.txtSend.TabIndex = 7;
            this.txtSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSend_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Read:";
            // 
            // txtRead
            // 
            this.txtRead.Enabled = false;
            this.txtRead.Location = new System.Drawing.Point(15, 206);
            this.txtRead.Multiline = true;
            this.txtRead.Name = "txtRead";
            this.txtRead.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRead.Size = new System.Drawing.Size(273, 168);
            this.txtRead.TabIndex = 9;
            // 
            // Cmd_Read
            // 
            this.Cmd_Read.Enabled = false;
            this.Cmd_Read.Location = new System.Drawing.Point(181, 380);
            this.Cmd_Read.Name = "Cmd_Read";
            this.Cmd_Read.Size = new System.Drawing.Size(107, 42);
            this.Cmd_Read.TabIndex = 10;
            this.Cmd_Read.Text = "Read";
            this.Cmd_Read.UseVisualStyleBackColor = true;
            this.Cmd_Read.Click += new System.EventHandler(this.Cmd_Read_Click);
            // 
            // Cmd_ONOFF
            // 
            this.Cmd_ONOFF.Enabled = false;
            this.Cmd_ONOFF.Location = new System.Drawing.Point(311, 136);
            this.Cmd_ONOFF.Name = "Cmd_ONOFF";
            this.Cmd_ONOFF.Size = new System.Drawing.Size(107, 42);
            this.Cmd_ONOFF.TabIndex = 11;
            this.Cmd_ONOFF.Text = "ON";
            this.Cmd_ONOFF.UseVisualStyleBackColor = true;
            this.Cmd_ONOFF.Click += new System.EventHandler(this.Cmd_ONOFF_Click);
            // 
            // BK_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 431);
            this.Controls.Add(this.Cmd_ONOFF);
            this.Controls.Add(this.Cmd_Read);
            this.Controls.Add(this.txtRead);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cmd_Write);
            this.Controls.Add(this.Cmd_Exit);
            this.Controls.Add(this.Cmd_Close);
            this.Controls.Add(this.Cmd_Open);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "BK_Main";
            this.Text = "BK Driver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Cmd_Open;
        private System.Windows.Forms.Button Cmd_Close;
        private System.Windows.Forms.Button Cmd_Exit;
        private System.Windows.Forms.Button Cmd_Write;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRead;
        private System.Windows.Forms.Button Cmd_Read;
        private System.Windows.Forms.Button Cmd_ONOFF;
    }
}

