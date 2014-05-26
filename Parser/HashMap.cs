using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class HashMap
{
    private Dictionary<string, Object> map = new Dictionary<string, object>();
    private static HashMap instance = new HashMap();
    
    private HashMap()
    {
        map.Add("NoFansub", new AnimeNoFansub());
        map.Add("WithFansub", new AnimeWithFansub());
    }

    public static HashMap getInstance()
    {
        return instance;
    }

    public Dictionary<string, Object> getMap()
    {
        return map;
    }

}

