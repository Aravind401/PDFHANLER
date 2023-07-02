using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.ComponentModel;
using PDFHANLER;

namespace PdfMergdelete
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private readonly List<string> pdflist = new List<string>();
        private string _pathname;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                richTextBox1.Text = string.Empty;
                richTextBox2.Text = string.Empty;
                List<string> myList = DirSearch(textBox1.Text, null, "*.pdf");
                PdfReader reader = null;
                Document sourceDocument = null;
                PdfCopy pdfCopyProvider = null;
                string[] lstFiles = myList.ToArray();
                if (lstFiles.Count() == 1) return;
                PdfImportedPage importedPage;
                var path = Path.Combine(Path.GetDirectoryName(textBox1.Text), Path.GetFileNameWithoutExtension(textBox1.Text));
                sourceDocument = new Document();
                DirectoryInfo parentDir = Directory.GetParent(path.EndsWith("\\") ? path : string.Concat(path, "\\"));
                try
                {
                    if (File.Exists(parentDir + "\\" + textBox4.Text + ".pdf"))
                    {
                        TaskDialog.Show("", "File name already Exist");
                        return;

                    }
                    else
                    {
                        pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(parentDir + "\\" + textBox4.Text + ".pdf", System.IO.FileMode.Create));

                        sourceDocument.Open();
                    }

                }
                catch (Exception ex) { }

                int sum = 0;
                int a = 0;
                int pages = 0;
                for (int f = 0; f < lstFiles.Length; f++)
                {

                    pages = get_pageCount(lstFiles[f]);
                    if (pages < 0) continue;
                    a = 0;
                   
                    reader = new PdfReader(lstFiles[f]);
                    
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }
                    a = Convert.ToInt32(pages);
                    sum += a;
                    
                    reader.Close();
                }

                richTextBox1.Text += sum;
                richTextBox2.Text += myList.Count();

                pdfCopyProvider.Close();
                sourceDocument.Close();
                pdflist.Clear();
                TaskDialog.Show("", "Completed");
                myList.Clear();
            }
            catch (Exception ex)
            { TaskDialog.Show("", "No Folder Selected "+ex); }



        }

        internal void RemoveOwnedForm()
        {
            throw new NotImplementedException();
        }

        private int Add(string sum, int pages)
        {
            int total;
            total = sum.Length + pages;
            return total;
        }


        private List<string> DirSearch(string dir, string rootDir = null, string sMatch = ".pdf", List<string> lstFilesFound = default(List<string>))
        {
            if (rootDir == null)
                rootDir = dir;
            if (lstFilesFound == null)
                lstFilesFound = new List<string>();
            try
            {
                foreach (string f in Directory.GetFiles(dir, sMatch))
                {
                    string filename = f.Substring(rootDir.Length);
                    lstFilesFound.Add(f);
                    Console.WriteLine(filename);
                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    Console.WriteLine(d);
                    DirSearch(d, rootDir, sMatch, lstFilesFound);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lstFilesFound;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = string.Empty;
                richTextBox2.Text = string.Empty;
                PdfReader reader = null;
                Document sourceDocument = null;
                PdfCopy pdfCopyProvider = null;
                string[] lstFiles = pdflist.ToArray();
                if (lstFiles.Count() == 1) return;
                PdfImportedPage importedPage;
                var path = Path.Combine(Path.GetDirectoryName(textBox2.Text), Path.GetFileNameWithoutExtension(textBox2.Text));
                //var path = Path.Combine(txtPDFFILE.Text.Trim('\\'), Path.GetFileNameWithoutExtension(txtPDFFILE.Text));                
                sourceDocument = new Document();
                DirectoryInfo parentDir = Directory.GetParent(path.EndsWith("\\") ? path : string.Concat(path, "\\"));
                var myParentDir = parentDir.Parent.FullName;
                try
                {
                    if (File.Exists(myParentDir + "\\" + textBox4.Text + ".pdf"))
                    {
                        TaskDialog.Show("", "File name already Exist");
                        return;

                    }
                    else
                    {
                        pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(myParentDir + "\\" + textBox4.Text + ".pdf", System.IO.FileMode.Create));
                        sourceDocument.Open();
                    }
                }
                catch (Exception ex) { }

                int sum = 0;
                int a = 0;
                int pages = 0;
                for (int f = 0; f < lstFiles.Length; f++)
                {

                    pages = get_pageCount(lstFiles[f]);
                    if (pages < 0) continue;
                    a = 0;
                   
                    reader = new PdfReader(lstFiles[f]);
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }
                    a = Convert.ToInt32(pages);
                    sum += a;
                    //var val  = sum+ pages;
                    reader.Close();
                }
                richTextBox1.Text += sum;
                richTextBox2.Text += pdflist.Count();
                sourceDocument.Close();
                pdfCopyProvider.Close();
                pdflist.Clear();
                TaskDialog.Show("", "Completed");
            }
            catch (Exception ex)
            { TaskDialog.Show("", "No File Selected  "+ex); }
        }
        private int get_pageCount(string file)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(file)))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());
                return matches.Count;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = string.Empty;
                richTextBox2.Text = string.Empty;
                int a = 0;
                string intval = string.Empty;
                string delval = string.Empty;
                var path = Path.Combine(Path.GetDirectoryName(textBox3.Text), Path.GetFileNameWithoutExtension(textBox3.Text));
                string sourceFile = textBox3.Text;
                List<string> pageval = new List<string>();
                PdfReader reader = new PdfReader(textBox3.Text);
                int sum = 0;
                var vn = 0;
                var n = 0;
                int page;
                foreach (var sn in textBox.Text.Split(',', '.'))
                {
                    vn = Convert.ToInt32(sn);
                    pageval.Add(vn.ToString());
                }
                for (page = 1; page <= reader.NumberOfPages; page++)
                {
                    n = Convert.ToInt32(page);

                    if (!pageval.Contains(n.ToString()))
                    {
                        intval = intval + page + ",";
                        a = Convert.ToInt32(page);
                    }
                }
                if (page <= vn)
                {
                    TaskDialog.Show("", "Pdf page count will be " + n + " and you typed number " + vn);
                    return;
                }

                try
                {
                    var X = Convert.ToInt32(pageval.Count());
                    sum += n - X;

                    richTextBox2.Text += "1";
                    reader.SelectPages(intval);
                    DirectoryInfo parentDir = Directory.GetParent(path.EndsWith("\\") ? path : string.Concat(path, "\\"));
                    // The result is available here
                    var myParentDir = parentDir.Parent.FullName;
                    try
                    {
                        if (File.Exists(myParentDir + "\\" + textBox4.Text + ".pdf"))
                        {
                            TaskDialog.Show("", "File name already Exist");
                            return;

                        }
                        else
                        {
                            PdfStamper stamper = new PdfStamper(reader, new FileStream(myParentDir + "\\" + textBox4.Text + ".pdf", FileMode.Create));
                            stamper.Close();
                        }
                    }
                    catch (Exception ex) { }
                    richTextBox1.Text += sum;

                    reader.Close();
                    TaskDialog.Show("", "completed");
                }
                catch (Exception ex) { TaskDialog.Show("", "File Name Already Existed"); }


            }
            catch (Exception ex) { TaskDialog.Show("", "No File Selected"+ex); }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_Click(object sender, EventArgs e)
        {

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                PDFHANLER.Form2 frm = new PDFHANLER.Form2();
                frm.ShowDialog();
            }


            if (checkBox1.Checked == true)
            {
                TaskDialog.Show("contact to aravindhannew@gmail.com", "Applicaton develoed by Aravindhan");
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {
            TaskDialog.Show("", "Enter the Differnt FILE NAME in same Folder");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void A_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {


        }

        private void label1_Clic(object sender, EventArgs e)
        {

        }

        private void label1_Clicks(object sender, EventArgs e)
        {

        }

        private void textbutton5(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            richTextBox2.Text = string.Empty;

            try
            {
                if (textBox6.Text == null && (textBox7.Text == null))
                {
                    TaskDialog.Show("", "Start Page and end page cannot not empty");
                    return;
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("", "Start Page and end page cannot not empty");
                return;
            }

            try
            {

                int startpage = Convert.ToInt32(textBox6.Text);
                int endpage = Convert.ToInt32(textBox7.Text);

                PdfReader reader = null;
                Document sourceDocument = null;
                PdfCopy pdfCopyProvider = null;
                PdfImportedPage importedPage = null;
                var path = Path.Combine(Path.GetDirectoryName(textbox65.Text), Path.GetFileNameWithoutExtension(textbox65.Text));
                DirectoryInfo parentDir = Directory.GetParent(path.EndsWith("\\") ? path : string.Concat(path, "\\"));
                // The result is available here
                var myParentDir = parentDir.Parent.FullName;
                reader = new PdfReader(textbox65.Text);
                int pages = get_pageCount(textbox65.Text);
                sourceDocument = new Document(reader.GetPageSizeWithRotation(startpage));
                try
                {
                    if (File.Exists(myParentDir + "\\" + textBox4.Text + ".pdf"))
                    {
                        TaskDialog.Show("", "File name already Exist");
                        return;

                    }
                    if (endpage > pages)
                    {
                        TaskDialog.Show("", "There are " + pages + " pages in the pdf");
                        return;
                    }
                    if (startpage >= endpage)
                    {
                        TaskDialog.Show("", "Check the page Number"); return;
                    }


                    else
                    {
                        pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(myParentDir + "\\" + textBox4.Text + ".pdf", System.IO.FileMode.Create));
                        sourceDocument.Open();
                    }

                }
                catch (Exception ex) { }
                int count = 0;
                for (int i = startpage; i <= endpage; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                    count = count + 1;
                }
                sourceDocument.Close();
                reader.Close();
                richTextBox2.Text += "1";
                richTextBox1.Text = count.ToString();
                TaskDialog.Show("", "Completed");
            }
            catch (Exception ex) { TaskDialog.Show("", "No File selected"); }


        }




        private void SElFiles(object sender, EventArgs e)
        {

        }

        private void DeletePDF(object sender, EventArgs e)
        {

        }

        private void pdfsplitter(object sender, EventArgs e)
        {

        }

        private void Seldir(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBox1.Text = dialog.FileName;
                _pathname = dialog.FileName;
                textBox1.Text = _pathname;
            }
        }

        private void Selec(object sender, EventArgs e)
        {

        }

        private void smpflder(object sender, EventArgs e)
        {

        }

        private void selfile(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog();
                od.Filter = "XLS files|*.pdf";
                od.Multiselect = true;
                string tb_path = null;
                if (od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string tempFolder = System.IO.Path.GetTempPath();

                    foreach (string fileName in od.FileNames)
                    {
                        //File.Copy(fileName, tempFolder + @"\" + Path.GetFileName(fileName));
                        pdflist.Add(fileName);
                    }
                    tb_path = od.FileName;
                    textBox2.Text = tb_path;
                }
            }
            catch (Exception ex) { throw new Exception("check the input file"); }
        }

        private void DelFile(object sender, EventArgs e)
        {
            string tb_path = null;
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.Filter = "Excel Files | *.pdf; *.pdf; *.pdf";
            openfiledialog1.Multiselect = false;
            Cursor.Current = Cursors.WaitCursor;
            if (openfiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb_path = openfiledialog1.FileName;
            }
            textBox3.Text = tb_path;
        }

        private void pdfSpli(object sender, EventArgs e)
        {
            string tb_path = null;
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.Filter = "Excel Files | *.pdf; *.pdf; *.pdf";
            openfiledialog1.Multiselect = false;
            Cursor.Current = Cursors.WaitCursor;
            if (openfiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb_path = openfiledialog1.FileName;
            }
            textbox65.Text = tb_path;
        }

        private void Multisplit(object sender, EventArgs e)
        {
                        
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form5 FRM = new Form5();
            FRM.Show();
        }
    }

       
}

