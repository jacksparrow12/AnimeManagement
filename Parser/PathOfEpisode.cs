using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class PathOfEpisode
{
    public static String[] getPathOfEpisode(string path)
    {
        string[] entries = Directory.GetFiles(path);
        List<string> mediaFiles = new List<string>();
        foreach (string entry in entries)
        {
            if (entry.Contains(".mkv") || entry.Contains(".avi") || entry.Contains(".mp4"))
            {
                mediaFiles.Add(entry);
            }

        }
        return mediaFiles.ToArray();

    }
}

