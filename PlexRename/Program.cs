using System;
using System.IO;

namespace PlexRename
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Media Renaming tool! Please input the information requested and the files will be updated shortly.");
            Console.WriteLine("Enter Folder Path: ");
            string dir = Console.ReadLine();
            string[] files = Directory.GetFiles(dir);
            Console.WriteLine("Enter Name of Show: ");
            string mediaName = Console.ReadLine();
            Console.WriteLine("Pick a Format:");
            Console.WriteLine("1. " + mediaName + " - S00E00");
            Console.WriteLine("2. " + mediaName + " - E00");
            int format = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many seasons are in this location?");
            int seasonCount = Convert.ToInt32(Console.ReadLine());
            if (seasonCount > 1) {
                Console.WriteLine("Are there the same amount of episodes each season? y/n");
                string equalEpisodes = Console.ReadLine();
                if(equalEpisodes[0] == 'y' || equalEpisodes[0] == 'Y') {
                    Console.WriteLine("How many episodes are there in each season?");
                    int episodesPerSeason = Convert.ToInt32(Console.ReadLine());
                }
                else { 
                
                }
                    }

            //Output Current Name and new Name
            foreach (string file in files)
                Console.WriteLine(Path.GetFileName(file));
        }
    }
}
