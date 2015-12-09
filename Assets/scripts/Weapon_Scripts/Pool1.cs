using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool1
{
    Object prefab;
    List<GameObject> objects = new List<GameObject>();

    public Pool1(Object prefab, int poolSize)
    {
        this.prefab = prefab;

        //spawn poolsize prefabs
        for (int i = 0; i < poolSize; ++i)
        {
            CreateNew();
        }
    }

    public GameObject Spawn()
    {
        for (int i = 0; i < objects.Count; ++i)
        {
            if (!objects[i].activeInHierarchy)
            {
                objects[i].SetActive(true);
                return objects[i];
            }
        }

        GameObject obj = CreateNew();
        obj.SetActive(true);
        return obj;
    }

    GameObject CreateNew()
    {
        GameObject obj = GameObject.Instantiate(prefab) as GameObject;
        objects.Add(obj);
        obj.SetActive(false);
        return obj;
    }
}


