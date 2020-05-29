using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
   [SerializeField] private Transform footfalls;
   [SerializeField] private float totaltime = 0;
    [SerializeField] private float timetoprint;

    private void Update() {
        totaltime += Time.deltaTime;
    }

    public void Foot() {
        if (totaltime > timetoprint) {
            Instantiate(footfalls, GetComponent<Transform>().position, footfalls.rotation);
            totaltime = 0;
        }
    }
}
