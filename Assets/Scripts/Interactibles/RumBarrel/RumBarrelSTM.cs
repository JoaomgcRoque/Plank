using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumBarrelSTM : MonoBehaviour
{
    public enum States { idle, open, off}
    public States states;

    [SerializeField] private GameObject rum;
    [SerializeField] private float time;

    private void Update() {
        STM();
    }

    private void STM() {
        switch (states) {
            case States.idle:
                rum.SetActive(false);
                break;
            case States.open:
                rum.SetActive(true);
                StartCoroutine(TurnOff(time));
                break;
            case States.off:
                rum.SetActive(false);
                StopCoroutine(TurnOff(time));
                break;
        }
    }

    IEnumerator TurnOff(float time) {
        yield return new WaitForSeconds(time);
        states = States.off;
    }
}
