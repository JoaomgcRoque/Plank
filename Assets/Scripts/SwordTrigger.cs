using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwordTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Animator>().SetBool("Dead", true);
            Destroy(other.gameObject.GetComponent<NavMeshAgent>());
            Destroy(other.gameObject.GetComponent<CapsuleCollider>());
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            Destroy(other.gameObject.GetComponent<BoxCollider>());
        }
    }
}
