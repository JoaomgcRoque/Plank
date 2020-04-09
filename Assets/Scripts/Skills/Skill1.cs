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
    }
    public void Skill1method() {
        //StartCoroutine(SkillTime());
        if(timePassed < skilltime) {
            playerinstance.MoveSpeed = newSpeed;
            deletethis = timePassed;
        }
        if (timePassed > skilltime) {
            playerinstance.MoveSpeed = defaultspeed;
            stminstance.isSkill1Active = false;
            //timePassed = skilltime;
        }
    }

    /*IEnumerator SkillTime() {
       float timePassed = 0;
       while(timePassed < skilltime)
       {
            timePassed += Time.deltaTime;
            playerinstance.MoveSpeed = newSpeed;
            deletethis = timePassed;
            yield return null;
        }
        if (timePassed > skilltime) {
            playerinstance.MoveSpeed = defaultspeed;
            timePassed = skilltime;
            //stminstance.skills = SkillsSTM.Skills.noskill;
            //yield return null;
        }
    }*/

}
