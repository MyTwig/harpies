using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingCollection : MonoBehaviour
{ //This class is for managing the construction panel

    public List<BaseBuilding> allBuildings = new List<BaseBuilding>();
    List<BuildButton> buttons = new List<BuildButton>();

    public GameObject buttonPrefab;
    public RectTransform panel;

    public void SetupBuildList()
    { //Adds all of the buildings to the list and enables clicking on ones that the player can build
        for (int i = 0; i < allBuildings.Count; i++)
        {
            BaseBuilding building = allBuildings[i];
            GameObject buttonObject = GameObject.Instantiate(buttonPrefab);
            buttonObject.transform.SetParent(panel.transform);
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

}
