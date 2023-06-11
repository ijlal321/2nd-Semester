using BusinessApplication.BL;
using BusinessApplication.UI;
using BusinessApplication.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string adminPath = "admin.txt";
            string announcementPath = "announcement.txt";
            string flightPath = "flight.txt";
            string customerPath = "customer.txt";
            string bookedFlightPath = "bookedFLight.txt"


            User currentUser = null;


            AdminDL.readFromFile(adminPath);
            AnnouncementDL.readFromFile(announcementPath);
            FlightDL.readFromFile(flightPath);
            CustomerDL.readFromFile(customerPath);
            BookedFlightDL.readFromFile(bookedFlightPath);
            // storeintoFile

            while (true)
            {

                while (true)       /// Login / Signup 
                {
                    int option = MenuUI.StartUpScreen();
                    if (option == 1)
                    {
                        currentUser = UserUI.SignUp();
                        if (currentUser == null)
                        {
                            Console.WriteLine("Please Enter valid info,   try again to be added");
                        }
                        else
                        {
                            Console.WriteLine("User added successfully");
                            if (currentUser.getRole() == "customer")
                            {
                                CustomerDL.addIntoList(currentUser);
                                CustomerDL.storeintoFile(customerPath);
                            }
                            else if (currentUser.getRole() == "admin")
                            {
                                AdminDL.addIntoList(currentUser);
                                AdminDL.storeintoFile(adminPath);
                            }
                        }

                    }

                    else if (option == 2)
                    {
                        currentUser = UserUI.Login();
                        if (currentUser == null)
                        {
                            Console.WriteLine("Credentials cannot be verified");
                        }
                        else
                        {
                            Console.WriteLine("User logged in successfully");
                            break;
                            // go to admin or 
                        }
                    }

                    else if (option == 3)
                    {
                        Console.ReadKey();
                        break;
                    }
                    MenuUI.clearScreen();
                }

                if (currentUser.getRole() == "customer")
                {
                    while (true)
                    {
                        Console.Clear();
                        string option = MenuUI.printCustomerInterface();
                        if (!SeachWord("see", option) && !SeachWord("cancel", option) && (option == "1" || ((SeachWord("book", option) || SeachWord("add", option) || SeachWord("new", option)) && (SeachWord("flight", option) || SeachWord("flights", option)))))
                        {
                            // Book Flight
                            MenuUI.Header();
                            BookedFlight bookedFlight = BookedFlightUI.takeInputFromConsole();
                            if (bookedFlight == null)
                            {
                                Console.WriteLine("no flight booked, going back");
                            }
                            else
                            {
                                currentUser.addBookedFlightIntoList(bookedFlight);
                                BookedFlightDL.storeintoFile(bookedFlightPath);
                            }
                        }
                        
                        else if (option == "2" || ((SeachWord("cancel", option) || SeachWord("remove", option) || SeachWord("delete", option)) && (SeachWord("flight", option) || SeachWord("flights", option))))
                        {
                            // Remove Flight
                            MenuUI.Header();
                            CustomerUI.cancelFlight(currentUser);
                            BookedFlightDL.storeintoFile(bookedFlightPath);

                        }
                        
                        else if (option == "3" || ((SeachWord("see", option) || SeachWord("show", option) || SeachWord("boooked", option)) && (SeachWord("flight", option) || SeachWord("flights", option))))
                        {
                            // See Flights
                            MenuUI.Header();
                            BookedFlightUI.showMyFlights(currentUser);
                        }
                        
                        else if (!SeachWord("see", option) && !SeachWord("remove", option) && (option == "4" || ((SeachWord("add", option) || SeachWord("new", option) || SeachWord("file", option)) && (SeachWord("complain", option) || SeachWord("complains", option)))))
                        {
                            // File Complain
                            MenuUI.Header();
                            CustomerUI.fileComplain(currentUser);
                            CustomerDL.storeintoFile(customerPath);
                        }
                        
                        else if (option == "5" || ((SeachWord("see", option) || SeachWord("show", option)) && (SeachWord("complain", option) || SeachWord("complains", option))))
                        {
                            // See Complain
                            MenuUI.Header();
                            CustomerUI.showMyComplain(currentUser);

                        }
                        
                        else if (option == "6" || ((SeachWord("remove", option) || SeachWord("delete", option)) && (SeachWord("complain", option) || SeachWord("complains", option))))
                        {
                            // Remove Complain
                            MenuUI.Header();
                            CustomerUI.RemoveComplain(currentUser);
                            CustomerDL.storeintoFile(customerPath);
                        }

                        else if (option == "7" || SeachWord("food", option) || SeachWord("Food", option))
                        {
                            // Change Food
                            MenuUI.Header();
                            CustomerUI.changeFood(currentUser);
                            BookedFlightDL.storeintoFile(bookedFlightPath);
                        }
                        
                        else if (option == "8" || ((SeachWord("see", option) || SeachWord("show", option)) && (SeachWord("announcements", option) || SeachWord("announcement", option))))
                        {
                            // See announcements
                            MenuUI.Header();
                            AnnouncementUI.showAllAnnouncement();
                        }
                        
                        else if (option == "9" || ((SeachWord("change", option) || SeachWord("edit", option)) && (SeachWord("id", option) || SeachWord("username", option) || SeachWord("Username", option))))
                        {
                            // Change password
                            MenuUI.Header();
                            UserUI.changePassword(currentUser);
                            
                        }
                        
                        else if (option == "10" || ((SeachWord("change", option) || SeachWord("edit", option)) && (SeachWord("password", option) || SeachWord("passward", option) || SeachWord("Password", option))))
                        {
                            // Change ID
                            MenuUI.Header();
                            UserUI.changeUsername(currentUser);
                            CustomerDL.storeintoFile(customerPath);
                            BookedFlightDL.storeintoFile(bookedFlightPath);

                        }
                        
                        else if (option == "11" || SeachWord("help", option) || SeachWord("contact", option) || SeachWord("Help", option))
                        {
                            MenuUI.Header();
                            MenuUI.printHelpMenu();

                        }
                        
                        else if (option == "12" || SeachWord("exit", option) || SeachWord("Exit", option))
                        {
                            break;
                        }
                        
                        else
                        {
                            Console.WriteLine("no valid option selected");
                        }

                        Console.ReadKey();
                    }
                }

                else if (currentUser.getRole() == "admin")
                {
                    while (true)
                    {
                        Console.Clear();
                        string option = MenuUI.printAdminInterface();


                        if (!SeachWord("see", option) && !SeachWord("remove", option) && (option == "1" || ((SeachWord("enter", option) || SeachWord("add", option) || SeachWord("new", option)) && (SeachWord("flight", option) || SeachWord("flights", option)))))
                        {
                            // Book Flight
                            MenuUI.Header();
                            Flight flight = FlightUI.takeInputFromConsole();
                            FlightDL.addIntoList(flight);
                            FlightDL.storeintoFile(flightPath);

                        }

                        else if (option == "2" || ((SeachWord("remove", option) || SeachWord("cancel", option) || SeachWord("delete", option)) && (SeachWord("flight", option) || SeachWord("flights", option))))
                        {
                            // Remove Flight
                            MenuUI.Header();
                            FlightUI.removeFlight();
                            FlightDL.storeintoFile(flightPath);
                        }

                        else if (option == "3" || ((SeachWord("see", option) || SeachWord("show", option) || SeachWord("check", option) || SeachWord("booked", option)) && (SeachWord("flight", option) || SeachWord("flights", option))))
                        {
                            // Book Flight
                            MenuUI.Header();
                            BookedFlightUI.showAllFlights();
                        }
                        
                        else if (option == "4" || ((SeachWord("see", option) || SeachWord("show", option) || SeachWord("box", option)) && (SeachWord("complain", option) || SeachWord("complains", option))))
                        {
                            // See Complain
                            MenuUI.Header();
                            CustomerUI.showAllComplains();
                            

                        }
                        
                        else if (option == "5" || SeachWord("guide", option))
                        {
                            // See how to guide
                            MenuUI.seeHowToUseGuide();
                        }

                        else if (option == "6" || (SeachWord("help", option) || (SeachWord("contact", option))))
                        {
                            // Change help menu
                            MenuUI.Header();
                            MenuUI.editHelpMenu();

                        }
                        
                        else if (option == "7" || (SeachWord("search", option) || (SeachWord("find", option))) && ((SeachWord("flight", option) || (SeachWord("flights", option)))))
                        {
                            // Search Flight
                            MenuUI.Header();
                            FlightUI.searchFlight();
                        }
                        
                        else if (option == "12" || ((SeachWord("remove", option) || SeachWord("delete", option)) && (SeachWord("customer", option) || SeachWord("customers", option))))
                        {
                            // Remove Customer
                            MenuUI.Header();
                            UserUI.removeCustomer();
                        }

                        else if (!SeachWord("see", option) && !SeachWord("remove", option) && (option == "9" || ((SeachWord("add", option) || SeachWord("new", option)) && (SeachWord("announcement", option) || SeachWord("announcements", option)))))
                        {
                            // Add Announcement
                            MenuUI.Header();
                            string announcement = AnnouncementUI.takeInputFromUser();
                            AnnouncementDL.addIntoList(announcement);
                            AnnouncementDL.storeintoFile(announcementPath);

                        }

                        else if (option == "10" || ((SeachWord("remove", option) || SeachWord("cancel", option) || SeachWord("delete", option)) && (SeachWord("announcement", option) || SeachWord("announcements", option))))
                        {
                            // Remove Announcement
                            MenuUI.Header();
                            AnnouncementUI.removeAnnouncement();
                            AnnouncementDL.storeintoFile(announcementPath);

                        }

                        else if (option == "11" || ((SeachWord("modify", option) || SeachWord("edit", option)) && (SeachWord("announcement", option) || SeachWord("announcements", option))))
                        {
                            // modify aannouncement
                            MenuUI.Header();
                            AnnouncementUI.modifyAnnouncement();
                            AnnouncementDL.storeintoFile(announcementPath);

                        }

                        else if (option == "8" || SeachWord("price", option) || SeachWord("Price", option))
                        {
                            // change price
                            MenuUI.Header();
                            FlightUI.changePrice();
                            FlightDL.storeintoFile(flightPath);
                        }

                        else if (option == "13" || SeachWord("Exit", option) || SeachWord("exit", option))
                        {
                            break;
                        }
                        
                        else
                        {
                            Console.WriteLine("no valid option selected");
                        }

                        Console.ReadKey();

                    }
                }

            }

                    /*

                    Flight flight1 = new Flight("1", "1", "1", "1");
                    Flight flight2 = new Flight("2", "2", "2", "2");
                    FlightDL.addIntoList(flight1);
                    FlightDL.addIntoList(flight2);

                    */

                    /*
                    FlightUI.changePrice();
                    FlightUI.showAllFlight();
                    */

                    /*
                    AnnouncementDL.addIntoList("helloooooo");
                    AnnouncementDL.addIntoList("ebqceruovherovho3rhvioer rjofqwp3");
                    */
                    /*
                    AnnouncementUI.removeAnnouncement();
                    AnnouncementUI.modifyAnnouncement();
                    AnnouncementUI.showAllAnnouncement();

                     */

                    /*
                    Customer customer1 = new Customer("12", "456");
                    CustomerDL.addIntoList(customer1);

                    BookedFlight bookedFlight1 = new BookedFlight(flight1, "veg");
                    customer1.addBookedFlightIntoList(bookedFlight1);

                    BookedFlight bookedFlight2 = new BookedFlight(flight1, "non-veg");
                    customer1.addBookedFlightIntoList(bookedFlight2);

                    */
                    /*
                    CustomerUI.showMyFlights(customer1);
                    CustomerUI.showAllFlights();
                    CustomerUI.cancelFlight(customer1);
                    CustomerUI.changeFood(customer1);
                    */
                    /*
                    CustomerUI.fileComplain(customer1);
                    CustomerUI.fileComplain(customer1);
                    CustomerUI.showAllComplains();
                    */
                    /*
                    CustomerUI.RemoveComplain(customer1);

                    CustomerUI.showMyComplain(customer1);
                    */


        }


        public static bool SeachWord(string word, string sentence)
        {
            int word_index = 0;
            int matching_Word = 0;
            int wordCheckSize = word.Length;

            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == ' ')
                {
                    word_index = 0;
                    matching_Word = 0;
                    continue;
                }
                if (sentence[i] == word[word_index])
                {
                    matching_Word += 1;
                    if (matching_Word == wordCheckSize)
                        return true;
                }
                word_index += 1;
                if (word_index >= word.Length)
                {
                    word_index = 0;
                }

            }
            return false;
        }

    }
}
