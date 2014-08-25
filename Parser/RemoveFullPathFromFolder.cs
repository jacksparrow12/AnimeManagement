using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class RemoveFullPathFromFolder
{
    private static RemoveFullPathFromFolder instance = new RemoveFullPathFromFolder();
    private List<string> pathOfEpisode = new List<string>();
    public static RemoveFullPathFromFolder getInstance()
    {
        return instance;
    }


    public static string getFolder(string path)
    {
        char[] delim = { '\\' };
        return path.Split(delim).Last();
    }

    /*
     *Add full path to media file
     */
    public string getPathOfEpisode(string file)
    {
        foreach (string entry in pathOfEpisode)
        {
            if (entry.Contains(file)) return entry;
        }

        return "";
    }

    /*
     *Remove full path from all media files
     *Store the parent directory of the media files to a variable
     *return media files without the full path
     */
    public String[] removeFullPathFromFiles(string[] file)
    {
        string[] mediaFiles = new string[file.Length];
        for (int i = 0; i < file.Length; i++)
        {
            pathOfEpisode.Add(file[i]);
        }

        char[] delim = { '\\' };
        for (int i = 0; i < file.Length; i++)
        {
            mediaFiles[i] = file[i].Split(delim).Last();
        }
        return mediaFiles;
    }

}
