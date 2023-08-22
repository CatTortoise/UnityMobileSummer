using UnityEngine;

public class InputMenager : MonoBehaviour
{
    [SerializeField] Camera mineCamra;
    [SerializeField] GameObject gameObject;
    [SerializeField] LocationMarkerScript marker;

    void Update()
    {
        Touch[] touches = Input.touches;
        foreach (Touch touch in touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				Vector3 vec = mineCamra.ScreenToWorldPoint(touch.position);
				gameObject.transform.position = new Vector3(vec.x, vec.y, 0);
				marker.ChangeLocation(gameObject.transform.position);
			}
		}
    }
}
