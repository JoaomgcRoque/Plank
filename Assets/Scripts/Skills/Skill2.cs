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

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
    }
    public void Skill2method() {
        StartCoroutine(SkillTime());
        playerinstance.AttackDamage = newDamage;
    }

    IEnumerator SkillTime() {
        float timePassed = 0;
        while (timePassed < skilltime) {
            timePassed += Time.deltaTime;
            yield return null;
        }
        if (timePassed >= skilltime) {
            playerinstance.AttackDamage = defaultDamage;
            stminstance.skills = SkillsSTM.Skills.noskill;
        }
    }
}
