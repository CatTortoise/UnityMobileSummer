using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LocationMarker _marker;
    private bool isEnemy = false;
    private const string ENEMY = "Enemy";

    public bool IsEnemy { get => isEnemy; private set => isEnemy = value; }

    void Update()
    {
        Touch[] touches = Input.touches;
        foreach (Touch touch in touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 vec = _mainCamera.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit2D = Physics2D.Raycast(vec, Vector2.zero, Mathf.Infinity);
                _marker.transform.position = new Vector3(vec.x, vec.y, 0);
                _marker.ChangeLocation(_marker.transform.position);
                Collider2D hitCollider = hit2D.collider;
                if (hitCollider != null && hitCollider.isTrigger == true) 
                {
                    IsEnemy = (hitCollider.tag == ENEMY);
                }
            }
        }
    }

    public void IsEnemyReset()
    {
        if (isEnemy)
        {
            IsEnemy = false;
        }
    }


}
