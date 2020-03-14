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

    private void Start() {
        skillsstm = GetComponent<SkillsSTM>();
    }

    private void Update() {
        UIManager();
    }

    private void UIManager() {
        if(skillsstm.canClick == true) {
            idle();
        }
        if (skillsstm.canClick == false) {
            cooldown();
        }
    }

    private void idle() {
        if(skillsstm.isSkill1 == true) {
            skillidle[0].SetActive(true);
            skilllocked[0].SetActive(false);
            skillcooldown[0].SetActive(false);
        } else {
            skillidle[0].SetActive(false);
            skilllocked[0].SetActive(true);
        }
        if (skillsstm.isSkill2 == true) {
            skillidle[1].SetActive(true);
            skilllocked[1].SetActive(false);
            skillcooldown[1].SetActive(false);
        } else {
            skillidle[1].SetActive(false);
            skilllocked[1].SetActive(true);
        }
        if (skillsstm.isSkill3 == true) {
            skillidle[2].SetActive(true);
            skilllocked[2].SetActive(false);
            skillcooldown[2].SetActive(false);
        } else {
            skillidle[2].SetActive(false);
            skilllocked[2].SetActive(true);
        }
        if (skillsstm.isSkill4 == true) {
            skillidle[3].SetActive(true);
            skilllocked[3].SetActive(false);
            skillcooldown[3].SetActive(false);
        } else {
            skillidle[3].SetActive(false);
            skilllocked[3].SetActive(true);
        }
    }

    private void cooldown() {
        if(skillsstm.isSkill1 == true) {
            skilllocked[0].SetActive(false);
            skillidle[0].SetActive(false);
            skillcooldown[0].SetActive(true);
        }
        if (skillsstm.isSkill2 == true) {
            skilllocked[1].SetActive(false);
            skillidle[1].SetActive(false);
            skillcooldown[1].SetActive(true);
        }
        if (skillsstm.isSkill3 == true) {
            skilllocked[2].SetActive(false);
            skillidle[2].SetActive(false);
            skillcooldown[2].SetActive(true);
        }
        if (skillsstm.isSkill4 == true) {
            skilllocked[3].SetActive(false);
            skillidle[3].SetActive(false);
            skillcooldown[3].SetActive(true);
        }
    }
}
