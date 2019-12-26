using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 Movement = Vector3.zero;
    private CharacterController CharacterController;
    public Animator Anim;

    public float MoveSpeed = 10;
    public float Gravity = 20;

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        Anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0f || Input.GetAxis("Horizontal") < 0f ||
            Input.GetAxis("Vertical") < 0f || Input.GetAxis("Vertical") > 0f)
        {
            Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            Anim.SetBool("Moving", true);
            Movement *= MoveSpeed;

            if (Movement != new Vector3(0f, 0f, 0f))
                transform.rotation = Quaternion.LookRotation(Movement);

            Movement.y -= (Gravity * Time.deltaTime);

            CharacterController.Move(Movement * Time.deltaTime);
        }
        else
            Anim.SetBool("Moving", false);
    }
}
