using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public Animator animator;
    public GameObject closeTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Fire", true);
            closeTrigger.SetActive(true);
        }
    }
}
