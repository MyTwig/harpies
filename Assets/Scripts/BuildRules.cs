using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class BuildRules
{ //These will be created in JSON and used to determine whether a building can be built

    [Serializable]
    public class ResourcePair
    {
        public string resourceName;
        public float amount;
    }

    [Serializable]
    public class MapRequirement
    {
        public string mapString; //Check this flag
        public bool requiredFlagState; //Checks to make sure flag matches this bool value

    }

    [Serializable]
    public class TerrainRequirement
    {
        TileInfo.Terrain terrain; //The terrain enum that each tile in the construction area must match
    }

    public ResourcePair[] resourcesNeeded; //Every entry in here must be fulfilled or construction can't take place
    public ResourcePair[] consumedResources; //If construction can happen, these resources are sucked from Resources.resources
    public MapRequirement[] mapRequirements; //Every item here must be met for construction to happen

    public TerrainRequirement terrainRequirement; //If this is not null, then the BuildingPlacer will use this to ensure the building is only on tiles of this type

    public static bool CheckResourcesNeeded(BuildRules rules)
    {
        if (rules.resourcesNeeded == null) //If there isn't an array here, then no resources are required
            return true;
        else
        {
            for (int i = 0; i < rules.resourcesNeeded.Length; i++)
            { //Loop through every resource in the array and exit early if we haven't met a condition
                ResourcePair pair = rules.resourcesNeeded[i];
                if (Resources.instance.GetResourceAmount(pair.resourceName) < pair.amount)
                    return false;
            }
            return true;
        }
    }
    public static bool CheckMapRequirements(BuildRules rules)
    {
        if (rules.mapRequirements == null)
            return true; //There are no map requirements, so this succeeds
        else
        {
            for (int i = 0; i < rules.mapRequirements.Length; i++)
            { //Loop through every flag requirement and exit early if it isn't set to the required value
                MapRequirement pair = rules.mapRequirements[i];
                if (MapGrid.flags.GetFlagValue(pair.mapString) != pair.requiredFlagState)
                    return false;
            }
            return true;
        }
    }

}
