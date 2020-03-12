using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Transform MainCamera;
    public TextMeshPro NameText;
    public TextMeshPro HealthText;
    public SwordAttack SwordAtt;
    public Slider HealthBar;
    public Slider theHealthBar;
    public GameObject LookRange;
    private Vector2 ScreenPosition;

    public float MaxHealth = 2f;
    public float Health;
    public float AttackDamage = 0.5f;
    public bool Attacked = false;
    public bool HitCooldown = false;
    public bool AttackCooldown = false;
    public float InvisibleFrames = 1.5f;
    public float Timer;

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
        Timer = InvisibleFrames;
    }

    void Update()
    {
        // Enemy Health UI
        HealthText.text = Health.ToString();
        HealthText.transform.rotation = Quaternion.LookRotation(transform.position - MainCamera.position);
        // Enemy Name UI
        NameText.transform.rotation = Quaternion.LookRotation(transform.position - MainCamera.position);

        ScreenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0f, 3f, 0f));

        if (theHealthBar != null)
            theHealthBar.transform.position = ScreenPosition;

        float distance = Vector3.Distance(target.position, transform.position);

        if (gameObject.GetComponent<NavMeshAgent>() != null)
            agent.SetDestination(target.position);

        if (HitCooldown)
            if (SwordAtt.AttackTimer <= 0)
                HitCooldown = false;

        if (AttackCooldown)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                AttackCooldown = false;
                Timer = InvisibleFrames;
            }
        }

        // Enemy Death
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

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }
}
