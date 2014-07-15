using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class SaveToFile
{

    private AnimeList animeList = AnimeList.getInstance();
    private static SaveToFile instance = new SaveToFile();

    public static SaveToFile getInstance()
    {
        return instance;
    }

    public void saveAnimeListToFile(string path)
    {
        using (StreamWriter writer = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
        {
            foreach (Anime anime in animeList.getAnimeList().Values)
            {
                writer.Write(anime.getTitle() + "#" + anime.buildStringOfFansubs() + "#" + anime.getEpisode() + "#" + anime.buildStringOfSub() + "#" + anime.buildStringOfVoice() + "#" + anime.buildStringOfSource() + "#" + anime.getDescription() + "#" + anime.getPathImg() + "§\n");
            }
        }

    }
}

