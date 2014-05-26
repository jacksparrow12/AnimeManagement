using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class Parser
{

    private string[] dirEntries;
    private List<Anime> animeList = new List<Anime>();
    private static Parser instance = new Parser();

    public static Parser getInstance()
    {
        return instance;
    }

    /*
     * The folders within a path are extrected.
     */
    public void processDirectory(string path, int depth)
    {
        try
        {
            dirEntries = Directory.GetDirectories(path);        //Get all folders in path
            foreach (string dir in dirEntries)
            {
                if (depth < 1)
                {
                    processDirectory(dir, depth++);             //Go one directory deeper
                }
                else if (depth == 1)
                {
                    char firstChar = dir[0];
                    if (firstChar == '[' || firstChar == '(')                                           //Folders which starts with '[' or '(' will be parsed to the corresponding Object
                    {
                        Object output;
                        HashMap.getInstance().getMap().TryGetValue("WithFansub", out output);
                        AnimeCreateInterface tmp = (AnimeCreateInterface)output;
                        tmp.createAnimeObject(dir);
                    }
                    else
                    {
                        Object output;
                        HashMap.getInstance().getMap().TryGetValue("NoFansub", out output);
                        AnimeCreateInterface tmp = (AnimeCreateInterface)output;
                        tmp.createAnimeObject(dir);
                    }
                }

            }
        }
        catch (DirectoryNotFoundException e)
        {
            Console.Write("{0} ", e.Message);
        }
    }

    /*
     * Returns all folders with full path.
     */
    public string[] getDirEntries()
    {
        return dirEntries;
    }

    /*
     * Returns the anime list.
     */
    public List<Anime> getAnimeList()
    {
        return animeList;
    }

}