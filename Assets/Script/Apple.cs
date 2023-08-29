using System;
using System.Collections;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private float _throwForce;
    [SerializeField] private Rigidbody2D _projectileRigidbody;
    [SerializeField] private Action<Apple> _onRelease;

    private void OnEnable()
    {
        StartCoroutine(DestroyAfter(5));
    }
    
    public void Init(Vector2 start, Vector2 direction, Action<Apple> onRelease)
    {
        _onRelease = onRelease;
        gameObject.transform.position = start;
        _projectileRigidbody.AddForce(direction.normalized * _throwForce, ForceMode2D.Impulse);
    }
    
    private IEnumerator DestroyAfter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _onRelease(this);
    }

    private void OnValidate()
    {
        _projectileRigidbody = GetComponent<Rigidbody2D>();
    }
}
