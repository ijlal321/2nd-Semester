using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace BusinessApplication.DL
{
    class AnnouncementDL
    {
        static List<string> announcements = new List<string>();

        public static void addIntoList(string announcement)
        {
            announcements.Add(announcement);
        }

        public static List<string> getAnnouncements()
        {
            return announcements;
        }

        public static bool isAnyAnnouncementAvailable()
        {
            if (announcements.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static void removeAnncouncement(int option)
        {
            announcements.RemoveAt(option);
        }

        public static void setSpecificAnnoucnemnt(int option, string announcement)
        {
            announcements[option] = announcement;
        }

        public static void storeintoFile(string path)
        {
            StreamWriter f = new StreamWriter(path, append: false);
            foreach (string announcement in announcements)
            {
                f.WriteLine(announcement);
            }
            f.Flush();
            f.Close();
        }

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    AnnouncementDL.addIntoList(record);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
