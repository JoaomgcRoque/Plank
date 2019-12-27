using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Transform MainCamera;
    public TextMeshPro Text;
    public SwordAttack SwordAtt;

    public float lookRadius = 10f;
    public float Health = 2f;
    public bool HitCooldown = false;

    Transform target;
    NavMeshAgent agent;
    
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        Text.text = Health.ToString();
        Text.transform.rotation = Quaternion.LookRotation(transform.position - MainCamera.position);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && agent)
        {
            agent.SetDestination(target.position);
        }

        if (HitCooldown)
            if (SwordAtt.AttackTimer <= 0)
                HitCooldown = false;

        if (Health <= 0f)
        {
            GetComponent<Animator>().SetBool("Dead", true);
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponentInChildren<TextMeshPro>());
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
