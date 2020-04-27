using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUI : MonoBehaviour
{
    [SerializeField] private GameObject[] skilllocked;
    [SerializeField] private GameObject[] skillidle;
    [SerializeField] private GameObject[] skillcooldown;
    [SerializeField] private SkillsSTM skillsstm;

    [SerializeField] private Image[] imageCooldown;
    [SerializeField] private float[] cooldowntime;
    [SerializeField] private Skill1 skill1;
    [SerializeField] private Skill2 skill2;
    [SerializeField] private Skill3 skill3;
    [SerializeField] private Skill4 skill4;

    private void Start() {
        skillsstm = GetComponent<SkillsSTM>();
    }

    private void Update() {
        Lock();
        UIManager();
    }

    private void UIManager() {
        if(skillsstm.isSkill1Active == true && skillsstm.isSkill1 == true) {
            cooldown();
        }
        if (skillsstm.isSkill1Active == false && skillsstm.isSkill1 == true) {
            idle();
        }
        if (skillsstm.isSkill2Active == true && skillsstm.isSkill2 == true) {
            cooldown();
        }
        if (skillsstm.isSkill2Active == false && skillsstm.isSkill2 == true) {
            idle();
        }
        if (skillsstm.isSkill3Active == true && skillsstm.isSkill3 == true) {
            cooldown();
        }
        if (skillsstm.isSkill3Active == false && skillsstm.isSkill3 == true) {
            idle();
        }
        if (skillsstm.isSkill4Active == true && skillsstm.isSkill4 == true) {
            cooldown();
        }
        if (skillsstm.isSkill4Active == false && skillsstm.isSkill4 == true) {
            idle();
        }
    }

    private void idle() {
        if (skillsstm.isSkill1Active == false && skillsstm.isSkill1 == true) {
            skillidle[0].SetActive(true);
            skilllocked[0].SetActive(false);
            skillcooldown[0].SetActive(false);
        }
        if (skillsstm.isSkill2Active == false && skillsstm.isSkill2 == true) {
            skillidle[1].SetActive(true);
            skilllocked[1].SetActive(false);
            skillcooldown[1].SetActive(false);
        }
        if (skillsstm.isSkill3Active == false && skillsstm.isSkill3 == true) {
            skillidle[2].SetActive(true);
            skilllocked[2].SetActive(false);
            skillcooldown[2].SetActive(false);
        }
        if (skillsstm.isSkill4Active == false && skillsstm.isSkill4 == true) {
            skillidle[3].SetActive(true);
            skilllocked[3].SetActive(false);
            skillcooldown[3].SetActive(false);
        }
    }
    private void cooldown() {
        if (skillsstm.isSkill1Active == true && skillsstm.isSkill1 == true) {
            skillidle[0].SetActive(false);
            skillcooldown[0].SetActive(true);
            StartCoroutine(Skill1Cooldown());
        }
        if (skillsstm.isSkill2Active == true && skillsstm.isSkill2 == true) {
            skillidle[1].SetActive(false);
            skillcooldown[1].SetActive(true);
            StartCoroutine(Skill2Cooldown());
        }
        if (skillsstm.isSkill3Active == true && skillsstm.isSkill3 == true) {
            skillidle[2].SetActive(false);
            skillcooldown[2].SetActive(true);
            StartCoroutine(Skill3Cooldown());
        }
        if (skillsstm.isSkill4Active == true && skillsstm.isSkill4 == true) {
            skillidle[3].SetActive(false);
            skillcooldown[3].SetActive(true);
            StartCoroutine(Skill4Cooldown());
        }
    }

    private void Lock() {
        if(skillsstm.isSkill1 == true) {
            skilllocked[0].SetActive(false);
            skillidle[0].SetActive(true);
        }
        if (skillsstm.isSkill1 == false) {
            skilllocked[0].SetActive(true);
            skillidle[0].SetActive(false);
        }
        if (skillsstm.isSkill2 == true) {
            skilllocked[1].SetActive(false);
            skillidle[1].SetActive(true);
        }
        if (skillsstm.isSkill2 == false) {
            skilllocked[1].SetActive(true);
            skillidle[1].SetActive(false);
        }
        if (skillsstm.isSkill3 == true) {
            skilllocked[2].SetActive(false);
            skillidle[2].SetActive(true);
        }
        if (skillsstm.isSkill3 == false) {
            skilllocked[2].SetActive(true);
            skillidle[2].SetActive(false);
        }
        if (skillsstm.isSkill4 == true) {
            skilllocked[3].SetActive(false);
            skillidle[3].SetActive(true);
        }
        if (skillsstm.isSkill4 == false) {
            skilllocked[3].SetActive(true);
            skillidle[3].SetActive(false);
        }
    }

    IEnumerator Skill1Cooldown() {
        Debug.Log("skill1cooldown começou");
        cooldowntime[0] = skill1.skilltime + skill1.cooldown;
        imageCooldown[0].fillAmount += 1 / cooldowntime[0] * Time.deltaTime;
        if (imageCooldown[0].fillAmount >= 1) {
            imageCooldown[0].fillAmount = 0;
            yield return null;
        } else {
            StopCoroutine(Skill1Cooldown());
            Debug.Log("skill1cooldown terminou");
        }
    }
    IEnumerator Skill2Cooldown() {
        Debug.Log("skill2cooldown começou");
        cooldowntime[1] = skill2.skilltime + skill2.cooldown;
        imageCooldown[1].fillAmount += 1 / cooldowntime[1] * Time.deltaTime;
        if (imageCooldown[1].fillAmount >= 1) {
            imageCooldown[1].fillAmount = 0;
            yield return null;
        } else {
            StopCoroutine(Skill2Cooldown());
            Debug.Log("skill2cooldown terminou");
        }
    }
    IEnumerator Skill3Cooldown() {
        Debug.Log("skill3cooldown começou");
        cooldowntime[2] = skill3.cooldown;
        imageCooldown[2].fillAmount += 1 / cooldowntime[2] * Time.deltaTime;
        if (imageCooldown[2].fillAmount >= 1) {
            imageCooldown[2].fillAmount = 0;
            yield return null;
        } else {
            StopCoroutine(Skill3Cooldown());
            Debug.Log("skill3cooldown terminou");
        }
    }

    IEnumerator Skill4Cooldown() {
        Debug.Log("skill4cooldown começou");
        cooldowntime[3] = skill4.burptime + skill4.cooldown;
        imageCooldown[3].fillAmount += 1 / cooldowntime[3] * Time.deltaTime;
        if (imageCooldown[3].fillAmount >= 1) {
            imageCooldown[3].fillAmount = 0;
            yield return null;
        } else {
            StopCoroutine(Skill4Cooldown());
            Debug.Log("skill4cooldown terminou");
        }
    }
}
