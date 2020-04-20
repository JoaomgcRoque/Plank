using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptPirateGrenade : MonoBehaviour
{
    [SerializeField] private EnemyController EnemyCont;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform lefthand;
    [SerializeField] private float force;
    [SerializeField] private GameObject grenade;
    [SerializeField] private float secondstoexplode;
    [SerializeField] private float explosiontime;
    public bool doeskill = false;
    [SerializeField] private GameObject explosion;

    private void Start() {
        EnemyCont = GameObject.Find("CorruptPirate2").GetComponent<EnemyController>();
        lefthand = GameObject.Find("gun").GetComponent<Transform>();
        rigidbody.AddForce(lefthand.transform.forward * force, ForceMode.Impulse);

    }

    private void Update() {
        StartCoroutine(Countdown(secondstoexplode));
        ExplosionBurst();
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && doeskill == true) {
            //Destroy(other);
            other.GetComponent<PlayerController>().Health = 0f;
            Debug.Log("Explosion");
            doeskill = false;
        }

        if (other.tag == "Enemy" && doeskill == true) {
            Destroy(grenade);
            EnemyCont.Health = 0f;
            Debug.Log("Explosion");
            doeskill = false;
        }
    }

    private void ExplosionBurst() {
        if (doeskill == true) {
            explosion.SetActive(true);
        } else {
            explosion.SetActive(false);
        }
    }

    IEnumerator Countdown(float secondstoexplode) {
        yield return new WaitForSeconds(secondstoexplode);
        doeskill = true;
        Debug.Log("Explosion");
        StartCoroutine(ExplosionTime());
    }

    IEnumerator ExplosionTime() {
        yield return new WaitForSeconds(explosiontime);
        Destroy(grenade);
    }
}
