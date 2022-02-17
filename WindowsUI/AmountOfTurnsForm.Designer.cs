namespace WindowsUI
{
    partial class AmountOfTurnsForm
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
            this.numOfTurn_btn = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numOfTurn_btn
            // 
            this.numOfTurn_btn.Location = new System.Drawing.Point(38, 10);
            this.numOfTurn_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numOfTurn_btn.Name = "numOfTurn_btn";
            this.numOfTurn_btn.Size = new System.Drawing.Size(224, 24);
            this.numOfTurn_btn.TabIndex = 0;
            this.numOfTurn_btn.Text = "Number of chances: ";
            this.numOfTurn_btn.UseVisualStyleBackColor = true;
            this.numOfTurn_btn.Click += new System.EventHandler(this.AmountOfTurns_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(157, 66);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(105, 28);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // AmountOfTurnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 105);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.numOfTurn_btn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AmountOfTurnsForm";
            this.Text = "AmountOfTurnsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button numOfTurn_btn;
        private System.Windows.Forms.Button btn_Start;
    }
}