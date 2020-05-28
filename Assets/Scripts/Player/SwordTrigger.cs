using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwordTrigger : MonoBehaviour
{
    public PlayerController PlayerCont;

    public Transform Playertransform;

    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            if (other.GetComponent<EnemyController>().HitCooldown == false) {
                audio.Play();
                other.GetComponent<EnemyController>().Health -= PlayerCont.AttackDamage;
                other.GetComponent<EnemyController>().theHealthBar.value =
                    other.GetComponent<EnemyController>().Health /
                    other.GetComponent<EnemyController>().MaxHealth;
                other.GetComponent<EnemyController>().HitCooldown = true;
                other.GetComponent<EnemyController>();

                //fazer push pa frente ao inimigo
                other.transform.position = Playertransform.position;
            }
        }
    }
}
