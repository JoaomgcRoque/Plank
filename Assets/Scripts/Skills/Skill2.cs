using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    [SerializeField] private PlayerController playerinstance;
    [SerializeField] private float newDamage;
    [SerializeField] private SkillsSTM stminstance;
    [SerializeField] public float skilltime;
    [SerializeField] private float defaultDamage;
    [SerializeField] private GameObject normalsword;
    [SerializeField] private GameObject redsword;
    [SerializeField] private bool isActive = false;
    [SerializeField] public float cooldown;

    public float deletethis;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();

        if(isActive == true) {
            playerinstance.AttackDamage = newDamage;
            normalsword.SetActive(false);
            redsword.SetActive(true);
        }
        if (isActive == false) {
            playerinstance.AttackDamage = defaultDamage;
            normalsword.SetActive(true);
            redsword.SetActive(false);
        }
    }
    public void Skill2method() {
        isActive = true;
        StartCoroutine(SkillTime());
        stminstance.skills = SkillsSTM.Skills.noskill;
    }

    IEnumerator SkillTime() {
        float timePassed = 0;
        while (timePassed < skilltime) {
            isActive = true;
            timePassed += Time.deltaTime;
            deletethis = timePassed;
            yield return null;
        }
        if (timePassed >= skilltime) {
            isActive = false;
            timePassed = skilltime;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldown);
        stminstance.isSkill2Active = false;
        Debug.Log("Cooldown2 terminou");
        StopCoroutine(Cooldown());
    }
}
