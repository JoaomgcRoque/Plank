using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CorruptPirateAI : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;
    [SerializeField] private float time;
    [SerializeField] private bool cooldown = false;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material = gameObject.GetComponent<EnemyController>().Orange;
            yield return StartCoroutine("Wait");
            gameObject.GetComponent<EnemyController>().Attacked = true;
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<EnemyController>().AttackCooldown == false && other.tag == "Player" && cooldown == false)
        {
            if (gameObject.GetComponent<EnemyController>().Attacked == true)
            {
                Throw();
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
                gameObject.GetComponentInChildren<MeshRenderer>().material = gameObject.GetComponent<EnemyController>().Orange;
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
            gameObject.GetComponentInChildren<MeshRenderer>().material = gameObject.GetComponent<EnemyController>().White;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    public void Throw()
    {
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        cooldown = true;
        StartCoroutine(CooldDown(time));
    }

    public void DestroyBullet()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(go);
        }
    }

    IEnumerator CooldDown(float time)
    {
        yield return new WaitForSeconds(time);
        DestroyBullet();
        cooldown = false;
    }
}
