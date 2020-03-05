using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform pistol;
    [SerializeField] private float force;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        pistol = GameObject.Find("pistol").GetComponent<Transform>();
        rigidbody.AddForce(pistol.transform.forward * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(bullet);
        }
    }
}
