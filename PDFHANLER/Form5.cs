using iTextSharp.text.pdf.parser;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFHANLER
{
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        private string _pathname;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(textBox1.Text), System.IO.Path.GetFileNameWithoutExtension(textBox1.Text));
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }


            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 1;
            xlWorkSheet.Cells[i, 1] = "S:NO";
            xlWorkSheet.Cells[i, 2] = "PDF";
            
            i++;
            DirectoryInfo dinfo = new DirectoryInfo(textBox1.Text);
            FileInfo[] pdf = dinfo.GetFiles("*.pdf");
            FileInfo[] txt = dinfo.GetFiles("*.txt");
            FileInfo[] xls = dinfo.GetFiles("*.xlsx");
            foreach (FileInfo file in pdf)
            {
                if (file == null) continue;

                xlWorkSheet.Cells[i, 1] = (i - 1).ToString();
                xlWorkSheet.Cells[i, 2] = file.Name.Replace(".pdf", "");
                i++;
            }

            xlWorkSheet.Range["A1", "A" + i].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.Columns.AutoFit();
            xlWorkSheet.Rows.AutoFit();
            xlWorkBook.SaveAs(path+"\\" + ".xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

           TaskDialog.Show("Excel file created ,complete");
        }
    }
}
