namespace ocr
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
            this.drawPictureBox = new System.Windows.Forms.PictureBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.makeNetworkButton = new System.Windows.Forms.Button();
            this.trainNetworkButton = new System.Windows.Forms.Button();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.number1Bar = new System.Windows.Forms.ProgressBar();
            this.number2Bar = new System.Windows.Forms.ProgressBar();
            this.number3Bar = new System.Windows.Forms.ProgressBar();
            this.number4Bar = new System.Windows.Forms.ProgressBar();
            this.number5Bar = new System.Windows.Forms.ProgressBar();
            this.number6Bar = new System.Windows.Forms.ProgressBar();
            this.number7Bar = new System.Windows.Forms.ProgressBar();
            this.number8Bar = new System.Windows.Forms.ProgressBar();
            this.number9Bar = new System.Windows.Forms.ProgressBar();
            this.number0Bar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.drawPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // drawPictureBox
            // 
            this.drawPictureBox.Location = new System.Drawing.Point(3, 30);
            this.drawPictureBox.Name = "drawPictureBox";
            this.drawPictureBox.Size = new System.Drawing.Size(222, 272);
            this.drawPictureBox.TabIndex = 0;
            this.drawPictureBox.TabStop = false;
            this.drawPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPictureBox_MouseMove);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(314, 215);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // makeNetworkButton
            // 
            this.makeNetworkButton.Location = new System.Drawing.Point(314, 42);
            this.makeNetworkButton.Name = "makeNetworkButton";
            this.makeNetworkButton.Size = new System.Drawing.Size(75, 23);
            this.makeNetworkButton.TabIndex = 2;
            this.makeNetworkButton.Text = "Tworz";
            this.makeNetworkButton.UseVisualStyleBackColor = true;
            this.makeNetworkButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // trainNetworkButton
            // 
            this.trainNetworkButton.Location = new System.Drawing.Point(314, 71);
            this.trainNetworkButton.Name = "trainNetworkButton";
            this.trainNetworkButton.Size = new System.Drawing.Size(75, 23);
            this.trainNetworkButton.TabIndex = 3;
            this.trainNetworkButton.Text = "Ucz";
            this.trainNetworkButton.UseVisualStyleBackColor = true;
            this.trainNetworkButton.Click += new System.EventHandler(this.trainNetworkButton_Click);
            // 
            // recognizeButton
            // 
            this.recognizeButton.Location = new System.Drawing.Point(314, 164);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(75, 23);
            this.recognizeButton.TabIndex = 4;
            this.recognizeButton.Text = "Sprawdz";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Visible = false;
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rozpoznano liczbe:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(488, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // number1Bar
            // 
            this.number1Bar.Location = new System.Drawing.Point(434, 57);
            this.number1Bar.Name = "number1Bar";
            this.number1Bar.Size = new System.Drawing.Size(100, 23);
            this.number1Bar.Step = 1;
            this.number1Bar.TabIndex = 7;
            // 
            // number2Bar
            // 
            this.number2Bar.Location = new System.Drawing.Point(434, 86);
            this.number2Bar.Name = "number2Bar";
            this.number2Bar.Size = new System.Drawing.Size(100, 23);
            this.number2Bar.TabIndex = 8;
            // 
            // number3Bar
            // 
            this.number3Bar.Location = new System.Drawing.Point(434, 115);
            this.number3Bar.Name = "number3Bar";
            this.number3Bar.Size = new System.Drawing.Size(100, 23);
            this.number3Bar.TabIndex = 9;
            // 
            // number4Bar
            // 
            this.number4Bar.Location = new System.Drawing.Point(434, 144);
            this.number4Bar.Name = "number4Bar";
            this.number4Bar.Size = new System.Drawing.Size(100, 23);
            this.number4Bar.TabIndex = 10;
            // 
            // number5Bar
            // 
            this.number5Bar.Location = new System.Drawing.Point(434, 173);
            this.number5Bar.Name = "number5Bar";
            this.number5Bar.Size = new System.Drawing.Size(100, 23);
            this.number5Bar.TabIndex = 11;
            // 
            // number6Bar
            // 
            this.number6Bar.Location = new System.Drawing.Point(434, 202);
            this.number6Bar.Name = "number6Bar";
            this.number6Bar.Size = new System.Drawing.Size(100, 23);
            this.number6Bar.TabIndex = 12;
            // 
            // number7Bar
            // 
            this.number7Bar.Location = new System.Drawing.Point(434, 231);
            this.number7Bar.Name = "number7Bar";
            this.number7Bar.Size = new System.Drawing.Size(100, 23);
            this.number7Bar.TabIndex = 13;
            // 
            // number8Bar
            // 
            this.number8Bar.Location = new System.Drawing.Point(434, 260);
            this.number8Bar.Name = "number8Bar";
            this.number8Bar.Size = new System.Drawing.Size(100, 23);
            this.number8Bar.TabIndex = 14;
            // 
            // number9Bar
            // 
            this.number9Bar.Location = new System.Drawing.Point(434, 289);
            this.number9Bar.Name = "number9Bar";
            this.number9Bar.Size = new System.Drawing.Size(100, 23);
            this.number9Bar.TabIndex = 15;
            // 
            // number0Bar
            // 
            this.number0Bar.Location = new System.Drawing.Point(434, 30);
            this.number0Bar.Name = "number0Bar";
            this.number0Bar.Size = new System.Drawing.Size(100, 23);
            this.number0Bar.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 512);
            this.Controls.Add(this.number0Bar);
            this.Controls.Add(this.number9Bar);
            this.Controls.Add(this.number8Bar);
            this.Controls.Add(this.number7Bar);
            this.Controls.Add(this.number6Bar);
            this.Controls.Add(this.number5Bar);
            this.Controls.Add(this.number4Bar);
            this.Controls.Add(this.number3Bar);
            this.Controls.Add(this.number2Bar);
            this.Controls.Add(this.number1Bar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recognizeButton);
            this.Controls.Add(this.trainNetworkButton);
            this.Controls.Add(this.makeNetworkButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.drawPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawPictureBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button makeNetworkButton;
        private System.Windows.Forms.Button trainNetworkButton;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar number1Bar;
        private System.Windows.Forms.ProgressBar number2Bar;
        private System.Windows.Forms.ProgressBar number3Bar;
        private System.Windows.Forms.ProgressBar number4Bar;
        private System.Windows.Forms.ProgressBar number5Bar;
        private System.Windows.Forms.ProgressBar number6Bar;
        private System.Windows.Forms.ProgressBar number7Bar;
        private System.Windows.Forms.ProgressBar number8Bar;
        private System.Windows.Forms.ProgressBar number9Bar;
        private System.Windows.Forms.ProgressBar number0Bar;
    }
}

