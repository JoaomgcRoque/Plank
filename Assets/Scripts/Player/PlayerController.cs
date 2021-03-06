﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Vector3 Movement = Vector3.zero;
    public Transform MainCamera;
    public CharacterController CharacterController;
    public Animator Anim;
    public SwordAttack SwordAtt;
    public Slider HealthBar;
    public GameObject DeathCanvas;
    public GameObject PauseCanvas;
    public Transform Player;
    public GameObject Footsteps;
    public AudioSource hitsound;

    public float horizontalSpeed;
    public float verticalSpeed;

    [SerializeField] private bool rotate = false;
    [SerializeField] private ChangeColor changecolor;

    public float MoveSpeed = 10;
    public float Gravity = 20;
    public float MaxHealth = 10f;
    public float Health;
    public float AttackDamage = 1f;
    public bool Paused;


    void Start()
    {
        Health = MaxHealth;
        HealthBar.value = CalculateHealth();
        Paused = false;
        changecolor.GetComponent<ChangeColor>();
    }

    private void Update()
    {

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);

        if ((Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f ||
            Input.GetAxisRaw("Vertical") < 0f || Input.GetAxisRaw("Vertical") > 0f) && SwordAtt.AttackTimer == 0) {
            Movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));


            Anim.SetBool("Moving", true);
            //Movement *= MoveSpeed;
            Movement = Movement.normalized * MoveSpeed; //isto é melhor

            if (Movement != new Vector3(0f, 0f, 0f))
                transform.rotation = Quaternion.LookRotation(Movement);

            Movement.y -= (Gravity * Time.deltaTime);

            CharacterController.Move(Movement * Time.deltaTime);

            Footsteps.SetActive(true);
        } else {
            Anim.SetBool("Moving", false);
            Footsteps.SetActive(false);
        }

        if ((Input.GetKeyDown(KeyCode.Escape)) || (Input.GetButtonDown("Options")))
        {
            if (Paused)
                Resume();
            else
                Pause();
        }

        if (Health <= 0)
        {
            GetComponent<Animator>().SetBool("Dead", true);
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponent<SwordAttack>());
            Destroy(GetComponentInChildren<TextMeshPro>());
            if (HealthBar != null)
                Destroy(HealthBar.gameObject);
            DeathCanvas.SetActive(true);
            //Time.timeScale = 0f;
            AudioListener.pause = true;
        }

        if(Input.GetKey("q")) {
            Player.transform.Rotate(new Vector3(0, 360, 0) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            Player.transform.Rotate(0f, 180f, 0f);
        }
    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

    public void Resume ()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        AudioListener.pause = false;
    }

    public void Pause ()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        AudioListener.pause = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Bullet") {
            hitsound.Play();
            changecolor.change = true;
        }
    }
}
