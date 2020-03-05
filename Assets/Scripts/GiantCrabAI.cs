using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCrabAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform crab;
    [SerializeField] private bool isJump = false;
    [SerializeField] private float time;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        StartCoroutine(CoolDown(time));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isJump == false)
        {
            crab.transform.position = player.transform.position;
            isJump = true;
            Vector3 direction = crab.transform.position - player.transform.position;
            direction.Normalize();
        }
    }

    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        isJump = false;
    }
}
