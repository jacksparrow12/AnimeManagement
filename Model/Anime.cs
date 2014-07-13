using System;
using System.Collections.Generic;

public class Anime
{
    private string title;
    private int episode;
    private string description;
    private List<string> fansub;
    private List<string> source;
    private List<string> sub;
    private List<string> voiceOutput;
    private string pathImg;

    public Anime(string title, int episode, string description, List<string> fansub, List<string> source, List<string> sub, List<string> voiceOutput, string pathImg)
    {
        this.title = title;
        this.episode = episode;
        this.description = description;
        this.fansub = fansub;
        this.source = source;
        this.sub = sub;
        this.voiceOutput = voiceOutput;
        this.pathImg = pathImg;
    }

    public string getTitle()
    {
        return title;
    }

    public void setTitle(string title)
    {
        this.title = title;
    }

    public int getEpisode()
    {
        return episode;
    }

    public void setEpisode(int episode)
    {
        this.episode = episode;
    }

    public string getDescription()
    {
        return description;
    }

    public void setDescription(string description)
    {
        this.description = description;
    }

    public List<string> getFansub()
    {
        return fansub;
    }

    public void setFansub(List<string> fansub)
    {
        this.fansub = fansub;
    }

    public void addFansub(string fansub)
    {
        this.fansub.Add(fansub);
    }

    public String buildStringOfFansubs()
    {
        if (fansub.Count!=0)
        {
            string tmp = "";
            foreach (string fan in fansub)
            {
                tmp += fan+", ";
            }
            tmp = tmp.Remove(tmp.LastIndexOf(","));
            return tmp;
        }
        else
        {
            return "no fansub";
        }
        
    }

    public int getFansubSize()
    {
        if (fansub != null)
        {
            return this.fansub.Count;
        }
        return 0;
    }

    public List<string> getSource()
    {
        return source;
    }

    public void setSource(List<string> source)
    {
        this.source = source;
    }

    public void addSource(string source)
    {
        this.source.Add(source);
    }

    public string buildStringOfSource()
    {
        string tmp = "";
        if (source.Count != 0)
        {
            foreach (string src in source)
            {
                tmp += src + ", ";
            }
            tmp = tmp.Remove(tmp.LastIndexOf(","));
            return tmp;
        }
        else
        {
            return "no source";
        }
    }

    public List<string> getSub()
    {
        return sub;
    }

    public void setSub(List<string> sub)
    {
        this.sub = sub;
    }

    public void addSub(List<string> subList)
    {
        foreach (string sub in subList)
        {
            this.sub.Add(sub);
        }
    }

    public String buildStringOfSub()
    {
        if (this.sub.Count != 0)
        {
            string tmp = "";
            foreach (string sub in this.sub)
            {
                tmp += sub+", ";
            }
            tmp = tmp.Remove(tmp.LastIndexOf(","));
            return tmp;
        }
        else
        {
            return "no subtitle";
        }
    }

    public List<string> getVoiceOutput()
    {
        return voiceOutput;
    }

    public void setVoiceOutput(List<string> voiceOutput)
    {
        this.voiceOutput = voiceOutput;
    }

    public void addVoiceOutput(List<string> voiceOutput)
    {
        foreach (string voice in voiceOutput)
        {
            this.voiceOutput.Add(voice);
        }
     
    }

    public string buildStringOfVoice()
    {
        if (voiceOutput.Count != 0)
        {
            string tmp = "";
            foreach (string voice in voiceOutput)
            {
                tmp += voice + ", ";
            }
            tmp = tmp.Remove(tmp.LastIndexOf(","));
            return tmp;
        }else
        {
            return "no voice";
        }
    }

    public string getPathImg()
    {
        return pathImg;
    }

    public void setPathImg(string pathImg)
    {
        this.pathImg = pathImg;
    }

    public override String ToString()
    {
        return this.title+" "+this.episode+" "+this.description+" "+this.fansub+" "+this.source+" "+this.voiceOutput+" "+this.sub+" "+this.pathImg;
    }

}