using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    [SerializeField] private PlayerController playerinstance;
    [SerializeField] private SkillsSTM stminstance;
    [SerializeField] private GameObject bomb;
    [SerializeField] public bool canThrow = true;
    [SerializeField] private Transform hand;
    [SerializeField] private float cooldown;

    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip throwclip;

    public float deletethis;

    private void Awake() {
        audiosource = GetComponent<AudioSource>();
    }


    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
    }

    public void Skill3method() {
        Debug.Log("skill3");
        Throw();
        stminstance.skills = SkillsSTM.Skills.noskill;
    }

    private void Throw() {
        if(canThrow == true) {
            Instantiate(bomb, hand.transform.position, hand.transform.rotation);
            audiosource.clip = null;
            audiosource.clip = throwclip;
            audiosource.Play();
            canThrow = false;
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldown);
        stminstance.isSkill3Active = false;
        Debug.Log("Cooldown3 terminou");
        StopCoroutine(Cooldown());
    }
}

