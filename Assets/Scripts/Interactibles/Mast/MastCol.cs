using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastCol : MonoBehaviour
{
    [SerializeField] private MastSTM maststm;
    [SerializeField] private SwordAttack swordattack;
    public bool isOpen = false;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && swordattack.Attacking == true
            && isOpen == false) {
            maststm.states = MastSTM.States.fall;
            isOpen = true;
        }
        if (other.gameObject.tag == "Grenade" &&
            other.gameObject.GetComponent<Grenade>().doeskill == true) {
            maststm.states = MastSTM.States.fall;
            isOpen = true;
        }
    }
}
