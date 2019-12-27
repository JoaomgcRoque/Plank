using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Transform MainCamera;
    public TextMeshPro Text;
    public SwordAttack SwordAtt;
    public Slider HealthBar;
    public Slider theHealthBar;
    private Vector2 ScreenPosition;

    public float lookRadius = 10f;
    public float MaxHealth = 2f;
    public float Health;
    public bool HitCooldown = false;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        Health = MaxHealth;
        ScreenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0f, 3f, 0f));
        theHealthBar = Instantiate(HealthBar, ScreenPosition, Quaternion.identity,
            GameObject.Find("Canvas").transform);
        theHealthBar.value = CalculateHealth();
    }

    void Update()
    {
        Text.text = Health.ToString();
        Text.transform.rotation = Quaternion.LookRotation(transform.position - MainCamera.position);

        ScreenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0f, 3f, 0f));

        if (theHealthBar != null)
            theHealthBar.transform.position = ScreenPosition;

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
            if (theHealthBar != null)
                Destroy(theHealthBar.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }
}
