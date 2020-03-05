using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptPirateAI : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;
    [SerializeField] private float time;
    [SerializeField] private bool cooldown = false;

    private void FixedUpdate()
    {
        if (cooldown == false)
        {
            Throw();
        }
    }

    public void Throw()
    {
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        cooldown = true;
        StartCoroutine(CooldDown(time));
    }

    public void DestroyBullet()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(go);
        }
    }

    IEnumerator CooldDown(float time)
    {
        yield return new WaitForSeconds(time);
        DestroyBullet();
        cooldown = false;
    }
}
