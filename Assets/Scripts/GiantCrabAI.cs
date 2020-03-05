using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GiantCrabAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private bool isJump = false;
    [SerializeField] private float time;
    [SerializeField] private Vector3 target;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        StartCoroutine(CoolDown(time));
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<EnemyController>().AttackCooldown = true;
            gameObject.GetComponent<EnemyController>().Attacked = false;
            gameObject.GetComponent<NavMeshAgent>().speed = 0f;
            gameObject.GetComponent<NavMeshAgent>().destination = player.transform.position;
            gameObject.GetComponentInChildren<MeshRenderer>().material = gameObject.GetComponent<EnemyController>().Orange;
            yield return StartCoroutine("Wait");
            isJump = true;
            gameObject.GetComponent<NavMeshAgent>().speed = 5f;
            yield return StartCoroutine("Wait");
            gameObject.GetComponent<NavMeshAgent>().speed = 1.5f;
            gameObject.GetComponent<EnemyController>().Attacked = true;
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<EnemyController>().AttackCooldown == false && other.tag == "Player")
        {
            if (gameObject.GetComponent<EnemyController>().Attacked == true)
            {
                gameObject.GetComponentInChildren<MeshRenderer>().material = gameObject.GetComponent<EnemyController>().Red;
                other.GetComponent<PlayerController>().Health -= gameObject.GetComponent<EnemyController>().AttackDamage;
                other.GetComponent<PlayerController>().HealthBar.value =
                    other.GetComponent<PlayerController>().Health /
                    other.GetComponent<PlayerController>().MaxHealth;
                gameObject.GetComponent<EnemyController>().AttackCooldown = true;
                gameObject.GetComponent<EnemyController>().Attacked = false;
            }
            else
            {
                if (other.tag == "Player" && isJump == false)
                {
                    gameObject.GetComponent<NavMeshAgent>().speed = 0f;
                    gameObject.GetComponent<NavMeshAgent>().destination = player.transform.position;
                    gameObject.GetComponentInChildren<MeshRenderer>().material = gameObject.GetComponent<EnemyController>().Orange;
                    yield return StartCoroutine("Wait");
                    isJump = true;
                    gameObject.GetComponent<NavMeshAgent>().speed = 5f;
                    yield return StartCoroutine("Wait");
                    gameObject.GetComponent<NavMeshAgent>().speed = 1.5f;
                    gameObject.GetComponent<EnemyController>().Attacked = true;
                }
            }
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<EnemyController>().AttackCooldown = true;
            gameObject.GetComponent<EnemyController>().Attacked = false;
            yield return StartCoroutine("Wait");
            gameObject.GetComponent<NavMeshAgent>().speed = 1.5f;
            gameObject.GetComponentInChildren<MeshRenderer>().material = gameObject.GetComponent<EnemyController>().White;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        isJump = false;
    }
}
