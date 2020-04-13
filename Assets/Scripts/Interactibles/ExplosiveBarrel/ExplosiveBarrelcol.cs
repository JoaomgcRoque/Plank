using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelcol : MonoBehaviour
{
    [SerializeField] private ExplosiveBarrelSTM explosivebarrelstm;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Grenade" && 
             other.gameObject.GetComponent<Grenade>().doeskill == true) {
            explosivebarrelstm.states = ExplosiveBarrelSTM.States.explosion;
        }
        if (other.gameObject.tag == "Bullet") {
            explosivebarrelstm.states = ExplosiveBarrelSTM.States.explosion;
        }
        if (other.gameObject.tag == "Throwable") {
            explosivebarrelstm.states = ExplosiveBarrelSTM.States.explosion;
        }
        if (other.gameObject.tag == "Player" && 
            other.gameObject.GetComponent<SwordAttack>().Attacking == true) {
            explosivebarrelstm.states = ExplosiveBarrelSTM.States.explosion;
        }
    }
}
