using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class AnimeWithFansub : AnimeCreateInterface
{

    public Anime createAnimeObject(string path)
    {
        int episodes = AmountOfEpisodes.getSumOfEpisodes(path);
        string folder = RemoveFullPathFromFolder.getFolder(path);

        char[] split = {'[', ']' , '(', ')'};
        string[] animeInfo = folder.Split(split);
        string fansub = animeInfo[0];
        string title = animeInfo[1].Replace('_', ' ');
        string tmp = animeInfo[2].ToUpper();
        List<string> voiceOutput = new List<string>();
        string source = "";
        if (tmp.Contains("GER") || tmp.Contains("ENG") || tmp.Contains("JPN"))
        {
            if (tmp.Contains("GER"))
            {
                voiceOutput.Add("German");
            }
            else if (tmp.Contains("ENG"))
            {
                voiceOutput.Add("English");
            }
            else if (tmp.Contains("JPN"))
            {
                voiceOutput.Add("Japanese");
            }
        }
        else
        {
            if (tmp.Contains("1080p"))
            {
                source = "BluRay";
            }
        }


    }

}
