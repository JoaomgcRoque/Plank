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

    [SerializeField] private Animator modelanimation;
    [SerializeField] private LevelManager levelmanager;

    Transform target;
    NavMeshAgent agent;

    public Transform Enemy;
    [SerializeField] private AudioSource[] audiosources;

    private void Awake() {
        foreach (AudioSource audio in audiosources) {
            GetComponent<AudioSource>();
        }
    }

    void Start()
    {
        //levelmanager = GetComponent<LevelManager>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        Health = MaxHealth;
        ScreenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0f, 3f, 0f));
        theHealthBar = Instantiate(HealthBar, ScreenPosition, Quaternion.identity,
            GameObject.Find("Canvas").transform);
        theHealthBar.value = CalculateHealth();
        Timer = InvisibleFrames;
    }

    void Update() {
        CheckGround();
        // Enemy Health UI
        HealthText.text = Health.ToString();
        HealthText.transform.rotation = Quaternion.LookRotation(transform.position - MainCamera.position);
        // Enemy Name UI
        if (NameText != null)
            { 
        NameText.transform.rotation = Quaternion.LookRotation(transform.position - MainCamera.position);
            }

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
            modelanimation.GetComponent<Animator>().enabled = false;
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponentInChildren<TextMeshPro>());
            if (theHealthBar != null)
                levelmanager.GetComponent<LevelManager>().numberofdead += 1;
            Destroy(theHealthBar.gameObject);
        }
    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

    private void CheckGround() {
        if(Enemy.transform.position.y > 10) {
            foreach (AudioSource audio in audiosources) {
                audio.mute = true;
            }
        }
        else {
            foreach (AudioSource audio in audiosources) {
                audio.mute = false;
            }
        }
    }

}
