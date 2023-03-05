using PSS_Final.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSS_Final.Objects
{
    public class DataAccessLayer
    {
        #region Create
        /// <summary>
        /// Inserts user into database
        /// </summary>
        /// <param name="user">User instance to be inserted</param>
        /// <returns>True if insert was successfull</returns>
        public bool InsertUser(User user)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(Program.INSERT_USER, db.connection))
                {
                    cmd.Parameters.AddWithValue("@rfidTag", string.IsNullOrEmpty(user.Rfid_tag) ? DBNull.Value : (object)user.Rfid_tag);
                    cmd.Parameters.AddWithValue("@roleID", user.RoleID);
                    cmd.Parameters.AddWithValue("@login", user.Login);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@surname", user.Surname);
                    cmd.Parameters.Add("@photo", SqlDbType.VarBinary, -1).Value = user.Photo != null ? (object)user.Photo : DBNull.Value;
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(user.Email) ? DBNull.Value : (object)user.Email);
                    cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(user.Phone) ? DBNull.Value : (object)user.Phone);

                    cmd.ExecuteNonQuery();

                }
                db.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return false;
            }

        }
        /// <summary>
        /// Inserts attendance record with current timestamp
        /// </summary>
        /// <param name="rfid_tag">Rfid tag taken from usb bus</param>
        /// <returns>True if insert was successfull</returns>
        public bool InsertAttendance(string rfid_tag)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(Program.INSERT_ATTENDANCE, db.connection))
                {
                    int inOrOut = 0;
                    using (SqlCommand subSelect = new SqlCommand(Program.SUB_SELECT_ATTENDANCE, db.connection))
                    {
                        subSelect.Parameters.AddWithValue("@rfidTag", rfid_tag);
                        SqlDataReader reader = subSelect.ExecuteReader();
                        reader.Read();

                        if (reader.HasRows)
                        {

                            inOrOut = Convert.ToInt32(reader[0]);
                        }

                        reader.Close();
                    }
                    cmd.Parameters.AddWithValue("@rfidTag", rfid_tag);
                    cmd.Parameters.AddWithValue("@inOrOut", inOrOut == 0 ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return false;
            }
        }
        #endregion
        #region Read
        /// <summary>
        /// Checks if login and password exist in database
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>True if record exists</returns>
        public bool Login(string login, string password)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(Program.LOGIN, db.connection))
                {
                    cmd.Parameters.AddWithValue("@loginInput", login);
                    cmd.Parameters.AddWithValue("@passwordInput", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();


                    if (!reader.HasRows)
                    {
                        return false;
                    }
                }
                db.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return false;
            }
        }
        /// <summary>
        /// Gets current user from database by inserted login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>User where login = inserted login</returns>
        public User GetCurrentUser(string login)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(Program.GET_CURRENT_USER, db.connection))
                {
                    cmd.Parameters.AddWithValue("@loginInput", login);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();

                    if (!reader.HasRows) return null;

                    User user = new User((int)reader[0],
                        reader[1] == DBNull.Value ? "" : (string)reader[1],
                        (string)reader[2],
                        (string)reader[3],
                        (string)reader[4],
                        (string)reader[5],
                        reader[6] == DBNull.Value ? null : (byte[])reader[6],
                        reader[7] == DBNull.Value ? "" : (string)reader[7],
                        reader[8] == DBNull.Value ? "" : (string)reader[8]);
                    db.CloseConnection();

                    return user;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return null;
            }
        }
        /// <summary>
        /// Gets all users from database except of current
        /// </summary>
        /// <param name="currentUserLogin"></param>
        /// <returns>DataTable with users</returns>
        public DataTable GetUsers(string currentUserLogin)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(Program.GET_USERS, db.connection);

                cmd.Parameters.AddWithValue("@currentUserLogin", currentUserLogin);


                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    db.CloseConnection();

                    return dt;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return null;
            }
        }
        /// <summary>
        /// Gets all attendance from database
        /// </summary>
        /// <returns>DataTable of attendance records</returns>
        public DataTable GetAttendance()
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(Program.GET_ALL_ATTENDANCE, db.connection);

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    db.CloseConnection();

                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return null;
            }
        }
        /// <summary>
        /// Gets attendance by userID. Used for users with role "User"
        /// </summary>
        /// <param name="userID">current user id</param>
        /// <returns>DataTable of attendance records</returns>
        public DataTable GetAttendaceByUser(int userID)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(Program.GET_ATTENDACE_BY_USER, db.connection);
                cmd.Parameters.AddWithValue("@userID", userID);

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    db.CloseConnection();

                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return null;
            }
        }
        /// <summary>
        /// Gets last attendance records with type - check in or check out
        /// </summary>
        /// <returns>DataTable of Attendance records</returns>
        public DataTable GetAttendaceType()
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(Program.ATTENDANCE_TYPE, db.connection);

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    db.CloseConnection();

                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return null;
            }
        }
        #endregion
        #region Update
        /// <summary>
        /// Updates user in database
        /// </summary>
        /// <param name="userInstance">New user instance (data collected from textBoxes)</param>
        /// <returns>True if update was successfull</returns>
        public bool UpdateUser(User userInstance)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(Program.UPDATE_USER, db.connection))
                {
                    cmd.Parameters.AddWithValue("@userID", userInstance.Id);
                    if (userInstance.Rfid_tag == "" || userInstance.Rfid_tag == null)
                    {
                        cmd.Parameters.AddWithValue("@rfidTag", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@rfidTag", userInstance.Rfid_tag);
                    }
                    cmd.Parameters.AddWithValue("@name", userInstance.Name);
                    cmd.Parameters.AddWithValue("@surname", userInstance.Surname);
                    cmd.Parameters.AddWithValue("@photo", userInstance.Photo);
                    cmd.Parameters.AddWithValue("@email", userInstance.Email);
                    cmd.Parameters.AddWithValue("@phone", userInstance.Phone);

                    cmd.ExecuteNonQuery();
                }

                db.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return false;
            }
        }
        /// <summary>
        /// Updates password in database where userID
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="oldPassword">Old password for the first access</param>
        /// <param name="newPassword">Final password to be applied</param>
        /// <returns>True if update was successfull</returns>
        public bool UpdatePassword(int userID, string oldPassword, string newPassword)
        {

            //check connection
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                //firstly check if oldpassword is correct
                using (SqlCommand cmd = new SqlCommand(Program.GET_PASSWORD, db.connection))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    //check for rows, if there's no rows so end it all
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        return false;
                    }
                    //check for old password
                    if (Program.ComputeSHA256(oldPassword) != (string)reader[0])
                    {
                        MessageBox.Show("Old password is not correct");
                        reader.Close();
                        return false;
                    }
                    reader.Close();

                    //finally execute update password
                    SqlCommand cmd1 = new SqlCommand(Program.UPDATE_PASSWORD, db.connection);

                    cmd1.Parameters.AddWithValue("@password", Program.ComputeSHA256(newPassword));
                    cmd1.Parameters.AddWithValue("@userID", userID);

                    cmd1.ExecuteNonQuery();
                }
                db.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return false;
            }
        }
        #endregion
        #region Delete
        /// <summary>
        /// Deletes user from database by id
        /// </summary>
        /// <param name="userID">User id which is gonna be deleted</param>
        /// <returns>True if delete was successfull</returns>
        public bool DeleteUser(int userID)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(Program.DELETE_USER, db.connection))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);

                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return false;
            }

        }
        /// <summary>
        /// Deletes all attendance records for user
        /// </summary>
        /// <param name="userID">User id which is referencing</param>
        /// <returns>True is delete was successfull</returns>
        public bool DeleteAttendance(int userID)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.connection.State == ConnectionState.Closed)
            {
                db.connection.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(Program.DELETE_ATTENDANCE, db.connection))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);

                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.CloseConnection();

                return false;
            }

        }
        #endregion
    }
}
