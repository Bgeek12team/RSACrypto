namespace Interface
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrivate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxCode = new System.Windows.Forms.TextBox();
            this.txtBoxCoding = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxDecoding = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblOpenKey = new System.Windows.Forms.Label();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbl_Params = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmBxTypes = new System.Windows.Forms.ComboBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.key = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(379, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Проект \"Криптография\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(39, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "Шифруемая строка:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(39, 524);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 41);
            this.label3.TabIndex = 2;
            this.label3.Text = "Открытый ключ:";
            // 
            // btnOpen
            // 
            this.btnOpen.CausesValidation = false;
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpen.Location = new System.Drawing.Point(289, 524);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(154, 44);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Показать";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(799, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 41);
            this.label4.TabIndex = 4;
            this.label4.Text = "Закрытый ключ:";
            // 
            // btnPrivate
            // 
            this.btnPrivate.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrivate.Location = new System.Drawing.Point(1041, 524);
            this.btnPrivate.Name = "btnPrivate";
            this.btnPrivate.Size = new System.Drawing.Size(154, 44);
            this.btnPrivate.TabIndex = 5;
            this.btnPrivate.Text = "Показать";
            this.btnPrivate.UseVisualStyleBackColor = true;
            this.btnPrivate.Click += new System.EventHandler(this.btnPrivate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(39, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 35);
            this.label5.TabIndex = 6;
            this.label5.Text = "Зашифрованное сообщение";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtBoxCode
            // 
            this.txtBoxCode.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBoxCode.Location = new System.Drawing.Point(330, 128);
            this.txtBoxCode.Multiline = true;
            this.txtBoxCode.Name = "txtBoxCode";
            this.txtBoxCode.Size = new System.Drawing.Size(865, 47);
            this.txtBoxCode.TabIndex = 7;
            this.txtBoxCode.TextChanged += new System.EventHandler(this.txtBoxCode_TextChanged);
            // 
            // txtBoxCoding
            // 
            this.txtBoxCoding.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBoxCoding.Location = new System.Drawing.Point(39, 353);
            this.txtBoxCoding.Multiline = true;
            this.txtBoxCoding.Name = "txtBoxCoding";
            this.txtBoxCoding.ReadOnly = true;
            this.txtBoxCoding.Size = new System.Drawing.Size(404, 153);
            this.txtBoxCoding.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(799, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 35);
            this.label6.TabIndex = 9;
            this.label6.Text = "Расшифрованное сообщение";
            // 
            // txtBoxDecoding
            // 
            this.txtBoxDecoding.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBoxDecoding.Location = new System.Drawing.Point(799, 353);
            this.txtBoxDecoding.Multiline = true;
            this.txtBoxDecoding.Name = "txtBoxDecoding";
            this.txtBoxDecoding.ReadOnly = true;
            this.txtBoxDecoding.Size = new System.Drawing.Size(396, 153);
            this.txtBoxDecoding.TabIndex = 10;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDecrypt.Location = new System.Drawing.Point(493, 353);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(260, 44);
            this.btnDecrypt.TabIndex = 12;
            this.btnDecrypt.Text = "Расшифровать";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblOpenKey
            // 
            this.lblOpenKey.AutoSize = true;
            this.lblOpenKey.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOpenKey.Location = new System.Drawing.Point(39, 575);
            this.lblOpenKey.Name = "lblOpenKey";
            this.lblOpenKey.Size = new System.Drawing.Size(0, 41);
            this.lblOpenKey.TabIndex = 13;
            this.lblOpenKey.Visible = false;
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrivateKey.Location = new System.Drawing.Point(799, 565);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(0, 41);
            this.lblPrivateKey.TabIndex = 14;
            this.lblPrivateKey.Visible = false;
            this.lblPrivateKey.Click += new System.EventHandler(this.lblPrivateKey_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbl_Params
            // 
            this.lbl_Params.AutoSize = true;
            this.lbl_Params.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Params.Location = new System.Drawing.Point(493, 527);
            this.lbl_Params.Name = "lbl_Params";
            this.lbl_Params.Size = new System.Drawing.Size(34, 28);
            this.lbl_Params.TabIndex = 16;
            this.lbl_Params.Text = "lbl";
            this.lbl_Params.Visible = false;
            // 
            // button1
            // 
            this.button1.CausesValidation = false;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(493, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 103);
            this.button1.TabIndex = 15;
            this.button1.Text = "Показать параметры шифрования";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.Location = new System.Drawing.Point(1140, 25);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(60, 58);
            this.btnInfo.TabIndex = 17;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEncrypt.Location = new System.Drawing.Point(858, 202);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(337, 47);
            this.btnEncrypt.TabIndex = 20;
            this.btnEncrypt.Text = "Зашифровать";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(39, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 41);
            this.label7.TabIndex = 18;
            this.label7.Text = "Вид шифрования:";
            // 
            // cmBxTypes
            // 
            this.cmBxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxTypes.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmBxTypes.FormattingEnabled = true;
            this.cmBxTypes.Items.AddRange(new object[] {
            "RSA ассиметричное",
            "Шифр Цезаря",
            "Шифрование перестановками"});
            this.cmBxTypes.Location = new System.Drawing.Point(330, 202);
            this.cmBxTypes.Name = "cmBxTypes";
            this.cmBxTypes.Size = new System.Drawing.Size(522, 45);
            this.cmBxTypes.TabIndex = 21;
            this.cmBxTypes.SelectedIndexChanged += new System.EventHandler(this.cmBxTypes_SelectedIndexChanged);
            this.cmBxTypes.TextChanged += new System.EventHandler(this.cmBxTypes_TextChanged);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKey.Location = new System.Drawing.Point(493, 305);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(89, 31);
            this.lblKey.TabIndex = 22;
            this.lblKey.Text = "Отступ:";
            this.lblKey.Visible = false;
            // 
            // key
            // 
            this.key.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.key.Location = new System.Drawing.Point(588, 305);
            this.key.Multiline = true;
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(165, 31);
            this.key.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1263, 717);
            this.Controls.Add(this.key);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.cmBxTypes);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.lbl_Params);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.lblOpenKey);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.txtBoxDecoding);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxCoding);
            this.Controls.Add(this.txtBoxCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPrivate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSA";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnOpen;
        private Label label4;
        private Button btnPrivate;
        private Label label5;
        private TextBox txtBoxCode;
        private TextBox txtBoxCoding;
        private Label label6;
        private TextBox txtBoxDecoding;
        private Button btnDecrypt;
        private Label lblOpenKey;
        private Label lblPrivateKey;
        private ErrorProvider errorProvider1;
        private Label lbl_Params;
        private Button button1;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private Button btnInfo;
        private ComboBox cmBxTypes;
        private Button btnEncrypt;
        private Label label7;
        private Label lblKey;
        private TextBox key;
    }
}