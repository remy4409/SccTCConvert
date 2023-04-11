namespace SccTCConvert
{
    partial class Form1
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
            label1 = new Label();
            OpenSCC_BTN = new Button();
            btn_23to29 = new Button();
            CB_baseTC = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(313, 35);
            label1.Name = "label1";
            label1.Size = new Size(93, 37);
            label1.TabIndex = 3;
            label1.Text = "Base TC";
            label1.UseMnemonic = false;
            // 
            // OpenSCC_BTN
            // 
            OpenSCC_BTN.Location = new Point(26, 35);
            OpenSCC_BTN.Name = "OpenSCC_BTN";
            OpenSCC_BTN.Size = new Size(127, 47);
            OpenSCC_BTN.TabIndex = 5;
            OpenSCC_BTN.Text = "OpenSCC";
            OpenSCC_BTN.UseVisualStyleBackColor = true;
            OpenSCC_BTN.Click += OpenSCC_BTN_Click;
            // 
            // btn_23to29
            // 
            btn_23to29.Location = new Point(26, 110);
            btn_23to29.Name = "btn_23to29";
            btn_23to29.Size = new Size(171, 60);
            btn_23to29.TabIndex = 7;
            btn_23to29.Text = "Convert 29.94 to 23.98 and save to SCC";
            btn_23to29.UseVisualStyleBackColor = true;
            btn_23to29.Click += btn_23to29_Click;
            // 
            // CB_baseTC
            // 
            CB_baseTC.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_baseTC.FormattingEnabled = true;
            CB_baseTC.Items.AddRange(new object[] { "00:00:00:00", "01:00:00:00", "02:00:00:00", "03:00:00:00", "04:00:00:00", "05:00:00:00", "06:00:00:00", "07:00:00:00", "08:00:00:00", "09:00:00:00", "10:00:00:00", "11:00:00:00", "12:00:00:00" });
            CB_baseTC.Location = new Point(313, 63);
            CB_baseTC.MaxDropDownItems = 12;
            CB_baseTC.Name = "CB_baseTC";
            CB_baseTC.Size = new Size(151, 28);
            CB_baseTC.TabIndex = 11;
            CB_baseTC.SelectedIndexChanged += CB_baseTC_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 189);
            Controls.Add(CB_baseTC);
            Controls.Add(btn_23to29);
            Controls.Add(OpenSCC_BTN);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_23to29;
        private Button button2;
        private Label label1;
        private Button button3;
        private Button OpenScc;
        private Button OpenSCC_BTN;
        private ComboBox CB_baseTC;
    }
}