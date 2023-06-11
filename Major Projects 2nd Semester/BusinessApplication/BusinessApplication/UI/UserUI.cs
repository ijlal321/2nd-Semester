using BusinessApplication.BL;
using BusinessApplication.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.UI
{
    class UserUI
    {
        public static User takeInputFromConsole()
        {
            Console.WriteLine("enter ID");
            string ID = Console.ReadLine();

            Console.WriteLine("enter password");
            string password = Console.ReadLine();

            Console.WriteLine("enter role");
            string role = Console.ReadLine();

            User user;
            if ( role == "admin")
            {
                user = new Admin(ID, password);
            }
            else
            {
                user = new Customer(ID, password);
            }
            return user;
        }

        public static User SignUp()
        {
            User currentUser = UserUI.takeInputFromConsole();
            if ( UserDL.isIDUnique(currentUser) == false)
            {
                Console.WriteLine("username already exist");
                return null;
            }

            if ( currentUser.getRole() == "customer")
            {
                // CustomerDL.addIntoList(currentUser);
                return currentUser;
            }

            else
            {
                Console.WriteLine("to make a admin account, you have to ask a admin to enter his credentials");

                Console.WriteLine("admin, please enter your name");
                string ID = Console.ReadLine();

                Console.WriteLine("admin, please enter your Password");
                string password = Console.ReadLine();
                User headAdmin = new Admin(ID, password);

                if (UserDL.FindInList(headAdmin) != null && headAdmin.getRole() == "admin")
                {
                    // AdminDL.addIntoList(currentUser);
                    return currentUser;
                }

                Console.WriteLine("admin cannot be verified");

                return null;
            }



        }

        public static User Login()
        {
            Console.WriteLine("please enter your name");
            string ID = Console.ReadLine();

            Console.WriteLine("please enter your Password");
            string password = Console.ReadLine();

            return UserDL.FindInList(ID, password);
        }

        public static void changeUsername(User user)
        {
            Console.WriteLine("enter password");
            string Password = Console.ReadLine();

            if (Password == user.getPassword())
            {
                Console.WriteLine("verified");
                Console.WriteLine("Enter new username");
                string newUsername = Console.ReadLine();

                if (UserDL.isIDUnique(newUsername) == true)
                {
                    user.changeIDInAllBookedFLights(newUsername);  // will do nothing in case user is admin, bcz empty in virtual
                    user.setID(newUsername);
                }
                else
                {
                    Console.WriteLine("Username already taken");
                }


            }
        }

        public static void changePassword(User user)
        {
            Console.WriteLine("enter old password");
            string oldPassword = Console.ReadLine();

            if ( oldPassword == user.getPassword())
            {
                Console.WriteLine("verified");
                Console.WriteLine("Enter new password");
                string newPassword = Console.ReadLine();

                user.setPassword(newPassword);

            }
        }

        public static void removeCustomer()
        {
            if (CustomerDL.isAnyCustomerAvailable() == false)
            {
                Console.WriteLine("no customers found");
            }
            else
            {
                CustomerUI.showAllCustomers();
                Console.WriteLine("enter customer you want to delete");
                int option = int.Parse(Console.ReadLine());

                User removeUser = CustomerDL.getList()[option];

                CustomerDL.removeFromList(removeUser);
                UserDL.removeFromList(removeUser);
            }
        }

    }
}
