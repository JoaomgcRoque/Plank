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
    private void locked() {
        foreach (GameObject locked in skilllocked) {
            locked.active = true;
        }
        foreach (GameObject idle in skillidle) {
            idle.active = false;
        }
        foreach (GameObject cooldown in skillcooldown) {
            cooldown.active = false;
        }
    }

    private void idle() {
        foreach (GameObject locked in skilllocked) {
            locked.active = false;
        }
        foreach (GameObject idle in skillidle) {
            idle.active = true;
        }
        foreach (GameObject cooldown in skillcooldown) {
            cooldown.active = false;
        }
    }

    private void cooldown() {
        foreach (GameObject locked in skilllocked) {
            locked.active = false;
        }
        foreach (GameObject idle in skillidle) {
            idle.active = false;
        }
        foreach (GameObject cooldown in skillcooldown) {
            cooldown.active = true;
        }
    }
}
