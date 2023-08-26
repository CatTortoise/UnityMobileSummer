using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public ApplePool pool;
    [SerializeField] private Transform _playerProjectileMarker;
    [SerializeField] private Transform _playerMarker;

    [System.Serializable]
    public class ApplePool
    {
        public string tag;
        public GameObject ApplePrefab;
        public int maxApples;
        //public Projectile projectile;
        public Rigidbody2D AppleRigidbody2D;
    }

    public static ProjectileController Instance;

    private void Awake()
    {
        Instance = this;
    }

    //To use this object pool use
    //ProjectileController.Instance.SpawnFromPool(tag, position, rotation)

    public Dictionary<string, Queue<ApplePool>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<ApplePool>>();

        Queue<ApplePool> appleQueue = new Queue<ApplePool>();

        for (int i = 0; i < pool.maxApples; i++)
        {
            GameObject apple = Instantiate(pool.ApplePrefab);
            ApplePool applePool = new();
            apple.SetActive(false);

            applePool.tag = pool.tag;
            applePool.ApplePrefab = apple;
            applePool.maxApples = pool.maxApples;
            appleQueue.Enqueue(applePool);
        }

        poolDictionary.Add(pool.tag, appleQueue);
    }

    public void SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool with tag " + tag + " doesn't exist");
        }

        ApplePool objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.ApplePrefab.SetActive(true);
        objectToSpawn.ApplePrefab.transform.position = _playerProjectileMarker.position;
        objectToSpawn.ApplePrefab.transform.rotation = _playerProjectileMarker.rotation;
        
        /* if (_playerMarker.position.x > _playerProjectileMarker.position.x)
        {
            objectToSpawn.projectile.rigidbody2DAddForce(Projectile.Direction.right);
        }
        else
        {
            objectToSpawn.projectile.rigidbody2DAddForce(Projectile.Direction.Left);
        }*/
        poolDictionary[tag].Enqueue(objectToSpawn);
    }


}
