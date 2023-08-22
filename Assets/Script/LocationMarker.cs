using UnityEngine;

public class LocationMarker : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void ChangeLocation(Vector3 newLocation)
    {
        transform.position = newLocation;
        gameObject.SetActive(true);
        _particleSystem.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _particleSystem.Stop();
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_particleSystem.isStopped || _particleSystem.isPaused)
        {
            gameObject.SetActive(false);
        }
    }

	private void OnValidate()
	{
		_particleSystem = GetComponentInChildren<ParticleSystem>();
	}
}
