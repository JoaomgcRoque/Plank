using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonLook : MonoBehaviour
{
    public GameObject Skeleton;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return StartCoroutine("Wait");
            Skeleton.GetComponent<EnemyController>().Attacked = true;
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (Skeleton.GetComponent<EnemyController>().AttackCooldown == false && other.tag == "Player")
        {
            if (Skeleton.GetComponent<EnemyController>().Attacked == true)
            {
                Skeleton.GetComponent<EnemyController>().AttackCooldown = false;
            }
            else
            {
                yield return StartCoroutine("Wait");
                Skeleton.GetComponent<EnemyController>().Attacked = true;
            }
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return StartCoroutine("Wait");

            Skeleton.GetComponent<EnemyController>().AttackCooldown = true;
            Skeleton.GetComponent<EnemyController>().Attacked = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
