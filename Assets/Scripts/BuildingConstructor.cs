using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstructor : MonoBehaviour
{
    //This class creates buildings after we know that the conditions to construct them are met
    //It puts the player in a build mode and manages that state. We will use our raycaster to check the tile under the mouse against any TerrainRequirement
    //Then when you left click it determines if the placement was valid. If it isn't, we exit build mode and display a message on screen, otherwise we create the building

    public GameObject buildingPrefab; //The prefab we are going to populate with our data
    BuildingData data;
    bool placingBuilding, canBuildHere;
    GameObject placeGhost;
    SpriteRenderer ghostRend;

    void Start()
    {
        placeGhost = new GameObject("ghostPlacer");
        ghostRend = placeGhost.AddComponent<SpriteRenderer>();
        ghostRend.sprite = Resources.Load<Sprite>("Art/square"); //Need to change this to a partially transparent verion of finished sprite
        placeGhost.SetActive(false);
    }

    void Update()
    {
        if (placingBuilding)
        { //This checks the tile under the mouse and updates the building ghost
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); pos.z = 0;
            placeGhost.transform.position = pos;
            TileInfo t = TileRaycaster.GetTileAtMouse();
            canBuildHere = false;
            if (t != null)
            { //We can only reason about the tile if there is even a tile there to begin with
                if (data.rules != null)
                { //Make sure this building even has rules
                    if (data.rules.terrainRequirement != null)
                    { //If it does have rules, make sure it has a terrainRequirement to check
                        if (t.TileTerrain == data.rules.terrainRequirement.terrain)
                            canBuildHere = true; //The terrain matches
                        else
                            canBuildHere = false;
                    }
                }
                if (data.rules == null)
                { //If there are no rules, you have met the terrain requirements
                    canBuildHere = true;
                }
                //Even if there are no rules for building this, we still can't place more than one building on a tile
                if (t.hasBuilding)
                {
                    Debug.Log("This tile has a building here, so you may not build here");
                    canBuildHere = false;
                }
            }
            //Lastly, update the color of the ghost
            if (canBuildHere)
                ghostRend.color = Color.green;
            else
                ghostRend.color = Color.red;
            if (Input.GetButtonDown("Fire1"))
            { //We have done all the updates we need for the mouse, but we should check to see if you tried to place it
                if (canBuildHere)
                {
                    CreateBuilding(data);
                }
                FinishBuildingPlacement();
            }
        }
    }

    public void CreateBuilding(BuildingData data)
    {
        GameObject b = GameObject.Instantiate(buildingPrefab);
        b.GetComponent<SpriteRenderer>().sprite = data.buildingSprite; //Make sure the sprite is assigned
        if (data.changeValues != null)
        {
            //We add the changer to the building and then pass it the values we have from the JSON file
            ResourceChanger changer = b.AddComponent<ResourceChanger>();
            changer.values = data.changeValues; 
        }
    }

    public void StartBuildingPlacement(BuildingData d)
    {
        data = d;
        placingBuilding = true;
        placeGhost.SetActive(true);
    }

    public void FinishBuildingPlacement()
    {
        data = null;
        placingBuilding = false;
        placeGhost.SetActive(false);
    }

}
