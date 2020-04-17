using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSTM : MonoBehaviour
{
    public enum States { idle, shoot, off }
    public States states;

    [SerializeField] private GameObject smoke;
    [SerializeField] private float time;
    [SerializeField] private float smoketime;
    [SerializeField] private GameObject cannonBullet;
    [SerializeField] private Transform shoot;
    [SerializeField] private bool hasShoot = false;
    [SerializeField] private GameObject cannonsound;

    private void Update() {
        STM();
    }

    private void STM() {
        switch (states) {
            case States.idle:
                smoke.SetActive(false);
                cannonsound.SetActive(false);
                break;
            case States.shoot:
                StartCoroutine(TimetoShoot(time));
                break;
            case States.off:
                StopCoroutine(TimetoShoot(time));
                StartCoroutine(SmokeTime(smoketime));
                break;
        }
    }

    private void Shoot() {
        if (hasShoot == false) {
            hasShoot = true;
            cannonsound.SetActive(true);
            Instantiate(cannonBullet, shoot.transform.position, shoot.transform.rotation);
        }
    }

    IEnumerator TimetoShoot(float time) {
        yield return new WaitForSeconds(time);
        Shoot();
        states = States.off;
    }

    IEnumerator SmokeTime(float smoketime) {
        smoke.SetActive(true);
        yield return new WaitForSeconds(smoketime);
        smoke.SetActive(false);
        StopCoroutine(SmokeTime(smoketime));
    }
}
