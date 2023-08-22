using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public ApplePool pool;

    [System.Serializable]
    public class ApplePool
    {
        public string tag;
        public GameObject ApplePrefab;
        public int maxApples;
    }

    public static ProjectileController Instance;

    private void Awake()
    {
        Instance = this;
    }

    //To use this object pool use
    //ProjectileController.Instance.SpawnFromPool(tag, position, rotation)

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        Queue<GameObject> appleQueue = new Queue<GameObject>();

        for (int i = 0; i < pool.maxApples; i++)
        {
            GameObject apple = Instantiate(pool.ApplePrefab);
            apple.SetActive(false);
            appleQueue.Enqueue(apple);
        }

        poolDictionary.Add(pool.tag, appleQueue);
    }

    public void SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool with tag " + tag + " doesn't exist");
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);
    }
}
