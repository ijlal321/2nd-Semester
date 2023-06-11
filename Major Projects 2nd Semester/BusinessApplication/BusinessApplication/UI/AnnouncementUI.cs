using BusinessApplication.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication.UI
{
    class AnnouncementUI
    {
        public static string takeInputFromUser()
        {
            Console.WriteLine("enter announcement");
            string announcement = Console.ReadLine();

            return announcement;
        }


        public static void showAllAnnouncement(bool seeSpecific = true)
        {
            List<string> announcements = AnnouncementDL.getAnnouncements();

            for (int i = 0; i < announcements.Count; i++)
            {
                if (announcements[i].Length < 15)
                {
                    Console.WriteLine(i + ". " + announcements[i]);
                }
                else
                {
                    Console.WriteLine(i + ". " + announcements[i].Substring(0, 15) + " ....");
                }
            }

            if (seeSpecific)
            {
                Console.WriteLine("enter announcement you want to see");
                int option = int.Parse(Console.ReadLine());

                Console.WriteLine(announcements[option]);
            }
        }


        public static void removeAnnouncement()
        {
            if (AnnouncementDL.isAnyAnnouncementAvailable() == false )
            {
                Console.WriteLine("no announcement found");
            }
            else
            {
                showAllAnnouncement(false);
                Console.WriteLine("enter announement to remove");
                int option = int.Parse(Console.ReadLine());

                AnnouncementDL.removeAnncouncement(option);
            }
        }

        public static void modifyAnnouncement()
        {
            if (AnnouncementDL.isAnyAnnouncementAvailable() == false)
            {
                Console.WriteLine("no announcement found");
            }
            else
            {
                showAllAnnouncement(false);
                Console.WriteLine("enter announement to modify");
                int option = int.Parse(Console.ReadLine());


                AnnouncementDL.setSpecificAnnoucnemnt(option, takeInputFromUser());
            }
        }

    }
}
