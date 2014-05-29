using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AnimeNoFansub : AnimeCreateInterface
{
    private AnimeList instance = AnimeList.getInstance();

    public void createAnimeObject(string path)
    {
        int episodes = AmountOfEpisodes.getSumOfEpisodes(path);
        string folder = RemoveFullPathFromFolder.getFolder(path);

        char[] split = { '[', ']', '(', ')' };
        string[] animeInfo = folder.Split(split);


        string title = "";
        List<string> sourceList = new List<string>();
        List<string> voiceList = new List<string>();
        List<string> subList = new List<string>();

        if (animeInfo.Length == 1)
        {
            title = animeInfo[0];
        }
        else if (animeInfo.Length == 2)
        {
            title = animeInfo[0];
            sourceList.Add(animeInfo[1]);
        }
        else if (animeInfo.Length == 4)
        {
            title = animeInfo[0];
            sourceList.Add(animeInfo[1]);
            voiceList.Add(animeInfo[3]);
        }
        else if (animeInfo.Length == 7)
        {     
            title = animeInfo[0];
            sourceList.Add(animeInfo[1]);
            voiceList.Add(animeInfo[3]);
            subList.Add(animeInfo[5]);
        }

        if (!instance.checkIfAnimeIsAlreadyInTheList(title))
        {
            instance.addAnimeToList(title, episodes, "no description", null, sourceList, subList, voiceList, "no path image");
        }
        else
        {

            instance.addSourceToAnime(title, sourceList[0]);
            instance.addVoiceOutputToAnime(title, voiceList);
            instance.addSubToAnime(title, subList);
        }

    }

}
