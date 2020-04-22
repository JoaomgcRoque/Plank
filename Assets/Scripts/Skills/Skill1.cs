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
    [SerializeField] private float timePassed = 0;
    [SerializeField] private bool isActive = false;

    public float deletethis;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
        if (isActive == true) {
            timePassed += Time.deltaTime;
        }
        if (isActive == false) {
            timePassed = 0f;
        }
        Speed();
    }
    public void Skill1method() {
        isActive = true;
        stminstance.skills = SkillsSTM.Skills.noskill;
    }

    private void Speed() {
        if (timePassed < skilltime && isActive == true) {
            playerinstance.MoveSpeed = newSpeed;
            deletethis = timePassed;
        }
        if (timePassed > skilltime && isActive == true) {
            playerinstance.MoveSpeed = defaultspeed;
            isActive = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldown);
        stminstance.isSkill1Active = false;
        Debug.Log("Cooldown1 terminou");
        StopCoroutine(Cooldown());
    }
}
