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
        pistol = GameObject.Find("gun").GetComponent<Transform>();
        rigidbody.AddForce(pistol.transform.forward * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().Health -= gameObject.GetComponent<EnemyController>().AttackDamage;
            other.GetComponent<PlayerController>().HealthBar.value =
                other.GetComponent<PlayerController>().Health /
                other.GetComponent<PlayerController>().MaxHealth;
            Destroy(bullet);
        }
    }
}
