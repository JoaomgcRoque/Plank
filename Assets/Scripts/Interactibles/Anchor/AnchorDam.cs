using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorDam : MonoBehaviour
{
    [SerializeField] private AnchorSTM anchorstm;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy" && anchorstm.states == AnchorSTM.States.fall) {
            other.GetComponent<EnemyController>().Health = 0f;
        }

        if (other.tag == "Player" && anchorstm.states == AnchorSTM.States.fall) {
            other.GetComponent<PlayerController>().Health = 0f;
        }
    }

    public void EndAnimation() {
        anchorstm.states = AnchorSTM.States.off;
    }
}
