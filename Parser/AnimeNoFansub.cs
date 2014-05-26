using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AnimeNoFansub : AnimeCreateInterface
{
    public void createAnimeObject(string path)
    {
        int episodes = AmountOfEpisodes.getSumOfEpisodes(path);
        string folder = RemoveFullPathFromFolder.getFolder(path);

    }

}
