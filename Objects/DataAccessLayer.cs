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
                    //, @, @login, @password, @name, @surname, @photo, @email, @phone
                    cmd.Parameters.AddWithValue("@rfidTag", user.Rfid_tag);
                    cmd.Parameters.AddWithValue("@roleID", user.RoleID);
                    cmd.Parameters.AddWithValue("@login", user.Login);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@surname", user.Surname);
                    cmd.Parameters.AddWithValue("@photo", user.Photo);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phone", user.Photo);

                    cmd.ExecuteNonQuery();
                    db.connection.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

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
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();

                        if (!reader.IsDBNull(0))
                        {
                            inOrOut = reader.GetInt32(0);
                        }




                    }
                    cmd.Parameters.AddWithValue("@rfidTag", rfid_tag);
                    cmd.Parameters.AddWithValue("@inOrOut", inOrOut == 0 ? 1 : 0);
                    cmd.ExecuteNonQuery();
                    db.connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion
        #region Read
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
                db.connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
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

                    User user = new User((int)reader[0], reader[1] == DBNull.Value ? "" : (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (string)reader[5], (byte[])reader[6], (string)reader[7], (string)reader[8]);
                    db.connection.Close();
                    return user;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

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
                    db.connection.Close();
                    return dt;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

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
                    db.connection.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

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
                    db.connection.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion
        #region Update
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
                    cmd.Parameters.AddWithValue("@rfidTag", userInstance.Rfid_tag);
                    cmd.Parameters.AddWithValue("@name", userInstance.Name);
                    cmd.Parameters.AddWithValue("@surname", userInstance.Surname);
                    cmd.Parameters.AddWithValue("@photo", userInstance.Photo);
                    cmd.Parameters.AddWithValue("@email", userInstance.Email);
                    cmd.Parameters.AddWithValue("@phone", userInstance.Phone);

                    cmd.ExecuteNonQuery();
                }

                db.connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
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
                        return false;
                    }
                    //check for old password
                    if (Program.ComputeSHA256(oldPassword) != (string)reader[0])
                    {
                        return false;
                    }
                    //finally execute update password
                    SqlCommand cmd1 = new SqlCommand(Program.UPDATE_PASSWORD, db.connection);

                    cmd1.Parameters.AddWithValue("@password", Program.ComputeSHA256(newPassword));
                    cmd1.Parameters.AddWithValue("@userID", userID);

                    cmd1.ExecuteNonQuery();
                    db.connection.Close();

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion
        #region Delete
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
                db.connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion
    }
}
