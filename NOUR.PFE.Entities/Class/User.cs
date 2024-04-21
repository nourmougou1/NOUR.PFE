﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NOUR.PFE.Entities
{
    public class User
    {

        #region Constructors 
        public User()
        {
            
            
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string UserPhone { get; set; }
        public UserRole UserRole { get; set; }
        public int RoleId { get; set; }
        public int roleId {  get; set; }
        
        public DateTime Birthday { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
        #endregion
        #region Methods  

        public bool Authenticate(string Login, string Password)
        {
            try
            {
                if ((Login != null) && (Login.Trim() != string.Empty)
                 && (this.Login != null) && (this.Login.Trim() != string.Empty)
                 && (Password != null) && (Password.Trim() != string.Empty)
                 && (this.Password != null) && (this.Password.Trim() != string.Empty))
                {
                    return Login.Trim().ToUpper().Equals(this.Login.Trim().ToUpper()) && Password.Equals(this.Password.Trim());
                }

                return false;
            }
            catch (Exception ex)
            {
                string _StrEX = ex.Message;
                return false;
            }
        }

        public override string ToString()
        {
            try
            {
                return string.Concat(this.FirstName, ' ', this.LastName);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        #endregion

        public string GetBirthDate(string dateFormat)
        {
            try
            {
                return this.Birthday.ToString(dateFormat);
            }
            catch (Exception ex)
            {
                string _StrEX = ex.Message;
                return string.Empty;
            }
        }
        public string GetCreationDate(string dateFormat)
        {
            try
            {
                return this.CreationDate.ToString(dateFormat);
            }
            catch (Exception ex)
            {
                string _StrEX = ex.Message;
                return string.Empty;
            }
        }


    }
}
