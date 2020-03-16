using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCrabSound : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip walkclip;

    private void Awake() {
        audiosource = GetComponent<AudioSource>();
    }

    private void Start() {
        audiosource.clip = walkclip;
        audiosource.Play();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            //audiosource.clip = null;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            audiosource.clip = null;
            audiosource.clip = walkclip;
            audiosource.Play();
        }
    }
}
