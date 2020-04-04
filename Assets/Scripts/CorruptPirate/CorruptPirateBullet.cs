using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptPirateBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform Allign;
    [SerializeField] private float force;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        Allign = GetComponentInParent<Transform>();
        rigidbody.AddForce(Allign.transform.forward * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().Health -= 2f;
            other.GetComponent<PlayerController>().HealthBar.value =
                other.GetComponent<PlayerController>().Health /
                other.GetComponent<PlayerController>().MaxHealth;
            Destroy(bullet);
        }
        if(other.tag == "Obstacle") {
            Destroy(bullet);
        }
    }
}
