using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceChanger : MonoBehaviour
{
    public ResourceChangerValues values;
    float elapsedTime;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= values.timeFrequency)
        {
            elapsedTime = 0;
            HarpyResources.instance.SetResourceAmount(values.resourceName, HarpyResources.instance.GetResourceAmount(values.resourceName) + values.changeAmount);
        }

    }

    [Serializable]
    public class ResourceChangerValues
    {
        public string resourceName; //What resource are we changing?
        public float changeAmount; //What value do we change it by after the time has elapsed?
        public float timeFrequency; //How often do we change the value?
    }
}
