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
    public GameObject LookRange;
    public GameObject AttackRange;
    public Material White;
    public Material Orange;
    public Material Red;
    private Vector2 ScreenPosition;

    public float MaxHealth = 2f;
    public float Health;
    public float AttackDamage = 0.5f;
    public bool Attacking = false;
    public bool Attacked = false;
    public bool HitCooldown = false;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        AttackRange.SetActive(false);
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

        agent.SetDestination(target.position);

        if (HitCooldown)
            if (SwordAtt.AttackTimer <= 0)
                HitCooldown = false;

        if (Attacking)
            AttackRange.SetActive(true);
        else
            AttackRange.SetActive(false);

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

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<EnemyController>().Attacking = true;
            gameObject.GetComponentInChildren<MeshRenderer>().material = Orange;
            yield return StartCoroutine("Wait");
            gameObject.GetComponent<EnemyController>().Attacked = true;
            gameObject.GetComponent<EnemyController>().Attacking = false;
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerController>().HitCooldown == false && gameObject.GetComponent<EnemyController>().Attacked == true)
            {
                gameObject.GetComponentInChildren<MeshRenderer>().material = Red;
                other.GetComponent<PlayerController>().Health -= AttackDamage;
                other.GetComponent<PlayerController>().HealthBar.value =
                    other.GetComponent<PlayerController>().Health /
                    other.GetComponent<PlayerController>().MaxHealth;
                other.GetComponent<PlayerController>().HitCooldown = true;
                gameObject.GetComponent<EnemyController>().Attacked = false;
            }
            else
            {
                gameObject.GetComponent<EnemyController>().Attacking = true;
                gameObject.GetComponentInChildren<MeshRenderer>().material = Orange;
                yield return StartCoroutine("Wait");
                gameObject.GetComponent<EnemyController>().Attacked = true;
                gameObject.GetComponent<EnemyController>().Attacking = false;
            }
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return StartCoroutine("Wait");
            gameObject.GetComponent<EnemyController>().Attacked = false;
            gameObject.GetComponent<EnemyController>().Attacking = false;
            gameObject.GetComponentInChildren<MeshRenderer>().material = White;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
