using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCrabSound : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip walkclip;

    [SerializeField] private EnemyController enemycontroller;

    private void Awake() {
        audiosource = GetComponent<AudioSource>();
    }

    private void Start() {
        audiosource.clip = walkclip;
        audiosource.Play();
    }

    private void Update() {
        if(enemycontroller.GetComponent<EnemyController>().Health <= 0) {
            audiosource.enabled = false;
        }
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
