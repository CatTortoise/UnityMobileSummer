using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LocationMarker _marker;

    void Update()
    {
        Touch[] touches = Input.touches;
        foreach (Touch touch in touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 vec = _mainCamera.ScreenToWorldPoint(touch.position);
                _marker.transform.position = new Vector3(vec.x, vec.y, 0);
                _marker.ChangeLocation(_marker.transform.position);
            }
        }
    }
}
