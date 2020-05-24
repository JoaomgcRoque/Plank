using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator animator, cannon1, cannon2, cannon3;
    public GameObject Win;
    public bool fase1, fase2, fase3, fase4, stop = false;
    public int nAttacksFase1, nAttacksFase2, nAttacksFase3;

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
            cannon1.SetBool("Open", true);
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
            cannon2.SetBool("Open", true);
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
            cannon3.SetBool("Open", true);
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

