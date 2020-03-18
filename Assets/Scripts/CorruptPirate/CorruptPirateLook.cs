using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CorruptPirateLook : MonoBehaviour
{
    public GameObject CorruptPirate;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;
    [SerializeField] private float time;
    [SerializeField] private bool cooldown = false;
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip shootclip;

    [SerializeField] private EnemyController enemycontroller;

    private void Awake() {
        audiosource = GetComponent<AudioSource>();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return StartCoroutine("Wait");
            CorruptPirate.GetComponent<NavMeshAgent>().speed = 0f;
            CorruptPirate.GetComponent<EnemyController>().Attacked = true;
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (CorruptPirate.GetComponent<EnemyController>().AttackCooldown == false && other.tag == "Player" && cooldown == false)
        {
            if (CorruptPirate.GetComponent<EnemyController>().Attacked == true)
            {
                Throw();
                CorruptPirate.GetComponent<EnemyController>().AttackCooldown = true;
                CorruptPirate.GetComponent<EnemyController>().Attacked = false;
            }
            else
            {
                yield return StartCoroutine("Wait");
                CorruptPirate.GetComponent<EnemyController>().Attacked = true;
            }
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return StartCoroutine("Wait");
            CorruptPirate.GetComponent<NavMeshAgent>().speed = 1.5f;
            CorruptPirate.GetComponent<EnemyController>().Attacked = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    public void Throw()
    {
        if (enemycontroller.Health > 0) {
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            cooldown = true;
            StartCoroutine(CooldDown(time));
            audiosource.clip = null;
            audiosource.clip = shootclip;
            audiosource.Play();
        }
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
