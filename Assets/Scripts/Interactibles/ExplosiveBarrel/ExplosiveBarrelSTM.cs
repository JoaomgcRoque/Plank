using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelSTM : MonoBehaviour
{
    public enum States { idle, explosion, off }
    public States states;

    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject explosivebarrel;
    [SerializeField] private float time;

    private void Update() {
        STM();
    }

    private void STM() {
        switch (states) {
            case States.idle:
                barrel.SetActive(true);
                explosion.SetActive(false);
                explosivebarrel.SetActive(true);
                break;
            case States.explosion:
                StartCoroutine(TurnOff(time));
                barrel.SetActive(false);
                explosion.SetActive(true);
                explosivebarrel.SetActive(true);
                break;
            case States.off:
                StopCoroutine(TurnOff(time));
                Destroy(explosivebarrel);
                break;
        }
    }

    IEnumerator TurnOff(float time) {
        yield return new WaitForSeconds(time);
        states = States.off;
    }
}
