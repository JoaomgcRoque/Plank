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

    [SerializeField] public bool[] isActive;

    private void Start() {
        skillsstm = GetComponent<SkillsSTM>();
        cooldowntime[0] = skill1.skilltime + skill1.cooldown;
        cooldowntime[1] = skill2.skilltime + skill2.cooldown;
        cooldowntime[2] = skill3.cooldown;
        cooldowntime[3] = skill4.burptime + skill4.cooldown;

        isActive[0] = false;
        isActive[1] = false;
        isActive[2] = false;
        isActive[3] = false;
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
        if (skillsstm.isSkill1Active == true && skillsstm.isSkill1 == true
            && isActive[0] == false) {
            isActive[0] = true;
            skillidle[0].SetActive(false);
            skillcooldown[0].SetActive(true);
            StartCoroutine(Skill1Cooldown(imageCooldown, cooldowntime));
        }
        if (skillsstm.isSkill2Active == true && skillsstm.isSkill2 == true
            && isActive[1] == false) {
            isActive[1] = true;
            skillidle[1].SetActive(false);
            skillcooldown[1].SetActive(true);
            StartCoroutine(Skill2Cooldown(imageCooldown, cooldowntime));
        }
        if (skillsstm.isSkill3Active == true && skillsstm.isSkill3 == true 
            && isActive[2] == false) {
            isActive[2] = true;
            skillidle[2].SetActive(false);
            skillcooldown[2].SetActive(true);
            StartCoroutine(Skill3Cooldown(imageCooldown, cooldowntime));
        }
        if (skillsstm.isSkill4Active == true && skillsstm.isSkill4 == true
            && isActive[3] == false) {
            isActive[3] = true;
            skillidle[3].SetActive(false);
            skillcooldown[3].SetActive(true);
            StartCoroutine(Skill4Cooldown(imageCooldown, cooldowntime));
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

    IEnumerator Skill1Cooldown(Image[] imageCooldown, float[] cooldowntime) {
        float time = 0;
        while (time < cooldowntime[0]) {
            float t = time / cooldowntime[0];
            imageCooldown[0].fillAmount = t;
            yield return null;
            time += Time.deltaTime;
        }
        imageCooldown[0].fillAmount = 1f;
        isActive[0] = false;
        skillsstm.isSkill1Active = false;
        if (isActive[0] == false) {
            StopCoroutine(Skill1Cooldown(imageCooldown, cooldowntime));
        }

    }

    IEnumerator Skill2Cooldown(Image[] imageCooldown, float[] cooldowntime) {
        float time = 0;
        while (time < cooldowntime[1]) {
            float t = time / cooldowntime[1];
            imageCooldown[1].fillAmount = t;
            yield return null;
            time += Time.deltaTime;
        }
        imageCooldown[1].fillAmount = 1f;
        isActive[1] = false;
        skillsstm.isSkill2Active = false;
        if (isActive[1] == false) {
            StopCoroutine(Skill2Cooldown(imageCooldown, cooldowntime));
        }

    }

    IEnumerator Skill3Cooldown(Image[] imageCooldown, float[] cooldowntime) {
        float time = 0;
        while (time < cooldowntime[2]) {
            float t = time / cooldowntime[2];
            imageCooldown[2].fillAmount = t;
            yield return null;
            time += Time.deltaTime;
        }
        imageCooldown[2].fillAmount = 1f;
        isActive[2] = false;
        skillsstm.isSkill3Active = false;
        if (isActive[2] == false) {
            StopCoroutine(Skill3Cooldown(imageCooldown, cooldowntime));
        }

    }

    IEnumerator Skill4Cooldown(Image[] imageCooldown, float[] cooldowntime) {
        float time = 0;
        while (time < cooldowntime[3]) {
            float t = time / cooldowntime[3];
            imageCooldown[3].fillAmount = t;
            yield return null;
            time += Time.deltaTime;
        }
        imageCooldown[3].fillAmount = 1f;
        isActive[3] = false;
        skillsstm.isSkill4Active = false;
        if (isActive[3] == false) {
            StopCoroutine(Skill4Cooldown(imageCooldown, cooldowntime));
        }

    }
}
