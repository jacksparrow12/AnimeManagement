using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class OpenFromFile
{
    private static OpenFromFile instance = new OpenFromFile();
    private ParserAnimeFromFile parserInstance = new ParserAnimeFromFile();
    private AnimeList animeList = AnimeList.getInstance();

    public static OpenFromFile getInstance()
    {
        return instance;
    }


    public void readAnimesFromFile(string path)
    {
        using(StreamReader reader = new StreamReader(path))
        {
            string animeInformation = "";
            char tmp;
            while (!reader.EndOfStream)
            {
                tmp = (char)reader.Read();
                switch (tmp)
                {
                    case '\n':
                        {
                            break;
                        }
                    case '§':
                        {
                            parserInstance.parserAnimeFromFile(animeInformation);
                            animeInformation = "";
                            break;
                        }
                    default:
                        {
                            animeInformation += tmp;
                            break;           
                        }
                }
            }
            reader.Close();
        }

    }

    public List<Anime> buildListFromStringArray()
    {
        return null;
    }

}

