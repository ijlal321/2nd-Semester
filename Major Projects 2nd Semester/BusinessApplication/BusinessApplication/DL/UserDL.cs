using BusinessApplication.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.DL
{
    class UserDL
    {
        static List<User> users = new List<User>();
        static User currentUser;

        public static User getCurrentUser()
        {
            return currentUser;
        }

        public static void setCurrentUser(User user)
        {
            currentUser = user;
        }

        public static List<User> getList()
        {
            return users;
        }

        public static void removeFromList(User user)
        {
            for(int i = 0; i < users.Count; i++)
            {
                if (users[i].getID() == user.getID())
                {
                    users.RemoveAt(i);
                    break;
                }
            }
        }

        public static void addIntoList(User user)
        {
            users.Add(user);
        }

        public static User FindInList(User user)
        {
            foreach( User u in users)
            {
                if ( user.getID() == u.getID() && user.getPassword() == u.getPassword() && user.getRole() == u.getRole())
                        return u;
            }
            return null;
        }

        public static User FindInList(string ID, string password)
        {
            foreach (User u in users)
            {
                if (ID == u.getID() && password == u.getPassword())
                    return u;
            }
            return null;
        }

        public static User FindInList(string ID, string password, string role)
        {
            foreach (User u in users)
            {
                if (ID == u.getID() && password == u.getPassword() && role == u.getRole())
                    return u;
            }
            return null;
        }

        public static bool isIDUnique(User user)
        {
            foreach (User u in users)
            {
                if (user.getID() == u.getID())
                        return false;
            }
            return true;
        }

        public static bool isIDUnique(string ID)
        {
            foreach (User u in users)
            {
                if (ID == u.getID())
                    return false;
            }
            return true;
        }





    }
}
