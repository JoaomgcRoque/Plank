using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedPirateAnim : MonoBehaviour
{
    [SerializeField] private Animator AnimController;

    private void Update() {
        AnimController = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            AnimController.Play("shoot");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            AnimController.Play("walk");
        }
    }
}
