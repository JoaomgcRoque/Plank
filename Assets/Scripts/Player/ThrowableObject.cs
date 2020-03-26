using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    [SerializeField] private PlayerController PlayerCont;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform lefthand;
    [SerializeField] private float force;
    [SerializeField] private GameObject throwable;

    private void Start() {
        PlayerCont = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        lefthand = GameObject.Find("left_hand").GetComponent<Transform>();
        rigidbody.AddForce(lefthand.transform.forward * force);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            Destroy(throwable);
            if (other.GetComponent<EnemyController>().HitCooldown == false) {
                other.GetComponent<EnemyController>().Health -= PlayerCont.AttackDamage;
                other.GetComponent<EnemyController>().theHealthBar.value =
                    other.GetComponent<EnemyController>().Health /
                    other.GetComponent<EnemyController>().MaxHealth;
                other.GetComponent<EnemyController>().HitCooldown = true;
            }
        }
        if(other.tag == "Obstacle") {
            Destroy(throwable);
        }
    }
}
