using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class BuildingCollection : MonoBehaviour
{ //This class is for managing the construction panel
    //It also holds all deserialized building templates

    static List<BuildingData> allBuildings;

    BuildingData[] buildings;
    List<BuildButton> buttons = new List<BuildButton>();

    public GameObject buttonPrefab;
    public RectTransform panel;

    private void Start()
    {

        BuildingCollection.allBuildings = JsonConvert.DeserializeObject<List<BuildingData>>(Resources.Load<TextAsset>("JSON/Buildings").ToString());
        SetupBuildList();
    }

    public void SetupBuildList()
    { //Adds all of the buildings to the list and enables clicking on ones that the player can build
        buildings = BuildingCollection.GetAllBuildings();
        for (int i = 0; i < buildings.Length; i++)
        {
            BuildingData building = buildings[i];
            building.Init();
            GameObject buttonObject = GameObject.Instantiate(buttonPrefab);
            buttonObject.transform.SetParent(panel.transform, false);
            BuildButton buttonComp = buttonObject.GetComponent<BuildButton>();
            buttonComp.building = building;
            buttonComp.button = buttonObject.GetComponent<Button>();
            buttonComp.SetClickable(building.CheckBuildable()); //Set the button to enabled or disabled depending on if the building requirements are met
            buttonComp.Init();
            buttons.Add(buttonComp);
        }
    }

    public void CheckBuildable()
    { //Used to update the buttons to reflect if the buildings can be constructed or not
        for (int i = 0; i < buttons.Count; i++)
        {
            BuildButton button = buttons[i];
            button.SetClickable(button.building.CheckBuildable());
        }
    }

    void Awake()
    {
        
    }

    public static void AddNewBuilding(BuildingData b)
    { //This is called after the building is created from a JSON file
        allBuildings.Add(b);
    }

    public static BuildingData[] GetAllBuildings()
    {
        //Returns the contents of allBuildings as a new reference so the static field cant be changed in another class
        return allBuildings.ToArray();
    }

}
