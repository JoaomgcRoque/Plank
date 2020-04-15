using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorDam : MonoBehaviour
{
    [SerializeField] private AnchorSTM maststm;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy" && maststm.states == AnchorSTM.States.fall) {
            other.GetComponent<EnemyController>().Health = 0f;
        }

        if (other.tag == "Player" && maststm.states == AnchorSTM.States.fall) {
            other.GetComponent<PlayerController>().Health = 0f;
        }
    }

    public void EndAnimation() {
        maststm.states = AnchorSTM.States.off;
    }
}
