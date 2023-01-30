using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PSS_Final
{

    internal class RFID
    {
        private SerialPort serialPort;
        public static string RFID_tag;
        public RFID()
        {
            RFID_tag = "";
            
            try
            {
                serialPort = new SerialPort(AutodetectArduinoPort(), 9600);
                serialPort.Open();
            }
            catch
            {
                Console.WriteLine("COM failed to open, maybe it's not in use.");
            }

        }

        public void readTag()
        {

            while (true)
            {
                System.Threading.Thread.Sleep(10);
                RFID_tag = serialPort.ReadLine().Trim();

                Console.WriteLine(RFID_tag);

            }


        }
        private string AutodetectArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
            }

            return null;
        }
    }
}
