using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CollisionObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private float _minImpactForce = 5;
    [SerializeField] private int _deleteTimeParticle = 2;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float impactForce = collision.impulse.magnitude;

        if (impactForce > _minImpactForce)
        {
            _audio.Play();
            ParticleSystem particle = Instantiate(_particle, collision.transform.position, Quaternion.identity);
            particle.Play();
            Destroy(particle.gameObject, _deleteTimeParticle);
        }
    }
}
