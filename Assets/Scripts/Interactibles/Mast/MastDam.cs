using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastDam : MonoBehaviour
{
    [SerializeField] private MastSTM maststm;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy" && maststm.states == MastSTM.States.fall) {
            other.GetComponent<EnemyController>().Health = 0f;
        }

        if (other.tag == "Player" && maststm.states == MastSTM.States.fall) {
            other.GetComponent<PlayerController>().Health = 0f;
        }
    }
}
