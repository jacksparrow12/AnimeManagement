using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ParserAnimeFromFile
{
    private AnimeList animeList = AnimeList.getInstance();
    private static ParserAnimeFromFile instance = new ParserAnimeFromFile();
    public ParserAnimeFromFile getInstance()
    {
        return instance;
    }

    public void parserAnimeFromFile(string anime)
    {
        char[] delim = { '#' };
        string[] animeInfo = anime.Split(delim);
        string title = animeInfo[0];
        string[] tmpFansub = animeInfo[1].Split(',');
        List<string> fansub = arrayToList(tmpFansub);
        int episode = Convert.ToInt32(animeInfo[2]);
        string[] tmpSub = animeInfo[3].Split(',');
        List<string> sub = arrayToList(tmpSub);
        string[] tmpDub = animeInfo[4].Split(',');
        List<string> dub = arrayToList(tmpDub);
        string[] tmpSource = animeInfo[5].Split(',');
        List<string> source = arrayToList(tmpSource);
        string description = animeInfo[6];
        string img = animeInfo[7];
        if (!animeList.checkIfAnimeIsAlreadyInTheList(title))
        {
            animeList.addAnimeToList(title, episode, description, fansub, source, sub, dub, img);

        }

    }

    public List<string> arrayToList(string[] info)
    {
        List<string> tmp = new List<string>();
        for (int i = 0; i < info.Count(); i++)
        {
            tmp.Add(info[i]);
        }

        return tmp;
    }

}

