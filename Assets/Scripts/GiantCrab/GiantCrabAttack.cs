﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCrabAttack : MonoBehaviour
{
    public GameObject GiantCrab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GiantCrab.GetComponent<EnemyController>().Attacked == true && GiantCrab.GetComponent<EnemyController>().AttackCooldown == false)
        {
            other.GetComponent<PlayerController>().Health -= GiantCrab.GetComponent<EnemyController>().AttackDamage;
            other.GetComponent<PlayerController>().HealthBar.value =
                other.GetComponent<PlayerController>().Health /
                other.GetComponent<PlayerController>().MaxHealth;
            GiantCrab.GetComponent<EnemyController>().AttackCooldown = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && GiantCrab.GetComponent<EnemyController>().Attacked == true && GiantCrab.GetComponent<EnemyController>().AttackCooldown == false)
        {
            other.GetComponent<PlayerController>().Health -= GiantCrab.GetComponent<EnemyController>().AttackDamage;
            other.GetComponent<PlayerController>().HealthBar.value =
                other.GetComponent<PlayerController>().Health /
                other.GetComponent<PlayerController>().MaxHealth;
            GiantCrab.GetComponent<EnemyController>().AttackCooldown = true;
        }
    }
}