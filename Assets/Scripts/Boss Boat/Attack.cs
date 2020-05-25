using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public AudioSource hitsound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hitsound.Play();
            other.GetComponent<PlayerController>().Health -= 5f;
            other.GetComponent<PlayerController>().HealthBar.value =
                other.GetComponent<PlayerController>().Health /
                other.GetComponent<PlayerController>().MaxHealth;
        }
    }
}
