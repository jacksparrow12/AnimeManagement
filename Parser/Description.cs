using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class Description
{
    public static string getDescription(string path)
    {
        string[] fileEntries = Directory.GetFiles(path);
        foreach(string entry in fileEntries)
        {
            if (entry.Contains("txt"))
            {
                return entry;
            }
        }

        return "no description";
    }

    public static string readFromFile(string path)
    {
        if (!path.Contains("no description"))
        {
            string description = "";
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                byte[] b = new byte[1000];
                Encoding tmp = Encoding.GetEncoding(1252);      //character encoding for latin alphabet
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    description += tmp.GetString(b);
                }
            }
            return description;
        }
        else
        {
            return "no description";
        }
    }
}

