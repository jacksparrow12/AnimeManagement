﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class Parser
{

    private string[] dirEntries;
    private static Parser instance = new Parser();

    public static Parser getInstance()
    {
        return instance;
    }

    /*
     * The folders within a path are extrected.
     */
    public void processDirectory(string path, int depth, string title)
    {
        try
        {
            dirEntries = Directory.GetDirectories(path);        //Get all folders in path
            foreach (string dir in dirEntries)
            {
                if (depth < 1)
                {
                    processDirectory(dir, 1, RemoveFullPathFromFolder.getFolder(dir));             //Go one directory deeper
                }
                else if (depth == 1)
                {
                    String dire = RemoveFullPathFromFolder.getFolder(dir);                      //Cut the full path to get the folder name for checking the first character of the folder to know if fansub exists
                    char firstChar = dire[0];
                    if (firstChar == '[' || firstChar == '(')                                           //Folders which starts with '[' or '(' will be parsed to the corresponding Object
                    {

                        AnimeCreateInterface tmp = (AnimeCreateInterface)HashMap.getInstance().getMap()["WithFansub"];
                        tmp.createAnimeObject(dir, title);
                    }
                    else
                    {
                        AnimeCreateInterface tmp = (AnimeCreateInterface)HashMap.getInstance().getMap()["NoFansub"];
                        tmp.createAnimeObject(dir, title);
                    }
                }
               
            }
        }
        catch (DirectoryNotFoundException e)
        {
            Console.Write("{0} ", e.Message);
        }
    }

}