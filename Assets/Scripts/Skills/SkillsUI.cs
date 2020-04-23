using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUI : MonoBehaviour
{
    [SerializeField] private GameObject[] skilllocked;
    [SerializeField] private GameObject[] skillidle;
    [SerializeField] private GameObject[] skillcooldown;
    [SerializeField] private GameObject[] skillhighlighted;
    [SerializeField] private SkillsSTM skillsstm;

    private void Start() {
        skillsstm = GetComponent<SkillsSTM>();
    }

    private void Update() {
        Lock();
        UIManager();
    }

    private void UIManager() {
        if(skillsstm.isSkill1Active == true && skillsstm.isSkill1 == true) {
            skillhighlighted[0].SetActive(true);
            cooldown();
        }
        if (skillsstm.isSkill1Active == false && skillsstm.isSkill1 == true) {
            skillhighlighted[0].SetActive(false);
            idle();
        }
        if (skillsstm.isSkill2Active == true && skillsstm.isSkill2 == true) {
            skillhighlighted[1].SetActive(true);
            cooldown();
        }
        if (skillsstm.isSkill2Active == false && skillsstm.isSkill2 == true) {
            skillhighlighted[1].SetActive(false);
            idle();
        }
        if (skillsstm.isSkill3Active == true && skillsstm.isSkill3 == true) {
            skillhighlighted[2].SetActive(true);
            cooldown();
        }
        if (skillsstm.isSkill3Active == false && skillsstm.isSkill3 == true) {
            skillhighlighted[2].SetActive(false);
            idle();
        }
        if (skillsstm.isSkill4Active == true && skillsstm.isSkill4 == true) {
            skillhighlighted[3].SetActive(true);
            cooldown();
        }
        if (skillsstm.isSkill4Active == false && skillsstm.isSkill4 == true) {
            skillhighlighted[3].SetActive(false);
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
        }
        if (skillsstm.isSkill2Active == true && skillsstm.isSkill2 == true) {
            skillidle[1].SetActive(false);
            skillcooldown[1].SetActive(true);
        }
        if (skillsstm.isSkill3Active == true && skillsstm.isSkill3 == true) {
            skillidle[2].SetActive(false);
            skillcooldown[2].SetActive(true);
        }
        if (skillsstm.isSkill4Active == true && skillsstm.isSkill4 == true) {
            skillidle[3].SetActive(false);
            skillcooldown[3].SetActive(true);
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
}
