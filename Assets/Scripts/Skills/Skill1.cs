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
        Debug.Log("skill1");
        StartCoroutine(SkillTime());
        //playerinstance.MoveSpeed = newSpeed;
    }


    IEnumerator SkillTime() {
        // stminstance.skills = SkillsSTM.Skills.noskill;

        float timePassed = 0; 
        while(timePassed < skilltime)
        {
            playerinstance.MoveSpeed = newSpeed;
            timePassed += Time.deltaTime;
            //yield return stminstance.skills = SkillsSTM.Skills.noskill;
            yield return null;
            //yield return playerinstance.MoveSpeed;
            playerinstance.MoveSpeed = defaultspeed;
            //yield return null;

        }
    }
}
