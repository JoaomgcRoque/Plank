using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelDam : MonoBehaviour
{
    private void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy") {
            other.GetComponent<EnemyController>().Health = 0f;
        }

        if (other.tag == "Player") {
            other.GetComponent<PlayerController>().Health = 0f;
        }
    }
}
