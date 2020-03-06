using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKeletonAnimations : MonoBehaviour
{
    [SerializeField] private Animator AnimController;

    private void Update()
    {
        AnimController = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            AnimController.Play("attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            AnimController.Play("walk");
        }
    }
}
