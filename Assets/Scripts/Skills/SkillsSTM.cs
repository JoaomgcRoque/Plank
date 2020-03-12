using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsSTM : MonoBehaviour
{
    public enum Skills
    {
        noskill,
        skill1,
        skill2,
        skill3,
        skill4,
        skill5
    }

    public Skills skills;

    public float cooldown;
    public bool canClick = true;

    public bool isSkill1 = false;
    public bool isSkill2 = false;
    public bool isSkill3 = false;
    public bool isSkill4 = false;
    public bool isSkill5 = false;

    public Skill1 skill1;
    public Skill2 skill2;
    public Skill3 skill3;
    public Skill4 skill4;
    public Skill5 skill5;

    private void Start() {
        skill1 = GetComponent<Skill1>();
        skill2 = GetComponent<Skill2>();
        skill3 = GetComponent<Skill3>();
        skill4 = GetComponent<Skill4>();
        skill5 = GetComponent<Skill5>();
    }

    private void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.Alpha1) && 
           isSkill1 == true && canClick == true) 
        {
            skills = Skills.skill1;
            canClick = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)
           && isSkill2 == true && canClick == true)
        {
            skills = Skills.skill2;
            canClick = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)
           && isSkill3 == true && canClick == true)
        {
            skills = Skills.skill3;
            canClick = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)
            && isSkill4 == true && canClick == true) 
        {
            skills = Skills.skill4;
            canClick = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) 
           && isSkill5 == true && canClick == true)
        {
            skills = Skills.skill5;
            //canClick = false;
        }
        STM();
    }

    private void STM() {
        switch(skills) {
            case Skills.noskill:
                //Debug.Log("no skills");
                break;
            case Skills.skill1:
                //Debug.Log("skill1");
                skill1.Skill1method();
                StartCoroutine(Cooldown());
                //skills = Skills.noskill;
                break;
            case Skills.skill2:
                //Debug.Log("skill2");
                skill2.Skill2method();
                StartCoroutine(Cooldown());
                //skills = Skills.noskill;
                break;
            case Skills.skill3:
                //Debug.Log("skill3");
                skill3.Skill3method();
                StartCoroutine(Cooldown());
                //skills = Skills.noskill;
                break;
            case Skills.skill4:
                //Debug.Log("skill4");
                skill4.Skill4method();
                StartCoroutine(Cooldown());
                //skills = Skills.noskill;
                break;
            case Skills.skill5:
                //Debug.Log("skill5");
                skill5.Skill5method();
                StartCoroutine(Cooldown());
                //skills = Skills.noskill;
                break;
            default:
                skills = Skills.noskill;
                break;
        }
    }
    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldown);

        canClick = true;

        skills = Skills.noskill;
    }
}
