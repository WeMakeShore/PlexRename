//Plex Rename tool for tv shows and anime v1.0
//Author: Tim Ruble
using System;
using System.IO;

namespace PlexRename
{
    class Program
    {
        static void Main(string[] args)
        {
            int seasonCount;
            int episodesPerSeason = 0;

            Console.WriteLine("Welcome to the Plex Formatting tool!\n" +
                "Please input the Folder path, Show name, season count, episodes per season.\n" +
                "Then the files will be updated to the plex format of \"ShowName - S01E01\".\n\n");
            
            Console.WriteLine("Enter Folder Path: ");
            string dir = Console.ReadLine();
            Console.WriteLine(dir);
            string[] files = Directory.GetFiles(dir);
            string ext = Path.GetExtension(files[0]);
            Console.WriteLine("Enter Name of Show: ");
            string mediaName = Console.ReadLine();
            Console.WriteLine("How many seasons are in this location?");
            seasonCount = Convert.ToInt32(Console.ReadLine());
            if (seasonCount > 1)
            {
                    Console.WriteLine("How many episodes are there in each season?");
                    episodesPerSeason = Convert.ToInt32(Console.ReadLine());

            }
            else
            {
                Console.WriteLine("How many episodes are there in the season?");
                episodesPerSeason = Convert.ToInt32(Console.ReadLine());
            }

            string[,] layout = SeasonLayoutStandard(seasonCount, episodesPerSeason);

            Console.WriteLine("\n\nThe new names for the files are as follows:");
            for (int x = 0; x < seasonCount; x++)
            {
                Console.WriteLine("Season {0}: ", x + 1);
                for (int y = 0; y < episodesPerSeason; y++)
                {
                    layout[x, y] = dir + "\\" +  mediaName + " - S0" + (x + 1) + "E0" + (y + 1) + ext;
                    Console.WriteLine(layout[x, y]);
                    //Console.WriteLine("{0} - S0{1}E{2}", mediaName, x + 1, y + 1);
                }
                Console.WriteLine();
            }

            for (int x = 0; x < seasonCount; x++)
            {
                for (int y = 0; y < episodesPerSeason; y++)
                {
                    System.IO.File.Move(files[x + y], layout[x, y]);
                }
            }

            string[] newfiles = Directory.GetFiles(dir);
            ////Output Current Name and new Name
            foreach (string file in newfiles)
                Console.WriteLine(Path.GetFileName(file));
        }

        private static string[,] SeasonLayoutStandard(int seasonCount, int episodesPerSeason)
        {
                string[,] layout = new string[seasonCount,episodesPerSeason];
                for(int x = 0; x < seasonCount; x++)
                {
                    for(int y = 0; y < episodesPerSeason; y++)
                    {
                        layout[x, y] = Convert.ToString(y + 1);
                    }
                }
            return layout;
        }
        
        static int[][] SeasonLayoutJagged(int seasonCount, int[] episodesPerSeason)
        {
            int[][] jaggedSeasonLayout = new int[seasonCount][];
            for(int x = 0; x < seasonCount; x++)
            {
                jaggedSeasonLayout[x] = new int[episodesPerSeason[x]];
            }

            for (int x = 0; x < seasonCount; x++)
            {
                for (int y = 0; y < episodesPerSeason[x]; y++)
                {
                    //incomplete
                }
            }
            return jaggedSeasonLayout;
        }
    }
}
