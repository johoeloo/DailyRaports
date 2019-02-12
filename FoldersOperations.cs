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
        public List<List<ProductClassification>> ReadExcelFile(string excelFilePath)
        {
            //create Excel object
            Excel.Application xlApp = new Excel.Application();
            //specified Excel file
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
            
            //pick first worksheet 
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1]; 
            Excel.Range xlRange = xlWorksheet.UsedRange;
            string now = "_" + DateTime.Now.ToString("yyyyMMdd");

            int rowCount;
            int colCount = xlRange.Columns.Count;

            //lists of data
            List<ProductClassification> products = new List<ProductClassification>();
            List<ProductClassification> omit = new List<ProductClassification>();
            List<ProductClassification> mailsWithAttachment = new List<ProductClassification>();
            List<ProductClassification> mails = new List<ProductClassification>();
            List<List<ProductClassification>> folders = new List<List<ProductClassification>>();

            //read Excel data
            for (int j = 1; j <= colCount; j+=2)
            {
                rowCount = xlRange.Cells[1, j].End(Excel.XlDirection.xlDown).Row;
                if (j == colCount -3)
                {
                    for (int i = 2; i <= rowCount; i++)
                        if (xlRange.Cells[i, j + 1].Value == "T")
                            mailsWithAttachment.Add(new ProductClassification {Path = xlRange.Cells[i, j + 2].Value.ToString().Replace("\\",now+ "\\") + now, ProductCode = xlRange.Cells[i, j].Value.ToString() });
                        else
                            mails.Add(new ProductClassification {Path = xlRange.Cells[i, j + 2].Value.ToString().Replace("\\", now + "\\") + now, ProductCode = xlRange.Cells[i, j].Value.ToString() });
                    j = j+1;
                }
                else if (j == colCount)
                {
                    for (int i = 2; i <= rowCount; i++)
                        omit.Add(new ProductClassification { ProductCode = xlRange.Cells[i, j].Value.ToString() });
                }
                else
                {
                    for (int i = 2; i <= rowCount; i++)
                    {
                        if (xlRange.Cells[i, j + 1].Value != "brak produktu")
                            products.Add(new ProductClassification { Path = xlRange.Cells[i, j + 1].Value.ToString().Replace("\\", now + "\\") + now, ProductCode = xlRange.Cells[i, j].Value.ToString() });
                    }
                }
            }
            folders.Add(mailsWithAttachment);
            folders.Add(omit);
            folders.Add(products);
            folders.Add(mails);

            //Close Excel and return data
            xlWorkbook.Close(0);
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            return folders;
        }

        /// <summary>
        /// Creates folders
        /// </summary>
        /// <param name="foldersList">List of folders names</param>
        /// <param name="Path">Path where folders will be craeted</param>
        public void CreateFolders(List<ProductClassification> foldersList, string Path)
        { 
            List<string> listOfFolders = foldersList.Select(o => o.Path).Distinct().ToList();
            string finalPath;

            for (int i = 0; i < listOfFolders.Count; i++)
            {
                finalPath= Path + "\\" + listOfFolders.ElementAt(i);
                Directory.CreateDirectory(finalPath);

            }

        }
    }
}