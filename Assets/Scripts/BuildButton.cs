using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{ //This is a button for constructing buildings

    public BaseBuilding building;
    public Button button;
    public Text text;

    public void Init()
    { //Called after the button is created and its fields are assigned
        text.text = building.buildingName;
    }

    public void SetClickable(bool clickable)
    {
        if (clickable)
            button.interactable = true;
        else
            button.interactable = false;
    }
}
