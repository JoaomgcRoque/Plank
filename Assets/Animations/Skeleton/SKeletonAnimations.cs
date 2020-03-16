using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKeletonAnimations : MonoBehaviour
{
    [SerializeField] private Animator AnimController;

    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip swordclip;

    private void Awake() {
        audiosource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        AnimController = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            AnimController.Play("attack");
            /*audiosource.clip = swordclip;
            audiosource.Play();*/
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            audiosource.clip = null;
            audiosource.clip = swordclip;
            audiosource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            audiosource.clip = null;
            AnimController.Play("walk");
        }
    }
}
