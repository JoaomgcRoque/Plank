using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [SerializeField] private float destroytime;
    [SerializeField] private float totaltime;
    // Start is called before the first frame update
    void Start()
    {
        if (totaltime == destroytime) {
            Destroy(gameObject, destroytime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        totaltime += Time.deltaTime;
    }
}
