using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    internal class DataManager
    {
        public DisplayDelegate displayManager { get; set; }

        public DataManager()
        {
            displayManager = new DisplayDelegate(LogMessage);
        }

        private void LogMessage(string message)
        {
            Console.WriteLine("Log: " + message);
        }

        public void ShowYourMessage(DisplayDelegate displayDelegate)
        {
            if (displayDelegate == null)
            {
                Console.WriteLine("Error");
            }
            else
                displayDelegate("This is from Show Your Message Function.");
        }

        public void ShowYourMessageWithData(DisplayDelegate displayDelegate, string data)
        {
            if (data != null && data != "")
            {
                data += " is winner of the event.";
            }
            else
                data = "No one is winner of the event.";

            if (displayDelegate == null)
            {
                Console.WriteLine("Error");
            }
            else
                displayDelegate(data);
        }
    }
}
