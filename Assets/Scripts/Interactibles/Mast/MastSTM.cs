using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastSTM : MonoBehaviour
{
    public enum States { idle, fall, off }
    public States states;

    [SerializeField] private Animator MastAnimator;
    [SerializeField] private GameObject mastsound;

    private void Start() {
        states = States.idle;
    }

    private void Update() {
        STM();
    }

    private void STM() {
        switch (states) {
            case States.idle:
                mastsound.SetActive(false);
                break;
            case States.fall:
                mastsound.SetActive(true);
                MastAnimator.Play("Fall");
                break;
            case States.off:
                MastAnimator.Play("GroundState");
                break;
        }
    }

    public void EndAnimation() {
        states = States.off;
    }

}
