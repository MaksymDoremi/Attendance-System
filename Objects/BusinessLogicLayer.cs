using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PSS_Final.Objects
{
    public class BusinessLogicLayer
    {
        public BusinessLogicLayer() { }

        #region Create
        public bool InsertUser(User user)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.InsertUser(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool InsertAttendance(string rfid_tag)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.InsertAttendance(rfid_tag);
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
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.Login(login, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public User GetCurrentUser(string login)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.GetCurrentUser(login);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DataTable GetUsers(string currentUserLogin)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.GetUsers(currentUserLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DataTable GetAttendance()
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.GetAttendance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DataTable GetAttendanceByUser(int userID)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.GetAttendaceByUser(userID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DataTable GetAttendanceType()
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.GetAttendaceType();
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
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.UpdateUser(userInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public bool UpdatePassword(int userID, string oldPassword, string newPassword)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.UpdatePassword(userID, oldPassword, newPassword);
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
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.DeleteUser(userID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public bool DeleteAttendance(int userID)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                return dal.DeleteAttendance(userID);
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
