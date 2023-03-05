using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS_Final
{
    public class User
    {
        #region Fields
        private int id;
        private string rfid_tag;
        private string role;
        private string name;
        private string surname;
        private string login;
        private string password;
        private string email;
        private string phone;
        private byte[] photo;
        #endregion
        #region Constructors
        public User(int id, string rfid_tag, string role, string login,string password, string name, string surname, byte[] photo, string email, string phone)
        {
            this.Id = id;
            this.Rfid_tag = rfid_tag;
            this.Role = role;
            this.Name = name;
            this.Surname = surname;
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.Phone = phone;
            this.Photo = photo;
        }
        public User(int id, string rfid_tag, string role, string login, string name, string surname, byte[] photo, string email, string phone)
        {
            this.Id = id;
            this.Rfid_tag = rfid_tag;
            this.Role = role;
            this.Name = name;
            this.Surname = surname;
            this.Login = login;
            this.Email = email;
            this.Phone = phone;
            this.Photo = photo;
        }
        public User(string rfid_tag, string role, string login, string password, string name, string surname, byte[] photo, string email, string phone)
        { 
            this.Rfid_tag = rfid_tag;
            this.Role = role;
            this.Name = name;
            this.Surname = surname;
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.Phone = phone;
            this.Photo = photo;
        }
        #endregion
        #region Getters and setters
        public int Id { get => id; set => id = value; }
        public string Rfid_tag { get => rfid_tag; set => rfid_tag = value; }
        public string Role { get => role; set => role = value; }
        public int RoleID { get => (Role) == "Admin" ? 1 : (Role) == "User" ? 2 : 0; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public byte[] Photo { get => photo; set => photo = value; }
        #endregion
    }
}
