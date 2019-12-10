using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 Movement = Vector3.zero;
    private CharacterController CharacterController;

    public float MoveSpeed = 10;
    public float Gravity = 20;

    public bool Attacking = false;

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Movement *= MoveSpeed;
        if (Movement != new Vector3(0f, 0f, 0f))
            transform.rotation = Quaternion.LookRotation(Movement);

        Movement.y -= (Gravity * Time.deltaTime);

        CharacterController.Move(Movement * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attacking = true;
        }
    }
}
