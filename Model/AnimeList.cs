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
        Anime output;
        animeList.TryGetValue(title, out output);
        output.addFansub(fansub);
        animeList[title] = output;
    }

    /*
     * Add source to an Anime.
     */
    public void addSourceToAnime(string title, string source)
    {
        Anime output;
        animeList.TryGetValue(title, out output);
        output.addSource(source);
        animeList[title] = output;
    }

    /*
     * Add sub to an Anime.
     */
    public void addSubToAnime(string title, List<string> subList)
    {
        Anime output;
        animeList.TryGetValue(title, out output);
        output.addSub(subList);
        animeList[title] = output;

    }

    /*
     * Add voice output to an Anime.
     */
    public void addVoiceOutputToAnime(string title, List<string> voiceOutputList)
    {
        Anime output;
        animeList.TryGetValue(title, out output);
        output.addVoiceOutput(voiceOutputList);
        animeList[title] = output;
    }

    public Dictionary<string, Anime> getAnimeList()
    {
        return animeList;
    }

    public void printAllEntries()
    {
        foreach (Anime anime in animeList.Values)
        {
            Console.WriteLine(anime);
        }
    }


}

