using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [SerializeField] private float destroytime;
    public GameObject footstep;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy(destroytime));
    }

    IEnumerator Destroy(float destroytime) {
            yield return new WaitForSeconds(destroytime);
            Destroy(footstep);
    }
}
