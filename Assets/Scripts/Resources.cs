using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public static Resources instance;
    public string[] resources;
    private float[] values; //A dictionary would work better, but I don't want to write anything custom for the editor...

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        values = new float[resources.Length];
    }

    int GetResourceIndex(string resource)
    {
        for (int i = 0; i < resources.Length; i++)
        {
            string r = resources[i];
            if (r.Equals(resource))
                return i;
        }
        Debug.Log("No such resource in Resource.resources!");
        return -1; //Oof
    }

    public float GetResourceAmount(string resource)
    {
        return values[GetResourceIndex(resource)];
    }

    public void SetResourceAmount(string resource, float amount)
    {
        values[GetResourceIndex(resource)] = amount;
    }

}
