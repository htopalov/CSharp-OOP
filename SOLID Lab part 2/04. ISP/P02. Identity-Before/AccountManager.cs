namespace P02._Identity_Before
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class AccountManager : IAccountAutentication
    {

        public void Register(string username, string password)
        {
            //register acc
        }

        public void Login(string username, string password)
        {
            //login
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            // change password
        }   
    }
}
