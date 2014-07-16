using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AnimeNoFansub : AnimeCreateInterface
{
    private AnimeList instance = AnimeList.getInstance();

    public void createAnimeObject(string path, string title)
    {
        int episodes = AmountOfEpisodes.getSumOfEpisodes(path);
        string img = PathOfImage.getPathOfImage(path);
        string[] mediaFiles = PathOfEpisode.getPathOfEpisode(path);
        string folder = RemoveFullPathFromFolder.getFolder(path);
        string description = Description.readFromFile(Description.getDescription(path));

        char[] split = { '[', ']', '(', ')' };
        string[] animeInfo = folder.Split(split);


        title = title.Replace("_", " ");
        List<string> sourceList = new List<string>();
        List<string> voiceList = new List<string>();
        List<string> subList = new List<string>();
        List<string> fansubList = new List<string>();


        if (animeInfo.Length == 1)
        {
        }
        else if (animeInfo.Length == 2 || animeInfo.Length == 3)
        {
            sourceList.Add(animeInfo[1]);
        }
        else if (animeInfo.Length == 4 || animeInfo.Length == 5)
        {
            sourceList.Add(animeInfo[1]);
            voiceList.Add(animeInfo[3]);
        }
        else if (animeInfo.Length == 7)
        {
            sourceList.Add(animeInfo[1]);
            voiceList.Add(animeInfo[3]);
            subList.Add(animeInfo[5]);
        }

        if (title.First() == ' ')                           //Check if the first character is a space then remove it
        {
            title = title.Substring(1, title.Count()-1);
        }

        if (!instance.checkIfAnimeIsAlreadyInTheList(title))
        {
            instance.addAnimeToList(title, episodes, description, fansubList, sourceList, subList, voiceList, img, mediaFiles);
        }
        else
        {

            instance.addSourceToAnime(title, sourceList[0]);
            instance.addVoiceOutputToAnime(title, voiceList);
            instance.addSubToAnime(title, subList);
            instance.addImgPath(title, img);
        }

    }

}
