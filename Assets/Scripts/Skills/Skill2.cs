using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    [SerializeField] private PlayerController playerinstance;
    [SerializeField] private float newDamage;
    [SerializeField] private SkillsSTM stminstance;
    [SerializeField] private float skilltime;
    [SerializeField] private float defaultDamage;
    [SerializeField] private GameObject normalsword;
    [SerializeField] private GameObject redsword;
    [SerializeField] private bool isActive = false;

    public float deletethis;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();

        if(isActive == true) {
            normalsword.SetActive(false);
            redsword.SetActive(true);
        }
        if (isActive == false) {
            normalsword.SetActive(true);
            redsword.SetActive(false);
        }
    }
    public void Skill2method() {
        StartCoroutine(SkillTime());
        playerinstance.AttackDamage = newDamage;
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
            playerinstance.AttackDamage = defaultDamage;
            timePassed = skilltime;
            isActive = false;
            stminstance.isSkill2Active = false;
        }
    }
}
