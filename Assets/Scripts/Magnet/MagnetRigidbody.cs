using System.Collections.Generic;
using UnityEngine;

public class MagnetRigidbody : MonoBehaviour
{
    [SerializeField] private float _magnetForce = 100f;
    [SerializeField] private float _speedDrop = 10f;
    private List<Rigidbody> caughtRigidbodies = new List<Rigidbody>();
    public static bool IsMagnet = false;


    private void Update()
    {
        if (Input.GetKeyDown(SettingsTransitions.DataSettings.PlayerControlKeyCode[9]) && IsMagnet == false)
        {
            IsMagnet = true;
        }
        else if (Input.GetKeyDown(SettingsTransitions.DataSettings.PlayerControlKeyCode[9]) && IsMagnet)
        {
            IsMagnet = false;
        }
        else if (Input.GetKeyDown(SettingsTransitions.DataSettings.PlayerControlKeyCode[10]) && IsMagnet)
        {
            IsMagnet = false;
            Drop();
        }
    }

    void FixedUpdate()
    {
        if (IsMagnet && LiftNDrop.IsLift == false)
        {
            foreach (Rigidbody rb in caughtRigidbodies)
            {
                if (rb != null)
                {
                    Vector3 direction = transform.position - (rb.transform.position + rb.centerOfMass);
                    rb.linearVelocity = direction * _magnetForce * Time.deltaTime;
                }
            }
        }
    }

    private void Drop()
    {
        foreach (Rigidbody rb in caughtRigidbodies)
        {
            if (rb != null)
            {
                Vector3 direction = (rb.transform.position - gameObject.transform.position).normalized;
                rb.AddForce(direction * _speedDrop, ForceMode.Impulse);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && !caughtRigidbodies.Contains(rb))
        {
            caughtRigidbodies.Add(rb);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && caughtRigidbodies.Contains(rb))
        {
            caughtRigidbodies.Remove(rb);
        }
    }
}
