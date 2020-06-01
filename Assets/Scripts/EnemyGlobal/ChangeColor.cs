using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material defaultcolor;
    public Material flash;
    public Renderer model;
    public bool change;

    public float time;

    private void Awake() {
        change = false;
    }

    private void Update() {
        if(change == true) {
            model.material = flash;
            StartCoroutine(ReturnColor(time));
        }
        else {
            model.material = defaultcolor;
        }
    }

    IEnumerator ReturnColor(float time) {
        yield return new WaitForSeconds(time);
        change = false;
        StopCoroutine(ReturnColor(time));
    }
}
