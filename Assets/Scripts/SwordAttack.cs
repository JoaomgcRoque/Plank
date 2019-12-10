using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider SwordCollider;

    private bool Attacking = false;
    private float AttackTimer = 0f;
    private float AttackCooldown = 1f;

    void Awake()
    {
        SwordCollider.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !Attacking)
        {
            Attacking = true;
            AttackTimer = AttackCooldown;

            SwordCollider.enabled = true;
        }
        if (Attacking)
        {
            if (AttackTimer > 0)
            {
                AttackTimer -= Time.deltaTime;
            }
            else
            {
                Attacking = false;
                SwordCollider.enabled = false;
            }
        }
    }
}
