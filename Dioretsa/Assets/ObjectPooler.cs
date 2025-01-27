using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }

    private Queue<GameObject> objectPool = new Queue<GameObject>();
    public int initialPoolSize = 1000;

    public GameObject objectPrefab;

    void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        PopulateInitialPool();
    }


    public void PopulateInitialPool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject prefab = InstantiateNewObject();
            prefab.SetActive(true);
            objectPool.Enqueue(prefab);
        }
    }

    public GameObject GetObject()
    {
        GameObject prefab;
        if (objectPool.Count > 0)
        {
            prefab = objectPool.Dequeue();
        }
        else
        {
            prefab = InstantiateNewObject();
        }
        prefab.SetActive(true);
        return prefab;
    }

    public void ReturnObject(GameObject prefab)
    {
        prefab.SetActive(false);
        objectPool.Enqueue(prefab);
    }


    private GameObject InstantiateNewObject()
    {
        GameObject prefab = Instantiate(objectPrefab);
        prefab.SetActive(false);
        return prefab;
    }


}