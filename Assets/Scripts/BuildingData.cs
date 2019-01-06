using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingData
{
    //Buildings are data driven, so the ResourceChanger determines what the building actually does, and this class is really just a data holder.

    public string buildingName; //For use in checking construction requirements and so on
    public ResourceChanger.ResourceChangerValues changeValues; //Define the values for the changer in JSON since we can't make a new MonoBehaviour from JSON
    public Sprite buildingSprite;
    public string spritePath; //Define this in the JSON file so it can load its sprite when created

    //What area on the grid does it take up?
    public Vector2Int topleft, bottomRight, dimensions;

    public BuildRules rules; //The rules that must be met for this building to be placeable

    public void Init()
    {
        buildingSprite = Resources.Load<Sprite>(spritePath);
    }

    public bool CheckBuildable()
    {
        if (rules != null)
        {
            bool mapRequirements = BuildRules.CheckMapRequirements(rules);
            bool resourceRequirements = BuildRules.CheckResourcesNeeded(rules);
            if (mapRequirements && resourceRequirements)
                return true;
            else
                return false;
        }
        return true;
    }
}
