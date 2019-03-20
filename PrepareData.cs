using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace DailyReports
{
    class PrepareData
    {
        /// <summary>
        /// Returns name of polish month in given date
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns></returns>
        public string month_pl(DateTime date)
        {
            if (date.Month ==1)
            {
                return "Styczeń";
            }
            else if (date.Month==2)
            {
                return "Luty";
            }
            else if (date.Month == 3)
            {
                return "Marzec";
                    }
            else if (date.Month == 4)
            {
                return "Kwiecień";
            }
            else if (date.Month == 5)
            {
                return "Maj";
            }
            else if (date.Month == 6)
            {
                return "Czerwiec";
            }
            else if (date.Month == 7)
            {
                return "Lipiec";
            }
            else if (date.Month == 8)
            {
                return "Sierpień";
            }
            else if (date.Month == 9)
            {
                return "Wrzesień";
            }
            else if (date.Month == 10)
            {
                return "Październik";
            }
            else if (date.Month == 11)
            {
                return "Listopad";
            }
            else if (date.Month == 12)
            {
                return "Grudzień";
            }
            else
            {
                return "niepoprawna data";
            }
        }

        /// <summary>
        /// Removes personal data from given Excel
        /// </summary>
        /// <param name="path">Path to Excel file</param>
        /// <param name="restrictions">List of columns to remove from Excel file</param>
        public void RemovePersonalData(string path, List<string> restrictions)
        {
            List<string> ColumnsToClear;

            //names of columns in Excel that shoud be cleared
            ColumnsToClear = restrictions;

            //create Excel object
            Excel.Application xlApp = new Excel.Application();
            //do not display warnings
            xlApp.DisplayAlerts = false;
            //specified Excel file
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);

            //pick worksheet 
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            Excel.Range xlRangeToClear;

            int rowStart=1;

            //find first row (headers)
            for (int i = 1; i < 5; i++)
            {
                if (xlRange.Cells[i, "D"].Value != "")
                {
                    rowStart = i; //header
                    break;
                }
            }

            int colCount = xlRange.Columns.Count;
            
            for (int j = 1; j <= colCount; j++)
            {
                foreach (var item in ColumnsToClear)
                {
                    if (xlRange.Cells[rowStart, j + 1].Value != null)
                    {
                        //find specific column defined in restrictions
                        if (xlRange.Cells[rowStart, j + 1].Value.ToString().Contains(item))
                        {
                            Excel.Range c1 = xlWorksheet.Cells[Type.Missing, j + 1];
                            Excel.Range c2 = xlWorksheet.Cells[Type.Missing, j + 1];

                            //clear values
                            xlRangeToClear = xlWorksheet.get_Range(c1, c2);
                            xlRangeToClear.EntireColumn.ClearContents();
                            xlWorksheet.Cells[rowStart, j + 1].Value = item;
                        }
                    }
                }
            }
            xlWorkbook.Save();
            xlWorkbook.Close();
            //activate warnings
            xlApp.DisplayAlerts = true;
            xlApp.Quit();
        }

    }
}
