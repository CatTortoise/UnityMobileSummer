using UnityEngine;

public class LocationMarkerScript : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    public void ChangeLocation(Vector3 newLocation)
    {
        transform.position = newLocation;
        gameObject.SetActive(true);
        particle.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            particle.Stop();
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (particle.isStopped || particle.isPaused)
        {
            gameObject.SetActive(false);
        }
    }
}