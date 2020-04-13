using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RumBarrelRum : MonoBehaviour
{
    [SerializeField] private float newdamage;
    [SerializeField] private float newspeed;
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyController>().AttackDamage =
                other.gameObject.GetComponent<EnemyController>().AttackDamage = newdamage;
            other.gameObject.GetComponent<NavMeshAgent>().speed =
                other.gameObject.GetComponent<NavMeshAgent>().speed = newspeed;
        }
    }
}
