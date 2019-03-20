using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
namespace DailyReports
{
    class CreateMail
    {
        /// <summary>
        /// create mail
        /// </summary>
        /// <param name="to">Mail receiver</param>
        /// <param name="template">Mail template</param>
        /// <param name="cc">Mail cc</param>
        /// <param name="from">Sender name</param>
        /// <param name="logPath">Path of the attachments</param>
        public void Draft(string to, string template, string cc, string subjectDate,  string logPath="")
        {
            //create Outlook object
            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItemFromTemplate(@"\\fs1ol\Programy$\OL_Raporty\Raporty_DZOK\Szablony miesięczne\" + template +".oft"); //template path

            mailItem.To = to;
            mailItem.CC = cc;

            //replace text in subject and in body
            mailItem.Subject = mailItem.Subject.Replace("tu_wstaw_datę", subjectDate);
            mailItem.HTMLBody = mailItem.HTMLBody.Replace("tu_wstaw_datę", subjectDate);
            

            if (logPath != "")
            {
                //if attachemnt does not exists go to next mail (add zip and txt file)
                try
                {
                    mailItem.Attachments.Add(logPath);
                    mailItem.Attachments.Add(logPath.Replace(".zip",".txt"));
                }
                catch
                {
                    return;
                }
            }
            mailItem.Display(false);

        }
    }
}