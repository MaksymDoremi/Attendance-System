using PSS_Final.Objects;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PSS_Final
{

    internal class RFID
    {
        private SerialPort serialPort;
        public static string RFID_tag;

        private BusinessLogicLayer bll;
        public RFID()
        {
            bll = new BusinessLogicLayer();
            RFID_tag = "";

            try
            {
                serialPort = new SerialPort(AutodetectArduinoPort(), 9600);
                serialPort.Open();
                Thread rfidThread = new Thread(this.readTag);
                rfidThread.Start();
            }
            catch
            {
                MessageBox.Show("COM failed to open, maybe it's not in use.");
            }

        }

        public void readTag()
        {
            string rfid = "";
            while (true)
            {

                System.Threading.Thread.Sleep(10);

                rfid = serialPort.ReadLine().Trim();

                if (rfid != "")
                {
                    Console.WriteLine(rfid);

                    bll.InsertAttendance(rfid);

                    rfid = "";
                }

                if (rfid == "")
                {
                    Console.WriteLine("null");
                }



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
