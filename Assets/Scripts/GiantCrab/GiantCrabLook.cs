using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GiantCrabLook : MonoBehaviour
{
    public GameObject GiantCrab;
    [SerializeField] private Transform player;
    [SerializeField] private bool isJump = false;
    [SerializeField] private float time;

    private void FixedUpdate()
    {
        StartCoroutine(CoolDown(time));
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GiantCrab.GetComponent<NavMeshAgent>() != null)
                GiantCrab.GetComponent<NavMeshAgent>().speed = 0f;
            if (GiantCrab.GetComponent<NavMeshAgent>() != null)
                GiantCrab.GetComponent<NavMeshAgent>().destination = player.transform.position;
            yield return StartCoroutine("Wait");
            isJump = true;
            if (GiantCrab.GetComponent<NavMeshAgent>() != null)
                GiantCrab.GetComponent<NavMeshAgent>().speed = 5f;
            yield return StartCoroutine("Wait");
            if (GiantCrab.GetComponent<NavMeshAgent>() != null)
                GiantCrab.GetComponent<NavMeshAgent>().speed = 1.5f;
            GiantCrab.GetComponent<EnemyController>().Attacked = true;
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (GiantCrab.GetComponent<EnemyController>().AttackCooldown == false && other.tag == "Player" && GiantCrab.GetComponent<NavMeshAgent>() != null)
        {
            if (GiantCrab.GetComponent<EnemyController>().Attacked == true)
            {
                GiantCrab.GetComponent<EnemyController>().AttackCooldown = false;
            }
            else
            {
                if (other.tag == "Player" && isJump == false)
                {
                    if (GiantCrab.GetComponent<NavMeshAgent>() != null)
                        GiantCrab.GetComponent<NavMeshAgent>().speed = 0f;
                    if (GiantCrab.GetComponent<NavMeshAgent>() != null)
                    GiantCrab.GetComponent<NavMeshAgent>().destination = player.transform.position;
                    yield return StartCoroutine("Wait");
                    isJump = true;
                    if (GiantCrab.GetComponent<NavMeshAgent>() != null)
                        GiantCrab.GetComponent<NavMeshAgent>().speed = 5f;
                    yield return StartCoroutine("Wait");
                    if (GiantCrab.GetComponent<NavMeshAgent>() != null)
                        GiantCrab.GetComponent<NavMeshAgent>().speed = 1.5f;
                    GiantCrab.GetComponent<EnemyController>().Attacked = true;
                }
            }
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return StartCoroutine("Wait");
            if (GiantCrab.GetComponent<NavMeshAgent>() != null)
                GiantCrab.GetComponent<NavMeshAgent>().speed = 1.5f;
            GiantCrab.GetComponent<EnemyController>().AttackCooldown = true;
            GiantCrab.GetComponent<EnemyController>().Attacked = false;
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
