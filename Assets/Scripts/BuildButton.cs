using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{ //This is a button for constructing buildings

    public BuildingData building;
    public Button button;
    public Text text;
    public static BuildingConstructor constructor;

    public void Init()
    { //Called after the button is created and its fields are assigned
        text.text = building.buildingName;
        if (constructor == null)
            constructor = GameObject.Find("Managers").GetComponent<BuildingConstructor>();
    }

    public void SetClickable(bool clickable)
    {
        if (clickable)
            button.interactable = true;
        else
            button.interactable = false;
    }

    public void Clicked()
    { //The logic that must be done when the Button Component is clicked
        constructor.StartBuildingPlacement(building);
    }
}
