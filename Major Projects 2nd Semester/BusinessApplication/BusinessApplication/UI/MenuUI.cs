using BusinessApplication.BL;
using BusinessApplication.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.UI
{
    class MenuUI
    {
        static List<string> helpInfo = new List<string> {"0223284784", "ioejw@gmail.com", "this is help message" };


        public static void Header()
        {
            Console.WriteLine("this is header");
        }

        public static void clearScreen()
        {
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static int StartUpScreen()
        {
            Console.WriteLine("chose option, signup, login");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        public static string printCustomerInterface()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    Chose Option");

            Console.WriteLine("\n\n");
            Console.WriteLine("\n\n");
            Console.WriteLine("\t  1. Book Flight                                7. Change Food");
            Console.WriteLine("\n");
            Console.WriteLine("\t  2. Cancel Flight                              8. See Announcements");
            Console.WriteLine("\n");
            Console.WriteLine("\t  3. See My Flights                             9. Change Password");
            Console.WriteLine("\n");
            Console.WriteLine("\t  4. File Complain                              10. Change Username ");
            Console.WriteLine("\n");
            Console.WriteLine("\t  5. See Complain                               11. Help ");
            Console.WriteLine("\n");
            Console.WriteLine("\t  6. Remove Complain                            12. Exit ");
            Console.WriteLine("\n\n");
            Console.WriteLine("\n\n");

            Console.WriteLine("enter option");
            string option = Console.ReadLine();

            return option;


        }

        public static string printAdminInterface(bool takeInput = true)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    Chose Option");

            Console.WriteLine("\n\n");
            Console.WriteLine("\t  1. Add Flight                                7. Search Flights                  ");
            Console.WriteLine("\n");
            Console.WriteLine("\t  2. Remove Flight                             8. Change Price");
            Console.WriteLine("\n");
            Console.WriteLine("\t  3. Check Booked Flights                      9.  Add announcement");
            Console.WriteLine("\n");
            Console.WriteLine("\t  4. See Complain Box                          10. Remove announcement ");
            Console.WriteLine("\n");
            Console.WriteLine("\t  5. See How To Guide                          11. Modify announcement ");
            Console.WriteLine("\n");
            Console.WriteLine("\t  6. Change Contact info                       12. Remove customer ");
            Console.WriteLine("\n");
            Console.WriteLine("\t                            13. Exit                         ");
            Console.WriteLine("\n\n");

            string option = "";
            if (takeInput)
            {
                Console.WriteLine("enter option");
                option = Console.ReadLine();
            }
            

            return option;

        }

        public static void seeHowToUseGuide()
        {
            animhowToUseFull();
            Console.Clear();

            MenuUI.printAdminInterface(false);
            Console.Write("\n\n");
            animprintRoboInterface();
            Console.ReadKey();
        }

        private static void animhowToUseFull()
        {
            Console.Clear();
            Console.Write("\n\n");
            animprintHowToLogo();
            Console.Write("\n\n");
            animprintRobo();
            Console.ReadKey();
            
        }

        private static void animprintHowToLogo()
        {
            Console.WriteLine("             _    _                 _______       _    _              _____       _     _        " );
            Console.WriteLine("            | |  | |               |__   __|     | |  | |            / ____|     (_)   | |       " );
            Console.WriteLine("            | |__| | _____      __    | | ___    | |  | |___  ___    | |  __ _   _ _  __| | ___   " );
            Console.WriteLine("            |  __  |/ _ | | /| / /    | |/ _  |  | |  | / __|/ _  |  | | |_ | | | | |/ _` |/ _  |  " );
            Console.WriteLine("            | |  | | (_) | V  V /     | | (_) |  | |__|  |__ |  __/  | |__| | |_| | | (_| |  __/  " );
            Console.WriteLine("            |_|  |_| |___/ |_/|_/     |_| |___/  |____/|___/ |___|   |_____| |__,_|_| |__,_| |___|  " );
        }

        private static void animprintRobo()
        {
            Console.WriteLine( "                      ****                                                                                    " );
            Console.WriteLine( "            ,,,,,,,,,,,,,,,,,,,,,,,,,                                                                         " );
            Console.WriteLine( "           /#%####/@@(#####@@@(###///                                                                         " );
            Console.WriteLine( "         *..##                   #///..,                                                                      " );
            Console.WriteLine( "         ,####     ##      ##    #///##*                  #################################################   " );
            Console.WriteLine( "         *,%##                   *////,,                  #                                               #   " );
            Console.WriteLine( "          .&##                   /////,                   #                                               #   " );
            Console.WriteLine( "          .,,,,,,,,,,,,,,,,,,,,,,,,,,,*                   #        Hi i am Robo, Your assistant.          #   " );
            Console.WriteLine( "           ,,,,,,,,,,,,,,,,,,,,,,,,,,.                    #                                               #   " );
            Console.WriteLine( "           ,,,,#@@@@@@@@@@@@@@@@@#,,,,                    #        Welcome to our Flight company          #   " );
            Console.WriteLine( "         /,,,,,#@@@@@@@@@@@%@@@@@#,,,,,                   #                                               #   " );
            Console.WriteLine( "        *,,,,  #%%@@#@/@@@@@&@&&%#,,,,,,                  #         We want you to know you made          #   " );
            Console.WriteLine( "       ,,,,*   #@@@@@@@@@@@@@@@@@#,  ,,,,,                #       the right choice, let us start by       #   " );
            Console.WriteLine( "   . ,,,,,.    ##(##/,,,,,,,,##(##,   ,,,,,, ,            #        giving a quick how to use guide.       #   " );
            Console.WriteLine( " ,,,,,,,,      #(,,#,,,,,,,,,##,,#,     ,,,,,,,,,         #                                               #   " );
            Console.WriteLine( ",,,. ,,,,*      ..,@%###(**(####&,.       ,,,, ,,         #          PRESS ANYTHING TO CONTINUE...        #   " );
            Console.WriteLine( "* .,,,.          ,%#(((/,,/####&,         .,,,            #                                               #   " );
            Console.WriteLine( "                 ,(((((/,,/####&*                         #################################################   " );
            Console.WriteLine( "                 *%#(((/,,/####&(                                                                             " );
            Console.WriteLine( "             ,%%########//#########%,                                                                         " );
            Console.WriteLine( "            #########(///(//((########                                                                        " );
        }

        private static void animprintRoboInterface()
        {
            {
                Console.WriteLine( "                      ****                                                                                    " );
                Console.WriteLine( "            ,,,,,,,,,,,,,,,,,,,,,,,,,                                                                         " );
                Console.WriteLine( "           /#%####/@@(#####@@@(###///                                                                         " );
                Console.WriteLine( "         *..##                   #///..,                  #################################################   " );
                Console.WriteLine( "         ,####     ##      ##    #///##*                  #                                               #   " );
                Console.WriteLine( "         *,%##                   *////,,                  #        The above you see is the interface     #   " );
                Console.WriteLine( "          .&##                   /////,                   #        You can select a choice from there     #   " );
                Console.WriteLine( "          .,,,,,,,,,,,,,,,,,,,,,,,,,,,*                   #                                               #   " );
                Console.WriteLine( "           ,,,,,,,,,,,,,,,,,,,,,,,,,,.                    #        We are proud to announce that          #   " );
                Console.WriteLine( "           ,,,,#@@@@@@@@@@@@@@@@@#,,,,                    #     our selection is not limited to numbers   #   " );
                Console.WriteLine( "         /,,,,,#@@@@@@@@@@@%@@@@@#,,,,,                   #       You can try LITERALLY ANYTHING like,    #   " );
                Console.WriteLine( "        *,,,,  #%%@@#@/@@@@@&@&&%#,,,,,,                  #                                               #   " );
                Console.WriteLine( "       ,,,,*   #@@@@@@@@@@@@@@@@@#,  ,,,,,                #      ---> I want to remove a flight           #   " );
                Console.WriteLine( "   . ,,,,,.    ##(##/,,,,,,,,##(##,   ,,,,,, ,            #      ---> Show me complains added by users    #   " );
                Console.WriteLine( " ,,,,,,,,      #(,,#,,,,,,,,,##,,#,     ,,,,,,,,,         #                                               #   " );
                Console.WriteLine( ",,,. ,,,,*      ..,@%###(**(####&,.       ,,,, ,,         #       any many more, or you can stick to      #   " );
                Console.WriteLine( "* .,,,.          ,%#(((/,,/####&,         .,,,            #       traditional 0s and 1. Your choice.      #   " );
                Console.WriteLine( "                 ,(((((/,,/####&*                         #                                               #   " );
                Console.WriteLine( "                 *%#(((/,,/####&(                         #       For any problem, see help menu...       #   " );
                Console.WriteLine( "             ,%%########//#########%,                     #################################################   " );
                Console.WriteLine( "            #########(///(//((########                                                                        " );
            }
        }

        public static void printHelpMenu()
        {
                Console.WriteLine( "This is help menu \n\n");
                Console.WriteLine( "Contact No: " + helpInfo[0]);
                Console.WriteLine( "Email: " + helpInfo[1]);
                Console.WriteLine(helpInfo[2]);

        }

        public static void editHelpMenu()
        {
            Console.WriteLine("enter info you want to change, in case you donot want to change, just press enterwithout writing anything");

            Console.WriteLine("enter contact no");
            string contactNo = "";
            contactNo = Console.ReadLine();
            if (contactNo != "")
            {
                helpInfo[0] = contactNo;
            }

            Console.WriteLine("enter email");
            string email = "";
            email = Console.ReadLine();
            if (email != "")
            {
                helpInfo[1] = email;
            }

            Console.WriteLine("enter message");
            string message = "";
            message = Console.ReadLine();
            if (message != "")
            {
                helpInfo[2] = message;
            }
        }




    }
}
