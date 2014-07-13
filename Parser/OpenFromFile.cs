using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class OpenFromFile
{
    private static OpenFromFile instance = new OpenFromFile();
    AnimeList animeList = AnimeList.getInstance();

    public static OpenFromFile getInstance()
    {
        return instance;
    }


    public void readAnimesFromFile(string path)
    {
        using(StreamReader reader = new StreamReader(path))
        {
            string line;
            char[] delims = {'#'};
            while((line  = reader.ReadLine())!=null)
            {
                 string[] entries = line.Split(delims);
            }

        }

    }

    public List<Anime> buildListFromStringArray()
    {
        return null;
    }

}

