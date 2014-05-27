using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class AnimeWithFansub : AnimeCreateInterface
{
    private AnimeList instance = AnimeList.getInstance();

    public void createAnimeObject(string path)
    {
        int episodes = AmountOfEpisodes.getSumOfEpisodes(path);
        string folder = RemoveFullPathFromFolder.getFolder(path);

        char[] split = {'[', ']' , '(', ')'};
        string[] animeInfo = folder.Split(split);
        
        string fansub = animeInfo[0];
        List<string> fansubList = new List<string>();
        fansubList.Add(fansub);
        
        string title = animeInfo[1].Replace('_', ' ');
        string tmp = animeInfo[2].ToUpper();
        List<string> voiceOutput = new List<string>();
        List<string> sub = new List<string>();
        List<string> sourceList = new List<string>();
        string source = "";
        if (tmp.Contains("GERENGJAPDUB") || tmp.Contains("GERJAPDUB") || tmp.Contains("GERDUB"))
        {
            voiceOutput = getVoiceOutput(tmp);
        }else if(tmp.Contains("GERENGSUB") || tmp.Contains("GERSUB") || tmp.Contains("ENGSUB"))
        {
            sub = getSub(tmp);
        }
        else if (tmp.Contains("720P") || tmp.Contains("1080P"))
        {
            source = getSource(tmp);
        }else
        {
            source = "";
        }

        sourceList.Add(source);
        if (!instance.checkIfAnimeIsAlreadyInTheList(title))                                                    //If the anime is not in the list, then add it as new anime.
        {
            instance.addAnimeToList(title, episodes, "", fansubList, sourceList, sub, voiceOutput, "");
        }
        else
        {
            instance.addFansubToAnime(title, fansub);                                                               //If the same anime is already in the list, then add parameters like fansub, source, sub, etc. to the anime.
            instance.addSourceToAnime(title, source);
            instance.addSubToAnime(title, sub);
            instance.addVoiceOutputToAnime(title, voiceOutput);
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
