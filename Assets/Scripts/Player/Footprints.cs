using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
   [SerializeField] private Transform footfalls;
    [SerializeField] private Transform footsteps;
    [SerializeField] private GameObject footprefab;
    [SerializeField] private LayerMask canbeprint;
   [SerializeField] private float totaltime = 0;
    [SerializeField] private float timetoprint;
    [SerializeField] private float distance;
    public bool issand = true;

    private void Update() {
        totaltime += Time.deltaTime;
        Foot();
    }

    public void Foot() {
        if (totaltime > timetoprint && issand == true) {
            //Instantiate(footfalls, GetComponent<Transform>().position, footsteps.rotation);
            Transform t_spawn = transform.Find("footstepspawner");

            RaycastHit t_hit = new RaycastHit();
            if(Physics.Raycast(t_spawn.position, t_spawn.forward, 
                out t_hit, distance, canbeprint))
            {
                /*GameObject t_newStep = Instantiate(footprefab, 
                    t_hit.point + t_hit.normal * 0.001f, Quaternion.identity) as GameObject;*/
                GameObject t_newStep = Instantiate(footprefab,
                t_hit.point + t_hit.normal * 0.001f, footsteps.rotation) as GameObject;
                t_newStep.transform.LookAt(t_hit.point + t_hit.normal);
                //Destroy(t_newStep, 5f);
                Debug.Log("Footstep");
            }


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
