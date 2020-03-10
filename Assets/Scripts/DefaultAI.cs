using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAI : MonoBehaviour
{
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return StartCoroutine("Wait");
            gameObject.GetComponent<EnemyController>().Attacked = true;
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<EnemyController>().AttackCooldown == false && other.tag == "Player")
        {
            if (gameObject.GetComponent<EnemyController>().Attacked == true)
            {
                other.GetComponent<PlayerController>().Health -= gameObject.GetComponent<EnemyController>().AttackDamage;
                other.GetComponent<PlayerController>().HealthBar.value =
                    other.GetComponent<PlayerController>().Health /
                    other.GetComponent<PlayerController>().MaxHealth;
                gameObject.GetComponent<EnemyController>().AttackCooldown = true;
                gameObject.GetComponent<EnemyController>().Attacked = false;
            }
            else
            {
                yield return StartCoroutine("Wait");
                gameObject.GetComponent<EnemyController>().Attacked = true;
            }
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return StartCoroutine("Wait");
            gameObject.GetComponent<EnemyController>().Attacked = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
