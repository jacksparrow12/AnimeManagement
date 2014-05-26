using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class Parser
{

    private string[] fileEntries;
    private List<Anime> animeList = new List<Anime>();
    private string path;
    private static Parser parser = new Parser();

    public static Parser getInstance()
    {
        return parser;
    }

    /*
     * The folders within a path are extrected.
     */
    public void processDirectory(string path)
    {
        this.path = path;
        try
        {
            fileEntries = Directory.GetDirectories(path);
            removeDirectoryFromPath();
        }
        catch (DirectoryNotFoundException e)
        {
            Console.Write("{0} ", e.Message);
        }
    }


    /*
     * Returns all folders with full path.
     */
    public string[] getFileEntries()
    {
        return fileEntries;
    }

    /*
     * Returns the path;
     */
    public string getPath()
    {
        return path;
    }


    /*
     * Returns the anime list.
     */
    public List<Anime> getAnimeList()
    {
        return animeList;
    }

    /*
     * The parser makes from each folder an anime object and adds it to the list.
     */
    public void parseDirToAnime()
    {
        foreach (string anime in fileEntries)
        {
            animeList.Add(new Anime(anime, 0, "", "", "", "", ""));
        }
    }

    /*
     * The full path from the entries are removed to get just the folder names.
     */
    public void removeDirectoryFromPath()
    {
        for (int i = 0; i < fileEntries.Length; i++)
        {
            fileEntries[i] = fileEntries[i].Remove(0, path.Length + 1);
        }
    }

    public static void Main(string[] args)
    {
        Parser test = Parser.getInstance();
        test.processDirectory("C:\\Users\\ipek\\Desktop\\testfolder");
        test.parseDirToAnime();

        foreach (Anime anime in test.getAnimeList())
        {
            Console.WriteLine("{0} ", anime.getTitle());
        }

    }


}