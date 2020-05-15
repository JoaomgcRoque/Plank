using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider SwordCollider;
    public Animator Anim;

    public bool Attacking = false;
    public float AttackTimer = 0f;
    public float AttackCooldown = 1f;

    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip swordclip;

    void Awake()
    {
        SwordCollider.enabled = false;
        audiosource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        if(Input.GetKeyDown(KeyCode.LeftControl) || (Input.GetKeyDown(KeyCode.Mouse0)))
        {
            Anim.SetBool("Attacking", true);
            audiosource.clip = swordclip;
            audiosource.Play();
            Attacking = true;
            AttackTimer = AttackCooldown;

            SwordCollider.enabled = true;
        }
        if (Attacking)
        {
            if (AttackTimer > 0f)
            {
                AttackTimer -= Time.deltaTime;
            }
            else
            {
                AttackTimer = 0f;
                Anim.SetBool("Attacking", false);
                Attacking = false;
                SwordCollider.enabled = false;
                audiosource.clip = null;
            }
        }
    }
}
