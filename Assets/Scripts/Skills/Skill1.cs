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

    public float deletethis;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
    }
    public void Skill1method() {
        StartCoroutine(SkillTime());
    }

    IEnumerator SkillTime() {
       float timePassed = 0;
       while(timePassed < skilltime)
       {
            timePassed += Time.deltaTime;
            playerinstance.MoveSpeed = newSpeed;
            deletethis = timePassed;
            yield return null;
        }
        if (timePassed >= skilltime) {
            playerinstance.MoveSpeed = defaultspeed;
            timePassed = skilltime;
            //stminstance.skills = SkillsSTM.Skills.noskill;
            //yield return null;
        }
    }

}
