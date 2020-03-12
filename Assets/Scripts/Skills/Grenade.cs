using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private PlayerController PlayerCont;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform lefthand;
    [SerializeField] private float force;
    [SerializeField] private GameObject grenade;
    [SerializeField] private float secondstoexplode;
    [SerializeField] private bool doeskill = false;

    private void Start() {
        PlayerCont = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        lefthand = GameObject.Find("left_hand").GetComponent<Transform>();
        rigidbody.AddForce(lefthand.transform.forward * force);

    }

    private void Update() {
        StartCoroutine(Countdown(secondstoexplode));
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy" && doeskill == true) {
            Destroy(grenade);
            Destroy(other);
            Debug.Log("Explosion");
            doeskill = false;
        }

        if (other.tag == "Player" && doeskill == true) {
            Destroy(grenade);
            Destroy(other);
            Debug.Log("Explosion");
            doeskill = false;
        }
    }

    IEnumerator Countdown(float secondstoexplode) {
        yield return new WaitForSeconds(secondstoexplode);
        doeskill = true;
        Debug.Log("Explosion");
    }
}
