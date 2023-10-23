using RSACrypto;

namespace Interface
{
    public partial class Form1 : Form
    {

        CryptoProcessRSA cp;
        CryptoProcessCaesar cpc;
        CryptoProcessTransposition cpt;
        MyBigInteger keyVal = new(-1);
        public enum CYPHER_TYPES { RSA, CESAURUS, INSERTION}
        public CYPHER_TYPES DefineType()
        {
            if (cmBxTypes == null)
                return CYPHER_TYPES.RSA;

            if (cmBxTypes.Text == "RSA ассиметричное")
            {
                key.Visible = false;
                lblKey.Visible = false;
                return CYPHER_TYPES.RSA;
            }

            if (cmBxTypes.Text == "Шифр Цезаря")
            {
                key.Visible = true;
                lblKey.Visible = true;
                lblKey.Text = "Отступ";
                return CYPHER_TYPES.CESAURUS;
            }

            if (cmBxTypes.Text == "Шифрование перестановками")
            {
                key.Visible = true;
                lblKey.Visible = true;
                lblKey.Text = "Ключ";
                return CYPHER_TYPES.INSERTION;
            }
            return CYPHER_TYPES.RSA;
        }
        public bool GetOffset()
        {
            try
            {
                this.keyVal = MyBigInteger.Parse(key.Text);
                return true;
            } catch
            {
                errorProvider1.SetError(key, "Некорректный ввод!");
                return false;
            }
        }
        public void GetKey()
        {
            errorProvider1.Clear();
            try
            {
                bool uniqConseq = true;
                int maxC = 0;
                for (int i = 0; i < key.Text.Length; i++)
                {
                    char cur = key.Text[i];
                    maxC = Math.Max(maxC, int.Parse(cur.ToString()));

                    int count = 0;
                    for (int j = 0; j < key.Text.Length; j++)
                    {
                        if (key.Text[j] == key.Text[i])
                            count++;
                    }
                    uniqConseq = count == 1;
                    if (!uniqConseq)
                        throw new Exception();
                }
                if (maxC > key.Text.Length)
                {
                    throw new Exception();
                }    

                this.keyVal = MyBigInteger.Parse(key.Text);
            }
            catch
            {
                keyVal = new(-1);

                errorProvider1.SetError(key, "Некорректный ввод!");
                return;
            }
        }
        public void ChangeStateKeys(bool visible)
        {
            label3.Visible = visible;
            label4.Visible = visible;
            btnOpen.Visible = visible;
            btnPrivate.Visible = visible;
            lblOpenKey.Visible = visible;
            lblPrivateKey.Visible = visible;
        }
        
        public Form1()
        {
            InitializeComponent();
            cmBxTypes.SelectedIndex = 0;
            if (txtBoxCode.Text.Length == 0)
            {
                btnOpen.Enabled = false;
                btnPrivate.Enabled = false;
                button1.Enabled = false;
                
            }
        }

        private void btnEncrypt_Click_1(object sender, EventArgs e)
        {

            txtBoxCoding.Text = "";
            txtBoxDecoding.Text = "";
            if (DefineType() == CYPHER_TYPES.RSA)
            {
                ChangeStateKeys(true);
                lblOpenKey.Visible = false;
                lblPrivateKey.Visible = false;
                if (txtBoxCode.Text.Length != 0)
                {
                    cp = new CryptoProcessRSA(txtBoxCode.Text);
                    txtBoxCoding.Text = cp.showEncrypt();
                    if (btnPrivate.Enabled)
                        lblPrivateKey.Text = cp.showPrivateKey();
                    if (btnOpen.Enabled)
                        lblOpenKey.Text = cp.showPublicKey();
                    lbl_Params.Text = cp.showKeyGen();
                    button1.Enabled = true;
                    btnOpen.Enabled = true;
                    btnPrivate.Enabled = true;
                }
                else
                    errorProvider1.SetError(btnEncrypt, "Вы не ввели шифр!");
            }
            else if (DefineType() == CYPHER_TYPES.CESAURUS)
            {
                ChangeStateKeys(false);
                if (GetOffset())
                {
                    cpc = new CryptoProcessCaesar(txtBoxCode.Text, keyVal);
                    txtBoxCoding.Text = cpc.showEncrypt();
                    lbl_Params.Text = "offset: " + cpc.showOffset();
                    lbl_Params.Visible = false;
                    button1.Enabled = true;
                }
            }
            else
            {
                ChangeStateKeys(false);
                GetKey();
                if (keyVal == -1)
                {
                    return;
                }
                cpt = new CryptoProcessTransposition(txtBoxCode.Text, keyVal.ToString());
                txtBoxCoding.Text = cpt.showEncrypt();
                lbl_Params.Text = "encryption key: " + cpt.showEncKey()
                    + ";\n decryption key: " + cpt.showDecKey();
                lbl_Params.Visible = false;
                button1.Enabled = true;
            }
            

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cp != null)
            {
                if (DefineType() == CYPHER_TYPES.RSA)
                {
                    ChangeStateKeys(true);
                    lblOpenKey.Text = cp.showPublicKey();
                    lblOpenKey.Visible = true;
                    btnOpen.Visible = false;
                }
                else if (DefineType() == CYPHER_TYPES.CESAURUS)
                {
                    ChangeStateKeys(false);
                }
                else 
                {
                    ChangeStateKeys(false);
                }
            }
        }

        private void btnPrivate_Click(object sender, EventArgs e)
        {
            if (cp != null)
            {
                lblPrivateKey.Text = cp.showPrivateKey();
                lblPrivateKey.Visible = true;
                btnPrivate.Visible = false;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (DefineType() == CYPHER_TYPES.RSA)
            {
                ChangeStateKeys(true);
                if (txtBoxCode.Text.Length != 0 && cp != null)
                    txtBoxDecoding.Text = cp.showDecrypt();
                else
                    errorProvider1.SetError(btnDecrypt, "Вы не ввели шифр!");
            }
            else if (DefineType() == CYPHER_TYPES.CESAURUS)
            {
                ChangeStateKeys(false);
                if (txtBoxCode.Text.Length != 0 && cpc != null)
                    txtBoxDecoding.Text = cpc.showDecrypt();
                else
                    errorProvider1.SetError(btnDecrypt, "Вы не ввели шифр!");
            }
            else
            {
                ChangeStateKeys(false);
                if (txtBoxCode.Text.Length != 0 && cpt != null)
                    txtBoxDecoding.Text = cpt.showDecrypt();
                else
                    errorProvider1.SetError(btnDecrypt, "Вы не ввели шифр!");
            }

        }

        private void txtBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (DefineType() == CYPHER_TYPES.RSA)
            {
                ChangeStateKeys(true);
            }
            else if (DefineType() == CYPHER_TYPES.CESAURUS)
            {
                ChangeStateKeys(false);
            }
            else
            {
                ChangeStateKeys(false);
            }
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DefineType() == CYPHER_TYPES.RSA)
            {
                ChangeStateKeys(true);
                if (cp != null)
                {

                    lbl_Params.Text = cp.showKeyGen();
                    lbl_Params.Visible = true;
                }
            }
            else if (DefineType() == CYPHER_TYPES.CESAURUS)
            {
                ChangeStateKeys(false);
                if (cpc != null)
                {
                    lbl_Params.Visible = true;
                }
            }
            else
            {
                ChangeStateKeys(false);
                if (cpt != null)
                {
                    lbl_Params.Visible = true;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblPrivateKey_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnOpen, "Открытый ключ для шифрования.");
            toolTip2.SetToolTip(btnPrivate, "Приватный ключ для шифрования.");
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm();
            infoForm.ShowDialog();
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {

        }

        private void cmBxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxCoding.Text = "";
            txtBoxDecoding.Text = "";
            lbl_Params.Text = "";
            if (DefineType() == CYPHER_TYPES.RSA)
            {
                ChangeStateKeys(true);
            }
            else if (DefineType() == CYPHER_TYPES.CESAURUS)
            {
                ChangeStateKeys(false);
            }
            else
            {
                ChangeStateKeys(false);
            }
        }

        private void cmBxTypes_TextChanged(object sender, EventArgs e)
        {
            return;
        }
    }
}