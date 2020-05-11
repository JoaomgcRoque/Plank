using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWave : MonoBehaviour
{
    [SerializeField] private bool isWave;
    [SerializeField] private GameObject wave;

    private void Awake() {
        isWave = false;
        wave.SetActive(false);
    }

    private void Update() {
        if(isWave == true) {
            wave.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            isWave = true;
        }
    }
}
