﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKeletonAnimations : MonoBehaviour
{
    [SerializeField] private Animator AnimController;

    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip swordclip;
    [SerializeField] private AudioClip walkclip;
    [SerializeField] private float walkaudiovolume;
    [SerializeField] private float swordaudiovolume;

    [SerializeField] private EnemyController enemycontroller;

    private void Awake() {
        audiosource = GetComponent<AudioSource>();
    }

    private void Start() {
        audiosource.volume = walkaudiovolume;
        audiosource.clip = walkclip;
        audiosource.Play();
    }
    private void Update()
    {
        AnimController = GetComponent<Animator>();
        if(enemycontroller.GetComponent<EnemyController>().Health <= 0) {
            audiosource.clip = null;
            audiosource.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            AnimController.Play("attack");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            audiosource.clip = null;
            audiosource.volume = swordaudiovolume;
            audiosource.clip = swordclip;
            audiosource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            audiosource.clip = null;
            audiosource.volume = walkaudiovolume;
            audiosource.clip = walkclip;
            audiosource.Play();
            AnimController.Play("walk");
        }
    }
}
