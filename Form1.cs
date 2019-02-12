using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace DailyReports
{
    public partial class Form1 : Form
    {
        DateTime Now;
        DateTime YesterdayOrFriday;
        DateTime Yesterday;
        
        string folderName;
        string Year;
        string YearMonth;
        string folderNamePL;
        string folderNameBOL;
        string dirMain;
        List<List<ProductClassification>> fo;
        List<ProductClassification> Mails;
        List<string> ToOmit;
        List<ProductClassification> CopyTo;
        List<string> Products;
        FoldersOperations ExcelProductsInfo = new FoldersOperations();
        List<ProductClassification> MailsWithAttachment;
        string CopyFolder;
        string fNamePrev, fName, ProductCode;
        string fNameShort = "";

        public Form1()
        {
            fo = ExcelProductsInfo.ReadExcelFile(@"\\fs1ol\Programy$\OL_Raporty\Raporty_DZOK\DodatkoweInformacje_RaportyDzienne.xlsx");
            MailsWithAttachment = fo.ElementAt(0); // list of mails that have attachments and distributors

            //Lists with data
            ToOmit = fo.ElementAt(1).Select(item => item.ProductCode).ToList(); // list of raports to ignore
            CopyTo = fo.ElementAt(2); // information about products target folders
            Mails = fo.ElementAt(3); // list of mails and distributors
            Products = CopyTo.Select(o => o.ProductCode).Distinct().ToList(); //list of products that have pinpointed folders
            Now = DateTime.Now;

            InitializeComponent();

            //default data = now
            dateTimePicker.Text = Now.ToString();
        }


        /// <summary>
        /// Creates folders structure and copies all xlsx and xls files
        /// </summary>
        private void btnCollectData_Click(object sender, EventArgs e)
        {
            Now = Convert.ToDateTime(dateTimePicker.Text);
            //----------------------------- create folders structure --------------------------------------

            dirMain = @"P:\OL_Raporty\Raporty_DZOK\" +  Now.ToString("yyyyMMdd"); 
            Directory.CreateDirectory(dirMain); // create folder for new day
            ExcelProductsInfo.CreateFolders(CopyTo, dirMain); //create folders structure

            //----------------------------- copy all xlsx / xls to main folder ------------------------------------
            Yesterday = Now.AddDays(-1);
            YesterdayOrFriday = (Now.DayOfWeek == DayOfWeek.Monday) ? Now.AddDays(-3) : Yesterday;

            folderName = Now.ToString("yyyyMMdd") + @"\";
            Year = Now.ToString("yyyy") + @"\";
            YearMonth = Now.ToString("yyyyMM") + @"\";
            folderNamePL = YesterdayOrFriday.ToString("yyyyMMdd") + @"\";
            folderNameBOL = Yesterday.ToString("yyyyMMdd") + @"\";

            int countCopied = 0;

            //Defines paths to copy from
            string[] CopyFrom = {
                                @"\\fs1ol\Programy$\Pentalife\Korespondencja\Raporty\" + folderNamePL, // Pentalife
                                @"\\fs1ol\Zasoby$\DWS_DOK_DOR\Raporty\Spektrum_Życia\" + Year + YearMonth + folderName, // SpektrumZycia
                                @"\\fs1ol\Zasoby$\DWS_DOK_DOR\Raporty\Zwrotka\" + Year +  YearMonth + folderName, // Zwrotka
                                @"\\fs1ol\Zasoby$\DWS_DOK_DOR\Raporty\Pomoc_w_Chorobie\" + Year +YearMonth + folderName, //PomocWChorobie
                                @"\\fs1ol\Zasoby$\DWS_DOK_DOR\Raporty\Pod_Kątem_Przyszłości\" + Year + YearMonth + folderName, //Pod Katem Przyszlosci
                                @"\\fs1ol\Zasoby$\DWS_DOK_DOR\Raporty\Dziesiątka\" + Year +YearMonth + folderName, //Dziesiatka
                                @"\\fs1ol\Zasoby$\DWS_DOK_DOR\Raporty\Plan_Pewnej_Ochrony\" + Year+ YearMonth + folderName, //Plan Pewnej Ochrony
                                @"\\fs1ol\Zasoby$\DWS_DOK_DOR\Raporty\Pod_Kątem_Przyszłości\" + Year + YearMonth + folderName, //Plan Na Pewna Przyszlosc
                                @"\\fs1ol\Programy$\OL_Raporty\BOL_PROD\" + folderNameBOL //BOL_PROD
                                };

            IEnumerable<string> dir;

            //copy all the data from folders
            for (int i = 0; i < CopyFrom.Length; i++)
            {
                dir = null;
                CopyFolder = CopyFrom[i];

                //if directory does not exists show messgae box and continue
                try
                {
                    dir = Directory.EnumerateFiles(CopyFolder).OrderBy(f => f);
                }
                catch (DirectoryNotFoundException dirEx)
                {
                    MessageBox.Show(dirEx.Message,"Błąd! Ścieżka nieznaleziona!");
                    continue;
                }

                if (dir != null)
                {
                    //copy files from directory
                    foreach (var file in dir)
                    {
                        fNamePrev = fNameShort;
                        fName = file.Replace(CopyFolder, "");
                        fNameShort = fName.Split('_')[0] + fName.Split('_')[1];
                        ProductCode = fName.Split('_')[0];

                        if (!ToOmit.Any(fName.Contains) && Products.Any(ProductCode.Equals)) //omit some of the files, chose only with specific product code
                        {
                            if (fNamePrev != fNameShort) // checks if product has already been copied
                            {
                                File.Copy(file, dirMain + '\\' + fName, true);
                                countCopied = countCopied + 1;
                            }
                        }
                    }
                }
            }
            label1.Text = "liczba przekopiowanych raportow: " + countCopied;
        }

        /// <summary>
        /// Splits xlsx and xls to folders
        /// </summary>
        private void btnSplitData_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(dirMain);
            string dirFile;
            string fProductCode;
            int countCopied = 0;
            foreach (var file in dir.GetFiles("*.xls*"))
            {
                // find file folder
                fName = file.Name.Replace(dirMain, "");
                fProductCode = fName.Split('_')[0];
                
                var paths = CopyTo.Where(item => item.ProductCode == fProductCode).Select(item => item.Path).Distinct().ToList();

                //path to file
                for (int i = 0; i < paths.Count; i++)
                {
                    dirFile = dirMain + "\\" + paths.ElementAt(i) + "\\" + fName;

                    //if file exists then move
                    if (!File.Exists(dirFile))
                    {
                        Directory.Move(file.FullName, dirFile);
                        countCopied = countCopied + 1;
                    }
                }
            }
            label2.Text = "raporty rozdzielone, rozdzielono " + countCopied + " raportow";
        }


        /// <summary>
        /// Zips folders
        /// </summary>
        private void btnZipData_Click(object sender, EventArgs e)
        {
            int countZiped= 0;
            DirectoryInfo dir = new DirectoryInfo(dirMain+"\\");

            //zip files in folder
            foreach (var file in dir.GetDirectories())
            {
                ZipFile.CreateFromDirectory(dirMain+ "\\"+ file.ToString(), dirMain + "\\" + file.ToString()+".zip");
                countZiped = countZiped + 1;
            }

            label3.Text = "utworzono " + countZiped + " plików zip";
        }

        /// <summary>
        /// Prepares drafts in Outlook
        /// </summary>
        private void btnCreateDrafts_Click(object sender, EventArgs e)
        {
            string MailTo;
            string Template;
            string CC = @"raporty_ol@openlife.pl";

            var mail = new CreateMail();

            //check box for pwc
            if (cbPWC.Checked == false)
            {
                Mails = Mails.Where(x => x.Path.ToLower().Substring(0, 3) != "pwc").ToList();
                MailsWithAttachment= MailsWithAttachment.Where(x => x.Path.ToLower().Substring(0,3) != "pwc").ToList();
            }

            //check box for NDF
            if (cbNDF.Checked == false)
            {
                Mails = Mails.Where(x => x.Path.ToLower().Substring(0, 3) != "ndf").ToList();
                MailsWithAttachment= MailsWithAttachment.Where(x => x.Path.ToLower().Substring(0, 3) != "ndf").ToList();
            }

            for (int i = 0; i < Mails.Count; i++) //drafts without attachments
            {
                MailTo = Mails.ElementAt(i).ProductCode.Split('/')[0];
                Template = Mails.ElementAt(i).ProductCode.Split('/')[1];
                mail.Draft(MailTo, Template, CC);
            }

            for (int i = 0; i < MailsWithAttachment.Count; i++) //drafts with attachments
            {
                MailTo = MailsWithAttachment.ElementAt(i).ProductCode.Split('/')[0];
                Template = MailsWithAttachment.ElementAt(i).ProductCode.Split('/')[1];
                mail.Draft(MailTo, Template, CC, dirMain + "\\" + MailsWithAttachment.ElementAt(i).Path + ".zip");
            }
            label4.Text = "kopie robocze utworzone";

        }
    }
}