//Plex Rename tool for tv shows and anime v1.0
//Author: Tim Ruble
using System;
using System.IO;
using System.Linq;

namespace PlexRename
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int seasonCount;
            int episodesPerSeason = 0;

            Console.WriteLine("Welcome to the Plex Formatting tool!\n" +
                "Please input the Folder path, Show name, season count, episodes per season.\n" +
                "Then the files will be updated to the plex format of \"ShowName - S01E01\".\n\n");

            Console.WriteLine("Enter Folder Path: ");
            string dir = Console.ReadLine();
            string[] filesList = Directory.GetFiles(dir);
            //string[] filteredFileList = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".mp3") || s.EndsWith(".jpg"));

            var files = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".avi") || s.EndsWith(".mp4") || s.EndsWith(".mkv"));
            //string[] filteredFiles = FilterFileList(filesList); Need to create function for filtering list to just AVI, MP4, and MKV file types
            string ext = Path.GetExtension(filesList[0]); //Store file extension

            Console.WriteLine("Enter Name of Show: "); //Add API check to find show on tvdb or something similar
            string mediaName = Console.ReadLine();

            Console.WriteLine("How many seasons are in this location?"); //Add which seasons question next to determine if all seasons are present in one location or not
            seasonCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Do all seasons have the same amount of episodes? (y//n)");
            string jaggedCheck = Console.ReadLine();
            if (jaggedCheck[0] == 'y' || jaggedCheck[0] == 'Y')
            {
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
                        layout[x, y] = dir + "\\" + mediaName + " - S0" + (x + 1) + "E0" + (y + 1) + ext;
                        Console.WriteLine(layout[x, y]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
            }
            //for (int x = 0; x < seasonCount; x++)
            //{
            //    for (int y = 0; y < episodesPerSeason; y++)
            //    {
            //        System.IO.File.Move(filesList[x + y], layout[x, y]);
            //    }
            //}

            string[] newfiles = Directory.GetFiles(dir);
            //Output Current Name and new Name
            foreach (string file in newfiles)
                Console.WriteLine(Path.GetFileName(file));
        }

        private static string[,] SeasonLayoutStandard(int seasonCount, int episodesPerSeason)
        {
            string[,] layout = new string[seasonCount, episodesPerSeason];
            for (int x = 0; x < seasonCount; x++)
            {
                for (int y = 0; y < episodesPerSeason; y++)
                {
                    if (y + 1 < 10)
                    {
                        layout[x, y] = "0" + Convert.ToString(y + 1);
                    }
                    else
                        layout[x, y] = Convert.ToString(y + 1);
                }
            }
            return layout;
        }

        private static string[][] SeasonLayoutJagged(int seasonCount, int[] episodesPerSeason)
        {
            string[][] jaggedSeasonLayout = new string[seasonCount][];
            for (int x = 0; x < seasonCount; x++)
            {
                jaggedSeasonLayout[x] = new string[episodesPerSeason[x]];
            }

            for (int x = 0; x < jaggedSeasonLayout.Length; x++)
            {
                for (int y = 0; y < jaggedSeasonLayout[x].Length; y++)
                {
                    if (y + 1 < 10)
                    {
                        jaggedSeasonLayout[x][y] = "0" + Convert.ToString(y + 1);
                    }
                    else
                        jaggedSeasonLayout[x][y] = Convert.ToString(y + 1);
                }
            }
            return jaggedSeasonLayout;
        }
    }
}