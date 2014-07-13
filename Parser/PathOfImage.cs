using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class PathOfImage
{

    public static String getPathOfImage(String path)
    {
        string[] fileEntries = Directory.GetFiles(path);
        foreach(string entry in fileEntries)
        {
            if(entry.Contains(".png") || entry.Contains(".jpg"))
            {
                return entry;
            }
        }
        return "no cover";
    }

    public static bool checkIfImgIsAvailable(String path)
    {
        string[] fileEntries = Directory.GetFiles(path);
        foreach (string entry in fileEntries)
        {
            if (entry.Contains(".png") || entry.Contains(".jpg"))
            {
                return true;
            }
        }
        return false;
    }
}

