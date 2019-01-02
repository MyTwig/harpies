using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFlags
{ //A collection of all the flags that BuildRules/anything else may need to know about the map

    public class FlagPair
    {
        public FlagPair() { }
        public FlagPair(string flagName, bool value)
        {
            Flag = flagName;
            Value = value;
        }
        public string Flag;
        public bool Value;
    }

    public List<FlagPair> mapFlags = new List<FlagPair>();
    
    public FlagPair GetFlagPair(string flagName)
    {
        for (int i = 0; i < mapFlags.Count; i++)
        {
            FlagPair p = mapFlags[i];
            if (p.Flag.Equals(flagName))
                return p;
        }
        Debug.Log("No such flag exists!");
        return null;
    }

    public bool GetFlagValue(string flagName)
    {
        return GetFlagPair(flagName).Value;
    }

    public void AddFlag(string flag, bool startValue)
    {
        mapFlags.Add(new FlagPair(flag, startValue));
    }

    public void RemoveFlag(string flag)
    {
        mapFlags.Remove(GetFlagPair(flag));
    }

    public void SetFlag(string flag, bool value)
    {
        FlagPair flagPair = GetFlagPair(flag);
        if (flagPair == null)
            AddFlag(flag, value);
        else
            flagPair.Value = value;
    }
}
