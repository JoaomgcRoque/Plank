using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastCol : MonoBehaviour
{
    [SerializeField] private MastSTM rumbarrelstm;
    [SerializeField] private SwordAttack swordattack;
    public bool isOpen = false;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && swordattack.Attacking == true
            && isOpen == false) {
            rumbarrelstm.states = MastSTM.States.fall;
            isOpen = true;
        }
    }
}
