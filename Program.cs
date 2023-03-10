using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using System.Security.Policy;
using System.IO;
using System.Data;
using System.Drawing;

namespace PSS_Final
{

    internal static class Program
    {
        #region SQL Commands
        #region Create
        /// <summary>
        /// Inserts new user into database
        /// <para>@rfidTag, @roleID, @login, @password, @name, @surname, @photo, @email, @phone</para>
        /// </summary>
        public const string INSERT_USER = "insert into [User](RFID_Tag, Role_ID, Login, Password, Name, Surname, Photo, Email, Phone) values(@rfidTag, @roleID, @login, @password, @name, @surname, @photo, @email, @phone)";
        /// <summary>
        /// Inserts attendance by rfid tag. 1 = in, 0 = out
        /// <para>@rfidTag, @inOrOut</para>
        /// </summary>
        public const string INSERT_ATTENDANCE = "insert into Attendance(User_ID, DateTime, Type) values((select [User].ID from [User] where [User].RFID_Tag = @rfidTag),CURRENT_TIMESTAMP,@inOrOut)";
        /// <summary>
        /// Subselect to get last attendace record (come, leave, come, leave)
        /// </summary>
        public const string SUB_SELECT_ATTENDANCE = "select top 1 Attendance.Type from Attendance where Attendance.User_ID = (select [User].ID from [User] where [User].RFID_Tag = @rfidTag) order by Attendance.DateTime desc";
        #endregion
        #region Read
        /// <summary>
        /// Searches for any appearance in database with @loginInput and @passwordInput
        /// Actually it will find only one.
        /// <para>@loginInput @passwordInput</para>
        /// </summary>
        public const string LOGIN = "select * from [User] where Login=@loginInput and Password=@passwordInput";
        /// <summary>
        /// Gets current user by current login
        /// <para>ID, RFID_Tag, Role, Login, Name, Surname, Photo, Email, Phone</para>
        /// <para>@loginInput</para>
        /// </summary>
        public const string GET_CURRENT_USER = "select [User].ID, [User].RFID_Tag, [Role].Name as Role, [User].Login, [User].Name, [User].Surname, [User].Photo, [User].Email, [User].Phone from [User] inner join [Role] on [User].Role_ID = [Role].ID where Login=@loginInput";
        /// <summary>
        /// Gets all user except of current user 
        /// <para>ID, RFID_Tag, Role, Login, Name, Surname, Photo, Email, Phone</para>
        /// <para>@currentUserLogin</para>
        /// </summary>
        public const string GET_USERS = "select [User].ID, [User].RFID_Tag, [Role].Name as Role, [User].Login, [User].Name, [User].Surname, [User].Photo, [User].Email, [User].Phone from [User] inner join [Role] on [User].Role_ID = [Role].ID where Login!=@currentUserLogin";
        /// <summary>
        /// Gets all attendance
        /// <para>ID, Name, Surname, DateTime, Type(1 = come in, 0 = leave)</para>
        /// </summary>
        public const string GET_ALL_ATTENDANCE = "select Attendance.ID, [User].Name, [User].Surname, Attendance.DateTime, Attendance.Type from Attendance inner join[User] on Attendance.User_ID = [User].ID";
        /// <summary>
        /// Gets all attendace for exact user
        /// <para>@userID</para>
        /// </summary>
        public const string GET_ATTENDACE_BY_USER = "select Attendance.ID, [User].Name, [User].Surname, Attendance.DateTime, Attendance.Type from Attendance inner join[User] on Attendance.User_ID = [User].ID where [User].ID = @userID";
        /// <summary>
        /// Get password
        /// <para>@userID</para>
        /// </summary>
        public const string GET_PASSWORD = "select [User].Password from [User] where [User].ID = @userID";
        /// <summary>
        /// Gets last record for each user
        /// <para>Type, Name, Surname</para>
        /// </summary>
        public const string ATTENDANCE_TYPE = "SELECT a.Type, u.Name, u.Surname FROM Attendance a JOIN (   SELECT Attendance.User_ID, MAX(Attendance.DateTime) AS max_datetime   FROM Attendance  GROUP BY Attendance.User_ID ) b ON a.User_ID = b.User_ID AND a.DateTime = b.max_datetime JOIN [User] u ON a.User_ID = u.ID ";
        #endregion
        #region Update
        /// <summary>
        /// Update user information
        /// <para>@rfidTag, @name, @surname, @photo, @email, @phone, @userID</para>
        /// </summary>
        public const string UPDATE_USER = "update [User] set RFID_Tag = @rfidTag, Name = @name, Surname = @surname, Photo = @photo, Email = @email, Phone = @phone where [User].ID = @userID";
        /// <summary>
        /// Change password
        /// <para>@password, @userID</para>
        /// </summary>
        public const string UPDATE_PASSWORD = "update [User] set Password = @password where [User].ID = @userID";
        #endregion
        #region Delete
        /// <summary>
        /// Deletes user from database
        /// <para>@userID</para>
        /// </summary>
        public const string DELETE_USER = "delete from [User] where [User].ID = @userID";
        /// <summary>
        /// Deletes all attendance from database by userID. Use before deleting user
        /// <para>@userID</para>
        /// </summary>
        public const string DELETE_ATTENDANCE = "delete from Attendance where User_ID = @userID";
        #endregion
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            //start arduino reader in different thread





            //start windows forms window

            //Thread thread = new Thread(RunProgram);
            //thread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());


        }

        private static void RunProgram()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
        #region Methods
        /// <summary>
        /// Takes string and hashes it to SHA256
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ComputeSHA256(string s)
        {
            string hash = String.Empty;

            // Initialize a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s + "do?enS12*hj*")); //add random string to make hash even more secure

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }
        /// <summary>
        /// Takes Image and converts to byte[]
        /// </summary>
        /// <param name="imageIn"></param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(Image imageIn)
        {
            //ImageConverter converter = new ImageConverter();

            //return (byte[])converter.ConvertTo(imageIn, typeof(byte[]));
            if (imageIn == null)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                //imageIn.Save(ms, imageIn.RawFormat);
                (new Bitmap(imageIn)).Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }

        }
        /// <summary>
        /// Takes byte[] and converts to Image
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        #endregion
    }


}
