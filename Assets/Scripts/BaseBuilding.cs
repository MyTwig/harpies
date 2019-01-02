using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour
{
    //Buildings are data driven, so the ResourceChanger determines what the building actually does, and this class is really just a data holder.

    public string buildingName; //For use in checking construction requirements and so on
    public ResourceChanger rChanger; //If it has a changer, this is the reference for it.

    //What area on the grid does it take up?
    public Vector2Int topleft, bottomRight, dimensions;

    public BuildRules rules; //The rules that must be met for this building to be placeable

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
