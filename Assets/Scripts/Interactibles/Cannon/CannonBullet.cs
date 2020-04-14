using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform Allign;
    [SerializeField] private float force;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletTimeLife;


    private void Start() {
        Allign = GetComponentInParent<Transform>();
        rigidbody.AddForce(Allign.transform.forward * force);
        StartCoroutine(BulletDestruction(bulletTimeLife));
    }

    private void Update() {
        Allign = GameObject.Find("shoot").transform;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            Destroy(bullet);
            other.GetComponent<EnemyController>().Health = 0f;
        }

        if (other.tag == "Player") {
            Destroy(bullet);
            other.GetComponent<PlayerController>().Health = 0f;
        }

        if (other.tag == "Obstacle") {
            Destroy(bullet);
        }
    }

    IEnumerator BulletDestruction(float bulletTimeLife) {
        yield return new WaitForSeconds(bulletTimeLife);
        Destroy(bullet);
        StopCoroutine(BulletDestruction(bulletTimeLife));
    }
}
