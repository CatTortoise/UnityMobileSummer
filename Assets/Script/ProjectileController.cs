using UnityEngine;
using UnityEngine.Pool;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Apple _applePrefab;
    [SerializeField] private Transform _appleLaunchPoint;
    [SerializeField] private int _applesCount = 10;
    private ObjectPool<Apple> _applePool;

    private void Awake()
    {
        InstantiateApplePool();
    }

    public Apple Throw(Vector2 launchDirection)
    {
        Apple apple = _applePool.Get();
        var startPosition = _appleLaunchPoint.position;
        apple.Init(startPosition, launchDirection, OnRelease);
        return apple;
    }

    private void OnRelease(Apple apple)
    {
        _applePool.Release(apple);
    }

    private void InstantiateApplePool()
    {
        _applePool = new ObjectPool<Apple>(
            createFunc: () => Instantiate(_applePrefab),
            actionOnGet: apple => apple.gameObject.SetActive(true),
            actionOnRelease: apple => apple.gameObject.SetActive(false),
            actionOnDestroy: apple => Destroy(apple.gameObject),
            defaultCapacity: _applesCount);
    }
}
