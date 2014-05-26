using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;


    class AmountOfEpisodes
    {

        public static int getSumOfEpisodes(string path)
        {
            int counter = 0;
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string entry in fileEntries)
            {
                if (entry.Contains(".mkv") || entry.Contains(".avi") || entry.Contains(".mp4"))
                {
                    counter++;
                }
            }

            return counter;
        }


    }

