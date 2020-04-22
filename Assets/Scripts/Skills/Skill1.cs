using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    [SerializeField] private PlayerController playerinstance;
    [SerializeField] private float newSpeed;
    [SerializeField] private SkillsSTM stminstance;
    [SerializeField] public float skilltime;
    [SerializeField] private float defaultspeed;
    [SerializeField] private float cooldown;
    private float timePassed = 0;

    public float deletethis;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
        if (stminstance.skills == SkillsSTM.Skills.skill1) {
            timePassed += Time.deltaTime;
        }
        if (stminstance.skills == SkillsSTM.Skills.noskill) {
            timePassed = 0f;
        }
        /*if (stminstance.isSkill1Active == false) {
            stminstance.skills = SkillsSTM.Skills.noskill;
            StartCoroutine(Cooldown());
        }*/
    }
    public void Skill1method() {
        //StartCoroutine(SkillTime());
        if(timePassed < skilltime) {
            playerinstance.MoveSpeed = newSpeed;
            deletethis = timePassed;
        }
        if (timePassed > skilltime) {
            playerinstance.MoveSpeed = defaultspeed;
            //stminstance.isSkill1Active = false;
            //timePassed = skilltime;
            stminstance.skills = SkillsSTM.Skills.noskill;
            StartCoroutine(Cooldown());
        }

        /*if (stminstance.isSkill1Active == false) {
            stminstance.skills = SkillsSTM.Skills.noskill;
            StartCoroutine(Cooldown());
        }*/
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldown);
        stminstance.isSkill1Active = false;
        Debug.Log("Cooldown terminou");
        StopCoroutine(Cooldown());
    }
}
