using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public class Loger
    {
        string configAddress = "config.txt";
        string logfileFolder;
        string logfileAddress;
        DateTime time;
        public Loger(TextBox logfileAddressTextBox)
        {
            time = new DateTime();
            try
            {
                using (StreamReader sr = new StreamReader(configAddress))
                {
                    logfileFolder = sr.ReadToEnd();
                }
                logfileAddress = (logfileFolder + "Log_" + DateTime.Now + ".txt").Replace(' ', '_').Replace(':', '.');
                logfileAddressTextBox.Text = logfileAddress;
            }
            catch (Exception ex) { }
        }
        public void AddToLogfile(string text)
        {
            StreamWriter sw = new StreamWriter(logfileAddress, true);
            sw.WriteLine(text);
            sw.Close();
        }
        public void ChangeLogfileAddress(string address)
        {
            logfileAddress = address;
        }
    }
}