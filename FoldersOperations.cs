using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace DailyReports
{
    class FoldersOperations
    {
        /// <summary>
        /// Reads specific excel file.
        /// </summary>
        /// <param name="excelFilePath">Excel file path</param>
        /// <returns>
        /// lists of objects (objects consist columns)
        /// </returns>
        public List<List<ProductClassification>> ReadExcelFile(string excelFilePath, string date)
        {
            //create Excel object
            Excel.Application xlApp = new Excel.Application();
            //specified Excel file
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
            
            //pick first worksheet 
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1]; 
            Excel.Range xlRange = xlWorksheet.UsedRange;
            string now = "_" + date;

            int rowCount;
            int colCount = xlRange.Columns.Count;

            //lists of data
            List<ProductClassification> products = new List<ProductClassification>();
            List<ProductClassification> mailsWithAttachment = new List<ProductClassification>();
            List<ProductClassification> mails = new List<ProductClassification>();
            List<List<ProductClassification>> folders = new List<List<ProductClassification>>();

            //read Excel data
            for (int j = 1; j <= colCount; j++)
            {
                rowCount = xlRange.Cells[1, 1].End(Excel.XlDirection.xlDown).Row;
                if (j == 3)
                {
                    for (int i = 2; i <= rowCount; i++)
                        if (xlRange.Cells[i, j + 1].Value == "T" && xlRange.Cells[i, j].Value !=null)
                            mailsWithAttachment.Add(new ProductClassification {Path = xlRange.Cells[i, j - 1].Value.ToString().Split('\\')[0].Replace("\\",now+ "\\") + now, ProductCode = xlRange.Cells[i, j].Value.ToString() });
                        else if (xlRange.Cells[i, j].Value != null)
                            mails.Add(new ProductClassification {Path = xlRange.Cells[i, j -1].Value.ToString().Split('\\')[0].Replace("\\", now + "\\") + now, ProductCode = xlRange.Cells[i, j].Value.ToString() });
                    j = j+1;
                }
                else if (j==1)
                {
                        for (int i = 2; i <= rowCount; i++)
                        {
                            if (xlRange.Cells[i, j + 1].Value != "brak produktu")
                                products.Add(new ProductClassification { Path = xlRange.Cells[i, j + 1].Value.ToString().Replace("\\", now + "\\") + now, ProductCode = xlRange.Cells[i, j].Value.ToString() });
                        }
                }
            }
            folders.Add(mailsWithAttachment.Where(m => m.ProductCode != "").GroupBy(e => e.Path).Select(group => group.First()).ToList());
            folders.Add(products);
            folders.Add(mails.Where(m => m.ProductCode != "").GroupBy(e => e.Path).Select(group => group.First()).ToList());

            //Close Excel and return data
            xlWorkbook.Close(0);
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            return folders;
        }


        public List<List<string>> ReadCommissionRestriction(string excelFilePath, string date)
        {
            //create Excel object
            Excel.Application xlApp = new Excel.Application();
            //specified Excel file
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);

            //pick first worksheet 
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[2];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            string now = "_" + date;

            int rowCount;

            //lists of data
            List<string> unchanged = new List<string>();
            List<string> code = new List<string>();
            List<string> columnsToClear = new List<string>();
            List<List<string>> folders = new List<List<string>>();

            //read Excel data
            rowCount = xlRange.Cells[1, 1].End(Excel.XlDirection.xlDown).Row;
            for (int i = 2; i <= rowCount; i++)
                unchanged.Add( xlRange.Cells[i, 1].Value.ToString());

            rowCount = xlRange.Cells[1, 2].End(Excel.XlDirection.xlDown).Row;
            for (int i = 2; i <= rowCount; i++)
                code.Add(xlRange.Cells[i, 2].Value.ToString());

            rowCount = xlRange.Cells[1, 3].End(Excel.XlDirection.xlDown).Row;
            for (int i = 2; i <= rowCount; i++)
                columnsToClear.Add(xlRange.Cells[i, 3].Value.ToString());

            folders.Add(unchanged);
            folders.Add(code);
            folders.Add(columnsToClear);

            //Close Excel and return data
            xlWorkbook.Close(0);
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            return folders;
        }


        public List<string> ReadCEncryptionFolders(string excelFilePath, string date)
        {
            //create Excel object
            Excel.Application xlApp = new Excel.Application();
            //specified Excel file
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);

            //pick first worksheet 
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[3];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            string now = "_" + date;

            int rowCount;

            //lists of data
            List<string> encryptionFolders = new List<string>();


            //read Excel data
            rowCount = xlRange.Cells[1, 1].End(Excel.XlDirection.xlDown).Row;
            for (int i = 2; i <= rowCount; i++)
                encryptionFolders.Add(xlRange.Cells[i, 1].Value.ToString());

            //Close Excel and return data
            xlWorkbook.Close(0);
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            return encryptionFolders;
        }

        /// <summary>
        /// Creates folders
        ///// </summary>
        /// <param name="foldersList">List of folders names</param>
        /// <param name="Path">Path where folders will be craeted</param>
        public void CreateFolders(List<ProductClassification> foldersList, string Path)
        { 
            //remove duplicates from list of folders
            List<string> listOfFolders = foldersList.Select(o => o.Path).Distinct().ToList();
            string finalPath;

            //create directories
            for (int i = 0; i < listOfFolders.Count; i++)
            {
                finalPath= Path + "\\" + listOfFolders.ElementAt(i);
                Directory.CreateDirectory(finalPath);

            }

        }
    }
}