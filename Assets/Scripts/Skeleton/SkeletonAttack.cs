using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    public GameObject Skeleton;

    [SerializeField] private EnemyController enemycontroller;
    public AudioSource hitsound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Skeleton.GetComponent<EnemyController>().Attacked == true && Skeleton.GetComponent<EnemyController>().AttackCooldown == false)
        {
            if (enemycontroller.GetComponent<EnemyController>().Health > 0) {
                other.GetComponent<PlayerController>().Health -= Skeleton.GetComponent<EnemyController>().AttackDamage;
                other.GetComponent<PlayerController>().HealthBar.value =
                    other.GetComponent<PlayerController>().Health /
                    other.GetComponent<PlayerController>().MaxHealth;
                Skeleton.GetComponent<EnemyController>().AttackCooldown = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Skeleton.GetComponent<EnemyController>().Attacked == true && Skeleton.GetComponent<EnemyController>().AttackCooldown == false)
        {
            if (enemycontroller.GetComponent<EnemyController>().Health > 0) {
                hitsound.Play();
                other.GetComponent<ChangeColor>().change = true;
                other.GetComponent<PlayerController>().Health -= Skeleton.GetComponent<EnemyController>().AttackDamage;
                other.GetComponent<PlayerController>().HealthBar.value =
                    other.GetComponent<PlayerController>().Health /
                    other.GetComponent<PlayerController>().MaxHealth;
                Skeleton.GetComponent<EnemyController>().AttackCooldown = true;
            }
        }
    }
}
