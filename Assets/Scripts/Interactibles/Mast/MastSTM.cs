using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastSTM : MonoBehaviour
{
    public enum States { idle, fall, off }
    public States states;

    [SerializeField] private Animator MastAnimator;

    private void Start() {
        states = States.idle;
    }

    private void Update() {
        STM();
    }

    private void STM() {
        switch (states) {
            case States.idle:
                break;
            case States.fall:
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
