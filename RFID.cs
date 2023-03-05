using PSS_Final.Objects;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PSS_Final
{

    internal class RFID
    {
        public static SerialPort serialPort;


        private BusinessLogicLayer bll;
        public RFID()
        {

            serialPort = new SerialPort(AutodetectArduinoPort(), 9600);
            serialPort.Open();


        }
        public static void CloseSerialPort()
        {
            try
            {
                if(serialPort != null)
                {
                    serialPort.Close();
                }
                
            }
            catch(Exception ex)
            {
                //do nothing
            }

        }

        public static void OpenSerialPort()
        {
            try
            {
                if (serialPort != null)
                {
                    serialPort.Open();
                }
            }
            catch(Exception ex)
            {

            }

        }

        public void ReturnTag()
        {
            string rfid = "";


            while (true)
            {
                System.Threading.Thread.Sleep(10);
                try
                {
                    rfid = serialPort.ReadLine().Trim();

                    if (rfid != "")
                    {
                        Console.WriteLine(rfid);
                        MessageBox.Show("RFID tag: " + rfid);
                    }
                }
                catch { }

            }



        }
        public void ReadTag()
        {
            string rfid = "";
            bll = new BusinessLogicLayer();
            while (true)
            {
                rfid = null;
                System.Threading.Thread.Sleep(10);
                try
                {
                    rfid = serialPort.ReadLine().Trim();

                    if (rfid != "" && rfid != null)
                    {
                        Console.WriteLine(rfid);

                        bll.InsertAttendance(rfid);


                    }


                }
                catch
                {

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
