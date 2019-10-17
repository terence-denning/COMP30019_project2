using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dunDestroy 
{
    public static List<GameObject> _ddolObjects = new List<GameObject>();

    public static void DontDestroyOnLoad(GameObject go) {
        UnityEngine.Object.DontDestroyOnLoad(go);
        _ddolObjects.Add(go);
    }

    public static void DestroyAll() {
        foreach(var go in _ddolObjects)
            if(go != null)
                UnityEngine.Object.Destroy(go);

        _ddolObjects.Clear();
    }

    public static void destroy(GameObject go)
    {
        foreach (var Dgo in _ddolObjects)
        {
            if (Dgo.CompareTag(go.tag))
            {
                UnityEngine.Object.Destroy(Dgo);
            }
        }
    }
}
