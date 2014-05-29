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