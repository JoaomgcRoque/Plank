using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSTM : MonoBehaviour
{
    public enum States { idle, fall, off }
    public States states;

    [SerializeField] private Animator AnchorAnimator;

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
                AnchorAnimator.Play("fall");
                break;
            case States.off:
                AnchorAnimator.Play("off");
                break;
        }
    }
}
