using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] private GameObject throwable;
    [SerializeField] private Transform hand;
    [SerializeField] private float time;
    [SerializeField] private bool cooldown = false;

    private void Update() {
        if (Input.GetMouseButtonDown(1) && cooldown == false) {
            Throw();
        }
    }
    public void Throw() {
        Instantiate(throwable, hand.transform.position, hand.transform.rotation);
        cooldown = true;
        StartCoroutine(CooldDown(time));
    }

    public void DestroyThrowables() {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Throwable")) {
            Destroy(go);
        }
    }

    IEnumerator CooldDown(float time) {
        yield return new WaitForSeconds(time);
        DestroyThrowables();
        cooldown = false;
    }
}
