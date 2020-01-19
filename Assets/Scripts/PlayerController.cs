using System.Collections;
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
    public TextMeshPro Text;
    public Slider HealthBar;
    public GameObject DeathCanvas;
    public GameObject PauseCanvas;

    public float MoveSpeed = 10;
    public float Gravity = 20;
    public float MaxHealth = 10f;
    public float Health;
    public float AttackDamage = 1f;
    public bool HitCooldown = false;
    public float InvisibleFrames = 1.5f;
    public float Timer;
    public bool Paused;

    void Start()
    {
        Health = MaxHealth;
        HealthBar.value = CalculateHealth();
        Timer = InvisibleFrames;
        Paused = false;
    }

    private void Update()
    {
        Text.text = Health.ToString();
        Text.transform.rotation = Quaternion.LookRotation(transform.position - MainCamera.position);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(0f, 3f, 0f));

        HealthBar.transform.position = screenPosition;

        if (HitCooldown)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                HitCooldown = false;
                Timer = InvisibleFrames;
            }
        }

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

        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    public void Pause ()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
}
