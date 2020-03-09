using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    [SerializeField] private PlayerController playerinstance;
    [SerializeField] private float newSpeed;
    [SerializeField] private SkillsSTM stminstance;
    [SerializeField] private float skilltime;
    [SerializeField] private float defaultspeed;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
    }
    public void Skill1method() {
        StartCoroutine(SkillTime());
        playerinstance.MoveSpeed = newSpeed;
    }

    IEnumerator SkillTime() {
       float timePassed = 0; 
       while(timePassed < skilltime)
       {
            timePassed += Time.deltaTime;
            yield return null;
       }
       if(timePassed >= skilltime) {
            playerinstance.MoveSpeed = defaultspeed;
            stminstance.skills = SkillsSTM.Skills.noskill;
        }
    }

}
