using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().Health -= 5f;
            other.GetComponent<PlayerController>().HealthBar.value =
                other.GetComponent<PlayerController>().Health /
                other.GetComponent<PlayerController>().MaxHealth;
        }
    }
}
