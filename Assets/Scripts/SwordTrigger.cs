using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwordTrigger : MonoBehaviour
{
    public PlayerController PlayerCont;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<EnemyController>().HitCooldown == false)
            {
                other.GetComponent<EnemyController>().Health -= PlayerCont.AttackDamage;
                other.GetComponent<EnemyController>().HitCooldown = true;
            }
        }
    }
}
