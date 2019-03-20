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
using System.Reflection;

namespace DailyReports
{
    public partial class Form1 : Form
    {
        DateTime Now;

        string folderName;
        string Year;
        string MonthPl;
        string dirMain;
        List<List<ProductClassification>> fo;
        List<List<string>> fo2;
        List<ProductClassification> Mails;
        List<ProductClassification> CopyTo;
        List<string> Products;
        List<string> EncryptionZip;

        List<string> ProductsWithPiToOmit;
        List<string> ProductsProv;
        FoldersOperations ExcelProductsInfo = new FoldersOperations();
        List<ProductClassification> MailsWithAttachment;
        string CopyFolder;
        string fNamePrev, fName;

        public Form1()
        {
            Now = DateTime.Now;

            InitializeComponent();

            //default data = now
            dateTimePicker.Text = Now.ToString();
            dateTimePicker.CustomFormat = "d MMMM yyyy";
        }


        /// <summary>
        /// Creates folders structure and copies all xlsx and xls files
        /// </summary>
        private void btnCollectData_Click(object sender, EventArgs e)
        {
            Now = Convert.ToDateTime(dateTimePicker.Text);
            int step = 0;
            lblProductType.Text = "Tworzenie struktury folderów...";
            Refresh();

            Year = Now.ToString("yyyy");
            PrepareData pd = new PrepareData();
            MonthPl = pd.month_pl(Now);
            int countCopied = 0;
            int lp = Now.Month + Now.Year - 2019;

            fo = ExcelProductsInfo.ReadExcelFile(@"\\fs1ol\Programy$\OL_Raporty\Raporty_DZOK\DodatkoweInformacje_RaportyMiesieczne.xlsx", Now.ToString("yyyyMM"));

            //Lists with data
            MailsWithAttachment = fo.ElementAt(0); // list of mails that have attachments and distributors
            CopyTo = fo.ElementAt(1); // information about products target folders
            Mails = fo.ElementAt(2); // list of mails and distributors
            Products = CopyTo.Select(o => o.ProductCode).Distinct().ToList(); //list of products that have pinpointed folders


            fo2 = ExcelProductsInfo.ReadCommissionRestriction(@"C:\Users\jmajcher\Desktop\Miesieczne_DOK\DodatkoweInformacje_RaportyMiesieczne.xlsx", Now.ToString("yyyyMM"));
            ProductsWithPiToOmit = fo2.ElementAt(0); //products code where is no need to clear personal data
            ProductsProv = fo2.ElementAt(1); // products name where personal data needs to be removed

            EncryptionZip = ExcelProductsInfo.ReadCEncryptionFolders(@"C:\Users\jmajcher\Desktop\Miesieczne_DOK\DodatkoweInformacje_RaportyMiesieczne.xlsx", Now.ToString("yyyyMM"));

            //----------------------------- create folders structure --------------------------------------

            dirMain = @"P:\OL_Raporty\Raporty_DZOK\RAPORTY MIESIĘCZNE\"+ lp + "." + MonthPl + " " + Year + "\\Prowizje_wysyłka_" + Now.ToString("yyyyMM");
            Directory.CreateDirectory(dirMain); // create folder for new day
            ExcelProductsInfo.CreateFolders(CopyTo, dirMain); //create folders structure


            //----------------------------- copy all xlsx / xls to main folder ------------------------------------


            //Defines paths to copy from
            string[] CopyFrom = {
                                @"P:\OL_Raporty\Raporty_DZOK\RAPORTY MIESIĘCZNE\" + lp + "." + MonthPl + " " + Year + @"\Ochronne\",
                                //@"P:\OL_Raporty\Raporty_DZOK\RAPORTY MIESIĘCZNE\" + lp + "." + MonthPl + " " + Year + @"\Inwestycyjne\",
                                @"P:\OL_Raporty\Rejestrator\" + Now.ToString("yyyyMMdd"),
                                };

            IEnumerable<string> dir;
            bool PersonalInfo;

            progressBar1.Visible = true;
            Refresh();

            //copy all the data from folders
            for (int i = 0; i < CopyFrom.Length; i++)
            {
                dir = null;
                CopyFolder = CopyFrom[i];
                
                //check if folder needs to be cleared from personal infromation
                PersonalInfo = false;
                if (CopyFolder.Contains("Inwestycyjne") == true)
                {
                    PersonalInfo = true;
                }

                //if directory does not exists show messgae box and continue
                try
                {
                    dir = Directory.EnumerateFiles(CopyFolder).OrderBy(f => f);
                }
                catch (DirectoryNotFoundException dirEx)
                {
                    MessageBox.Show(dirEx.Message,"Błąd! Ścieżka " + CopyFrom[i] + " nieznaleziona!");
                    continue;
                }

                //information for user (on the Form)
                if (dir != null)
                {
                    if (CopyFolder.Contains("Inwestycyjne") == true)
                        lblProductType.Text = "Inwestycyjne";
                    else if (CopyFolder.Contains("Rejestrator") == true)
                        lblProductType.Text = "Rejestrator";
                    else
                        lblProductType.Text = "Ochronne";
                    Refresh();

                    progressBar1.Value = 0;
                    progressBar1.Maximum = dir.Count();
                    progressBar1.Minimum = 0;
                    progressBar1.Step = 1;

                    //copy files from directory
                    foreach (var file in dir)
                    {
                        fNamePrev = fName;
                        fName = file.Replace(CopyFolder, "");

                        if (fNamePrev != fName ) // checks if product has already been copied
                        {
                            File.Copy(file, dirMain + '\\' + fName, true);
                            countCopied = countCopied + 1;

                            //remove personal infrormation
                            if (PersonalInfo == true && !ProductsWithPiToOmit.Any(fName.Contains))
                            {
                                pd.RemovePersonalData(dirMain + '\\' + fName, fo2.ElementAt(2));
                            }
                        }
                        step += 1;
                        progressBar1.PerformStep();
                        Refresh();
                    }
                }
            }
            progressBar1.Visible = false;
            lblProductType.Text = "";
            label1.Text = "liczba przekopiowanych raportow: " + countCopied;
            Refresh();
        }

        /// <summary>
        /// Splits files to folders
        /// </summary>
        private void btnSplitData_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(dirMain);
            string dirFile;
            int countCopied = 0;
            List<string> paths = new List<string>();

            foreach (var file in dir.GetFiles())
            {
                // find file folder
                fName = file.Name.Replace(dirMain, "");

                foreach (var item in CopyTo)
                {
                    if (fName.Contains(item.ProductCode))
                    {
                        paths.Add(item.Path);
                    }
                }

                //path to file
                for (int i = 0; i < paths.Count; i++)
                {
                    dirFile = dirMain + "\\" + paths.ElementAt(i) + "\\" + fName;

                    //if file exists then move
                    if (!File.Exists(dirFile) && File.Exists(file.FullName))
                    {
                        Directory.Move(file.FullName, dirFile);
                        countCopied = countCopied + 1;
                    }
                }
                paths.Clear();
            }

            label2.Text = "raporty rozdzielone, rozdzielono " + countCopied + " raportow";
        }

        /// <summary>
        /// Creates txt files with lists of folders in directory
        /// </summary>
        private void btnListsOfFiles_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(dirMain + "\\");
            DirectoryInfo subDir;
            string[] subfolders = Directory.GetDirectories(dir.ToString());
            string str = "";
            int countCopied = 0;

            // find all subfolders in directory
            foreach (var directory in subfolders)
            {
                str = "";
                subDir = new DirectoryInfo(directory);

                //read files names in subfolder
                foreach (FileInfo raport in subDir.GetFiles())
                {
                    str = str + raport + ", ";
                }

                if (str.Length == 0)
                {
                    str = "brak plikow   ";
                }

                //create txt file with files list
                str = "Lista plikow: " + str.Substring(0, str.Length - 2);
                File.WriteAllText(subDir +  ".txt", str);
                countCopied = countCopied + 1;
            }
            label5.Text = "listy plikow wygenerowane, storzono " + countCopied + " list txt";
        }


        /// <summary>
        /// Zips folders
        /// </summary>
        private void btnZipData_Click(object sender, EventArgs e)
        {
            int countZiped= 0;
            DirectoryInfo dir = new DirectoryInfo(dirMain+"\\");

            //use seven zip library to create zips with password
            SevenZip.SevenZipBase.SetLibraryPath((Assembly.GetEntryAssembly().Location).Replace(Assembly.GetEntryAssembly().FullName.Split(',')[0] + ".exe", "7za.dll"));
            SevenZip.SevenZipCompressor compressor = new SevenZip.SevenZipCompressor();

            string password = MonthPl.Substring(0, 1).ToUpper() + MonthPl.Substring(1, MonthPl.Length-1).ToLower() + Year.Substring(2,2) + "_OL";
            string destinationFile = "";
            string[] sourceFiles;

            //zip files in folder
            foreach (var file in dir.GetDirectories())
            {
                destinationFile = dirMain +"\\" + file.ToString() + ".zip";
                sourceFiles = Directory.GetFiles(dirMain + "\\" + file.ToString());

                try
                {
                    //if file on EncryptionZip list, create zip with password
                    if (EncryptionZip.Any(destinationFile.Contains))
                    {
                       
                        compressor.EncryptHeaders = true;
                        compressor.CompressFilesEncrypted(destinationFile, password, sourceFiles);
                    }
                    else
                    {
                        compressor.CompressFiles(destinationFile, sourceFiles);

                    }
                    countZiped = countZiped + 1;
                }
                catch (ArgumentOutOfRangeException dirEx)
                {
                    MessageBox.Show("Folder " + dirMain + "\\" + file.ToString() + " jest pusty!" + "\n" + "\n" + "Nie został swtorzony zip dla tego folderu! "+ "\n" + "\n" +"\n" + "("+dirEx +")" , "Błąd! indeks poza zakresem");
                    continue;
                }
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


            for (int i = 0; i < Mails.Count; i++) //drafts without attachments
            {
                MailTo = Mails.ElementAt(i).ProductCode.Split('/')[0];
                Template = Mails.ElementAt(i).ProductCode.Split('/')[1];
                mail.Draft(MailTo, Template, CC, MonthPl + " " + Year);
            }

            for (int i = 0; i < MailsWithAttachment.Count; i++) //drafts with attachments
            {
                MailTo = MailsWithAttachment.ElementAt(i).ProductCode.Split('/')[0];
                Template = MailsWithAttachment.ElementAt(i).ProductCode.Split('/')[1];
                mail.Draft(MailTo, Template, CC, MonthPl+ " " + Year, dirMain + "\\" + MailsWithAttachment.ElementAt(i).Path + ".zip");
            }
            label4.Text = "kopie robocze utworzone";

        }
    }
}