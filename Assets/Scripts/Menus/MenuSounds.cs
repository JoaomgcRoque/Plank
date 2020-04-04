using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip clickclip;

    private void Awake() {
        audiosource = GetComponent<AudioSource>();
    }

    public void ClickSound() {
        audiosource.clip = null;
        audiosource.clip = clickclip;
        audiosource.Play();
    }
}
