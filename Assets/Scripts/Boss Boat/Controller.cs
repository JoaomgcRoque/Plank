using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator animator, cannon1, cannon2, cannon3;
    public Canvas canvas;
    public GameObject Win;
    public GameObject[] wave1Enemies, wave2Enemies, wave3Enemies;
    public bool fase1, fase2, fase3, fase4, wave1, wave2, wave3, stop = false;
    public int nAttacksFase1, nAttacksFase2, nAttacksFase3, counter;

    void Update()
    {
        if (fase1 && stop == false)
            StartCoroutine(BossFase1());
        if (fase2 && stop == false)
            StartCoroutine(BossFase2());
        if (fase3 && stop == false)
            StartCoroutine(BossFase3());
        if (fase4 && stop == false)
            StartCoroutine(BossFase4());
    }

    public IEnumerator BossFase1()
    {
        stop = true;
        if (fase1)
        {
            yield return new WaitForSeconds(1f);
            for (int x = 0; x < nAttacksFase1; x++)
            {
                animator.SetInteger("Fase", 1);
                animator.SetInteger("Attack", Random.Range(1, 5));
                yield return new WaitForSeconds(1.75f);
                animator.SetInteger("Attack", 0);
                yield return new WaitForSeconds(0.5f);
            }
        }
        BossWave1();
    }

    public void BossWave1()
    {
        stop = false;
        animator.SetInteger("Wave", 1);
        if (wave1)
        {
            counter = 0;
            for (int x = 0; x < wave1Enemies.Length; x++)
                if (wave1Enemies[x].GetComponent<NavMeshAgent>() == null)
                    counter++;

            if (counter == wave1Enemies.Length)
            {
                cannon1.SetBool("Open", true);
                for (int x = 0; x < wave1Enemies.Length; x++)
                {
                    Destroy(canvas.transform.GetChild(6+x).gameObject);
                    Destroy(wave1Enemies[x]);
                }
                wave2 = true;
                stop = true;
                wave1 = false;
            }
        }
    }

    public IEnumerator BossFase2()
    {
        stop = true;
        if (fase2)
        {
            yield return new WaitForSeconds(1f);
            for (int x = 0; x < nAttacksFase2; x++)
            {
                animator.SetInteger("Fase", 2);
                animator.SetInteger("Attack", Random.Range(1, 5));
                yield return new WaitForSeconds(1.5f);
                animator.SetInteger("Attack", 0);
                yield return new WaitForSeconds(0.5f);
            }
        }
        BossWave2();
    }

    public void BossWave2()
    {
        stop = false;
        animator.SetInteger("Wave", 2);
        if (wave2)
        {
            counter = 0;
            for (int x = 0; x < wave2Enemies.Length; x++)
                if (wave2Enemies[x].GetComponent<NavMeshAgent>() == null)
                    counter++;

            if (counter == wave2Enemies.Length)
            {
                cannon2.SetBool("Open", true);
                for (int x = 0; x < wave2Enemies.Length; x++)
                {
                    Destroy(canvas.transform.GetChild(6 + x).gameObject);
                    Destroy(wave2Enemies[x]);
                }
                wave3 = true;
                stop = true;
                wave2 = false;
            }
        }
    }

    public IEnumerator BossFase3()
    {
        stop = true;
        if (fase3)
        {
            yield return new WaitForSeconds(1f);
            for (int x = 0; x < nAttacksFase3; x++)
            {
                animator.SetInteger("Fase", 3);
                animator.SetInteger("Attack", Random.Range(1, 5));
                yield return new WaitForSeconds(1.3f);
                animator.SetInteger("Attack", 0);
                yield return new WaitForSeconds(0.5f);
            }
        }
        BossWave3();
    }
    
    public void BossWave3()
    {
        stop = false;
        animator.SetInteger("Wave", 3);
        if (wave3)
        {
            counter = 0;
            for (int x = 0; x < wave3Enemies.Length; x++)
                if (wave3Enemies[x].GetComponent<NavMeshAgent>() == null)
                    counter++;

            if (counter == wave3Enemies.Length)
            {
                cannon3.SetBool("Open", true);
                for (int x = 0; x < wave3Enemies.Length; x++)
                {
                    Destroy(canvas.transform.GetChild(6 + x).gameObject);
                    Destroy(wave3Enemies[x]);
                }
                stop = true;
            }
        }
    }

    public IEnumerator BossFase4()
    {
        stop = true;
        if (fase4)
        {
            animator.SetInteger("Fase", 4);
            yield return new WaitForSeconds(5f);
            Win.SetActive(true);
        }
    }
}

