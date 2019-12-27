using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Vector3 Movement = Vector3.zero;
    public Transform MainCamera;
    public CharacterController CharacterController;
    public Animator Anim;
    public SwordAttack SwordAtt;
    public TextMeshPro Text;

    public float MoveSpeed = 10;
    public float Gravity = 20;
    public float Health = 10f;
    public float AttackDamage = 1f;

    private void Update()
    {
        Text.text = Health.ToString();
        Text.transform.rotation = Quaternion.LookRotation(transform.position - MainCamera.position);

        if ((Input.GetAxis("Horizontal") > 0f || Input.GetAxis("Horizontal") < 0f ||
            Input.GetAxis("Vertical") < 0f || Input.GetAxis("Vertical") > 0f) && SwordAtt.AttackTimer == 0)
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
