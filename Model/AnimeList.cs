using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


class AnimeList
{
    private Dictionary<string, Anime> animeList = new Dictionary<string, Anime>();
    private static AnimeList instance = new AnimeList();
    public AnimeList() { }
    public static AnimeList getInstance()
    {
        return instance;
    }

    /*
     *Add an Anime to list. 
     */
    public void addAnimeToList(string title, int episode, string description, List<string> fansub, List<string> source, List<string> sub, List<string> voiceOutput, string pathImg, string[] mediaFiles)
    {
        animeList.Add(title, new Anime(title, episode, description, fansub, source, sub, voiceOutput, pathImg, mediaFiles));
    }

    public void addAnimeToList(Anime anime)
    {
        animeList.Add(anime.getTitle(), anime);
    }

    public void addAnimeToList(AnimeList filteredList)
    {
        for (int i = 0; i < filteredList.getAllTitle().Count(); i++)
        {
            if (!animeList.ContainsKey(filteredList.getAnimeList().Values.ToArray()[i].getTitle()))
            {
                animeList.Add(filteredList.getAnimeList().Values.ToArray()[i].getTitle(), filteredList.getAnimeList().Values.ToArray()[i]);
            }

        }
    }

    public void addAnimeToList(Dictionary<string, Anime> filteredList)
    {
        foreach (KeyValuePair<string, Anime> list in filteredList)
        {
            animeList.Add((string)list.Key, list.Value);
        }
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
        if (animeList[title].getPathImg().Equals("no cover"))    //Check if no image path is set
        {
            animeList[title].setPathImg(imgPath);               //Set if no image path was set
        }

    }

    public void addMediaFiles(string title, string[] mediaFiles)
    {
        animeList[title].setPathOfEpisode(mediaFiles);
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

    /*
     *Get all anime titles ordered by alphabet
     */
    public String[] getSortedAllTitle()
    {
        var titleList = animeList.Keys.ToList();
        titleList.Sort();
        return titleList.ToArray();
    }

    public void clearList()
    {
        animeList.Clear();
    }

    /*
     *return anime with german subtitle
     */
    public AnimeList getGerSubAnime()
    {
        AnimeList gerSubAnime = new AnimeList();
        foreach (Anime anime in animeList.Values)
        {
            if (anime.getSub().Count != 0)
            {
                foreach (String sub in anime.getSub())
                {
                    if (sub.Contains("Ger") || sub.Contains("German") || sub.Contains("GER") || sub.Contains("deutsch"))
                    {
                        gerSubAnime.addAnimeToList(anime);
                    }
                }
            }
        }

        return gerSubAnime;
    }

    /*
     *return anime with english subtitle
     */
    public AnimeList getEngSubAnime()
    {
        AnimeList engSubAnime = new AnimeList();
        foreach (Anime anime in animeList.Values)
        {
            if (anime.getSub().Count != 0)
            {
                foreach (String sub in anime.getSub())
                {
                    if (sub.Contains("Eng") || sub.Contains("English") || sub.Contains("ENG") || sub.Contains("englisch"))
                    {
                        engSubAnime.addAnimeToList(anime);
                    }
                }
            }

        }

        return engSubAnime;
    }


    /*
     * 
     * return german dub anime
     */
    public AnimeList getGerDubAnime()
    {
        AnimeList gerDubAnime = new AnimeList();
        foreach (Anime anime in animeList.Values)
        {
            if (anime.getVoiceOutput().Count != 0)
            {
                foreach (String dub in anime.getVoiceOutput())
                {
                    if (dub.Contains("Ger") || dub.Contains("German") || dub.Contains("GER") || dub.Contains("deutsch"))
                    {
                        gerDubAnime.addAnimeToList(anime);
                    }
                }
            }
        }
        return gerDubAnime;
    }


    /*
     * return english dub anime
     */
    public AnimeList getEngDubAnime()
    {
        AnimeList engDubAnime = new AnimeList();
        foreach (Anime anime in animeList.Values)
        {
            if (anime.getVoiceOutput().Count != 0)
            {
                foreach (String dub in anime.getVoiceOutput())
                {
                    if (dub.Contains("Eng") || dub.Contains("English") || dub.Contains("ENG") || dub.Contains("englisch"))
                    {
                        engDubAnime.addAnimeToList(anime);
                    }
                }
            }

        }
        return engDubAnime;
    }


    /*
     *return japanese dub anime
     */
    public AnimeList getJapDubAnime()
    {
        AnimeList japDubAnime = new AnimeList();
        foreach (Anime anime in animeList.Values)
        {
            if (anime.getVoiceOutput().Count != 0)
            {
                foreach (String dub in anime.getVoiceOutput())
                {
                    if (dub.Contains("Jap") || dub.Contains("Japanese") || dub.Contains("Jap") || dub.Contains("japanisch"))
                    {
                        japDubAnime.addAnimeToList(anime);
                    }
                }
            }
        }
        return japDubAnime;
    }

    public void removeAnimeWhichIsNotInTheList(AnimeList filteredList)
    {
        var list = animeList.Keys.Intersect(filteredList.getAnimeList().Keys);
        List<string> keys = new List<string>();
        foreach (KeyValuePair<string, Anime> entry in animeList)
        {
            if(!list.Contains(entry.Key))
            {
                keys.Add(entry.Key);
            }
        }

        foreach (string key in keys)
        {
            animeList.Remove(key);
        }
          
    }
}

