
using PdfMergdelete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace PDFHANLER
{
    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            FileStream text = null;
            DateTime dt1 = DateTime.Now;
            DateTime dt = DateTime.Parse(dt1.ToString());

            if (dt1.Date > dt.Date)
            {
                try {
                    if (!File.Exists(@"E:\smpl.txt"))
                    {

                        text = new FileStream(@"E:\smpl.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    }

                    TextWriter tw = new StreamWriter(text);
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.Close();
                    Form3 frm = new Form3();
                    frm.ShowDialog();
                }
                catch(Exception ex)
                {
                    if (!File.Exists(@"d:\smpl.txt"))
                    {

                        text = new FileStream(@"d:\smpl.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    }

                    TextWriter tw = new StreamWriter(text);
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("@#$%%^&*()_QWERTYUIOP{ASDFGHJKL:ASDFGHJKL:QWERTYUIOP");
                    tw.WriteLine("asdfghjkl;'qwertyuiop[zxcvbnm,.qwertyuiop[scvbnmqwertyui");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.WriteLine("1234567890-=1234567890-12345678901234567890-23456789912345");
                    tw.Close();
                    Form3 frm = new Form3();
                    frm.ShowDialog();

                }

                



            }


            else
            {
                string readText = string.Empty;
                if (File.Exists(@"E:\smpl.txt") || File.Exists(@"d:\smpl.txt"))
                {
                    Form3 frm = new Form3();
                    frm.ShowDialog();
                }

                else
                {

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());

                }
            }

        }
    }
}
