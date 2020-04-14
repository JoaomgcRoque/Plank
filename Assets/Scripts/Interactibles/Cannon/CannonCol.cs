using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCol : MonoBehaviour
{
    [SerializeField] private CannonSTM cannonstm;
    [SerializeField] private SwordAttack swordattack;
    public bool isOpen = false;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && swordattack.Attacking == true
            && isOpen == false) {
            cannonstm.states = CannonSTM.States.shoot;
            isOpen = true;
        }
    }
}
