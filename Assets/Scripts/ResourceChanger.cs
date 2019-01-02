using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceChanger : MonoBehaviour
{
    public string resourceName; //What resource are we changing?
    public float changeAmount; //What value do we change it by after the time has elapsed?
    public float timeFrequency; //How often do we change the value?
    float elapsedTime;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeFrequency)
        {
            elapsedTime = 0;
            Resources.instance.SetResourceAmount(resourceName, Resources.instance.GetResourceAmount(resourceName) + changeAmount);
        }

    }
}
