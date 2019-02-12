using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
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
        public void Draft(string to, string template, string cc, string logPath="")
        {
            //create Outlook object
            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItemFromTemplate(@"\\fs1ol\Programy$\OL_Raporty\Raporty_DZOK\Szablony\" + template +".oft"); //template path

            mailItem.To = to;
            mailItem.CC = cc;

            if (logPath != "")
            {
                //if attachemnt does not exists go to next mail
                try
                {
                    mailItem.Attachments.Add(logPath);
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