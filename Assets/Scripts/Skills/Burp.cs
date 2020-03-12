using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burp : MonoBehaviour
{
    [SerializeField] private PlayerController PlayerCont;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            //Destroy(other);
            if (other.GetComponent<EnemyController>().HitCooldown == false) {
                other.GetComponent<EnemyController>().Health -= PlayerCont.AttackDamage;
                other.GetComponent<EnemyController>().theHealthBar.value =
                    other.GetComponent<EnemyController>().Health /
                    other.GetComponent<EnemyController>().MaxHealth;
                other.GetComponent<EnemyController>().HitCooldown = true;
            }
        }

    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy") {
            //Destroy(other);
            if (other.GetComponent<EnemyController>().HitCooldown == false) {
                other.GetComponent<EnemyController>().Health -= PlayerCont.AttackDamage;
                other.GetComponent<EnemyController>().theHealthBar.value =
                    other.GetComponent<EnemyController>().Health /
                    other.GetComponent<EnemyController>().MaxHealth;
                other.GetComponent<EnemyController>().HitCooldown = true;
            }
        }

    }
}
