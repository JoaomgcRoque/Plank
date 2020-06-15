using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
   [SerializeField] private Transform footfalls;
    [SerializeField] private Transform footsteps;
   [SerializeField] private float totaltime = 0;
    [SerializeField] private float timetoprint;
    public bool issand = true;

    private void Update() {
        totaltime += Time.deltaTime;
        Foot();
    }

    public void Foot() {
        if (totaltime > timetoprint && issand == true) {
            //Instantiate(footfalls, GetComponent<Transform>().position, footfalls.rotation);
            Instantiate(footfalls, GetComponent<Transform>().position, footsteps.rotation);
            totaltime = 0;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Sand") {
            issand = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Sand") {
            issand = false;
        }
    }
}
