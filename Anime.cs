using System;

public class Anime
{
    private string title;
    private int episode;
    private string description;
    private string fansub;
    private string source;
    private string sub;
    private string voiceOutput;

    public Anime(string title, int episode, string description, string fansub, string source, string sub, string voiceOutput)
    {
        this.title = title;
        this.episode = episode;
        this.description = description;
        this.fansub = fansub;
        this.source = source;
        this.sub = sub;
        this.voiceOutput = voiceOutput;
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

    public string getFansub()
    {
        return fansub;
    }

    public void setFansub(string fansub)
    {
        this.fansub = fansub;
    }

    public string getSource()
    {
        return source;
    }

    public void setSource(string source)
    {
        this.source = source;
    }

    public string getSub()
    {
        return sub;
    }

    public void setSub(string sub)
    {
        this.sub = sub;
    }

    public string getVoiceOutput()
    {
        return voiceOutput;
    }

    public void setVoiceOutput(string voiceOutput)
    {
        this.voiceOutput = voiceOutput;
    }


}