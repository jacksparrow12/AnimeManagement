using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


class AnimeList
{
    private Dictionary<string, Anime> animeList = new Dictionary<string, Anime>();
    private static AnimeList instance = new AnimeList();
    private AnimeList() {}
    public static AnimeList getInstance()
    {
        return instance;
    }


    /*
     *Add an Anime to list. 
     */
    public void addAnimeToList(string title, int episode, string description, List<string> fansub, List<string> source, List<string> sub, List<string> voiceOutput, string pathImg)
    {
        animeList.Add(title, new Anime(title, episode, description, fansub, source, sub, voiceOutput, pathImg));
    }

    /*
     *Check if Anime is already in the list.
     *Returns true if available.
     */
    public Boolean checkIfAnimeIsAlreadyInTheList(string title)
    {
        return animeList.ContainsKey(title);
    }

    /*
     *Add fansub to an Anime.
     */
    public void addFansubToAnime(string title, string fansub)
    {
        animeList[title].addFansub(fansub);
    }

    /*
     * Add source to an Anime.
     */
    public void addSourceToAnime(string title, string source)
    {
        animeList[title].addSource(source);
    }

    /*
     * Add sub to an Anime.
     */
    public void addSubToAnime(string title, List<string> subList)
    {
        animeList[title].addSub(subList);
    }

    /*
     * Add voice output to an Anime.
     */
    public void addVoiceOutputToAnime(string title, List<string> voiceOutputList)
    {
        animeList[title].addVoiceOutput(voiceOutputList);
    }
    /*
     *Add img path if no image path is available 
     */
    public void addImgPath(string title, string imgPath)
    {
        if(animeList[title].getPathImg().Equals("no cover"))    //Check if no image path is set
        {
            animeList[title].setPathImg(imgPath);               //Set if no image path was set
        }
        
    }

    /*
     * Get all animes
     */
    public Dictionary<string, Anime> getAnimeList()
    {
        return animeList;
    }


    /*
     *Get title of all anime. 
     */
    public String[] getAllTitle()
    {
        string[] list = new string[animeList.Count];
        int counter = 0;
        foreach (Anime anime in animeList.Values)
        {
            list[counter++] = anime.getTitle();
        }

        return list;
    }

    /*
     *Get all anime titles 
     */
    public Anime getAnimeByTitle(string title)
    {
        return animeList[title];
    }

}

