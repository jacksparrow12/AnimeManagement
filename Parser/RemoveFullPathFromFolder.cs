using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class RemoveFullPathFromFolder
{
    private static RemoveFullPathFromFolder instance = new RemoveFullPathFromFolder();
    private string path;
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
    public string addFullPathToFile(string file)
    {
        return this.path +"\\"+ file;
    }

    /*
     *Remove full path from all media files
     *Store the parent directory of the media files to a variable
     *return media files without the full path
     */
    public String[] removeFullPathFromFiles(string[] file)
    {
        this.path = Directory.GetParent(file[0]).FullName;
        char[] delim = { '\\' };
        for (int i = 0; i < file.Length; i++)
        {
            file[i] = file[i].Split(delim).Last();
        }
        return file;
    }
}
