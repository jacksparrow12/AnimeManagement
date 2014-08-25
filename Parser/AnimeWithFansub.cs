using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class AnimeWithFansub : AnimeCreateInterface
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
        string[] animeInfo = folder.Split(split);                   /*Important! When the seperator is at the beginning then an empty element will be added to the array, furthermore when two seperators are one after 
                                                                      then again an empty element will be added, last but not least when a seperator is at the end then again an empty element will be added to the array */

        List<string> fansubList = new List<string>();
        title = title.Replace("_", " ");
        List<string> voiceOutput = new List<string>();
        List<string> sub = new List<string>();
        List<string> sourceList = new List<string>();

        if (animeInfo.Length == 3)
        {
            fansubList.Add(animeInfo[1]);
            
        }
        else if (animeInfo.Length == 4 || animeInfo.Length == 5)
        {
            fansubList.Add(animeInfo[1]);
            sourceList.Add(animeInfo[3]);

        }
        else if (animeInfo.Length == 6 || animeInfo.Length == 7)
        {
            fansubList.Add(animeInfo[1]);
            sourceList.Add(animeInfo[3]);
            if (animeInfo[5].Contains("Sub"))
            {
                sub.Add(animeInfo[5]);
            }
            else
            {
                voiceOutput.Add(animeInfo[5]);
            }
        }
        else if (animeInfo.Length == 9)
        {
            fansubList.Add(animeInfo[1]);
            sourceList.Add(animeInfo[3]);
            voiceOutput.Add(animeInfo[5]);
            sub.Add(animeInfo[7]);
        }


        if (title.First() == ' ')                       //Check if the first character is a space then remove it
        {
            title = title.Substring(1, title.Count()-1);
        }

        if (!instance.checkIfAnimeIsAlreadyInTheList(title))                                                    //If the anime is not in the list, then add it as new anime.
        {
            instance.addAnimeToList(title, episodes, description, fansubList, sourceList, sub, voiceOutput, img, mediaFiles);
        }
        else
        {
            instance.addFansubToAnime(title, fansubList.First());                                                               //If the same anime is already in the list, then add parameters like fansub, source, sub, etc. to the anime.
            if (sourceList.Count != 0)
            {
                instance.addSourceToAnime(title, sourceList.First());
            }
            instance.addSubToAnime(title, sub);
            instance.addVoiceOutputToAnime(title, voiceOutput);
            instance.addImgPath(title, img);
            instance.addMediaFiles(title, mediaFiles);

        }

    }

    /*
     *Determine the different voice output.
     *Return list of voice output.
     */
    public List<string> getVoiceOutput(string voice)
    {
        List<string> voiceList = new List<string>();
        if (voice.Contains("GER"))
        {
            voiceList.Add("German");
        }
        else if (voice.Contains("ENG"))
        {
            voiceList.Add("English");
        }
        else
        {
            voiceList.Add("Japanese");
        }

        return voiceList;
    }

    /*
     *Determine the subs.
     *Return list of sub;
     */
    public List<string> getSub(string sub)
    {
        List<string> subList = new List<string>();
        if (sub.Contains("GER"))
        {
            subList.Add("German");
        }
        else
        {
            subList.Add("English");
        }
        return subList;
    }

    /*
     *Determine the source of the Anime.
     *Return source.
     */
    public string getSource(string source)
    {
        if (source.Contains("1080P"))
        {
            return "BluRay";
        }
        else
        {
            return "TV";
        }
    }

}
