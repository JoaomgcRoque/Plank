using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCannon : MonoBehaviour
{
    public Animator animator;
    public Animator BoatAnimator;
    public Controller controller;
    public GameObject blocker;
    public int Fase;

    private bool stop = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Close", true);
            BoatAnimator.SetInteger("Fase", Fase);
            blocker.SetActive(true);
            if (controller.fase1 && stop == false)
            {
                stop = true;
                controller.fase2 = true;
                controller.fase1 = false;
            }
            if (controller.fase2 && stop == false)
            {
                stop = true;
                controller.fase3 = true;
                controller.fase2 = false;
            }
            if (controller.fase3 && stop == false)
            {
                stop = true;
                controller.fase4 = true;
                controller.fase3 = false;
            }
            stop = false;
            controller.stop = false;
            gameObject.SetActive(false);
        }
    }
}
