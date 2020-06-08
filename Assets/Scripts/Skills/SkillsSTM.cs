using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public bool isSkill1Active = false;
    public bool isSkill2Active = false;
    public bool isSkill3Active = false;
    public bool isSkill4Active = false;

    public Skill1 skill1;
    public Skill2 skill2;
    public Skill3 skill3;
    public Skill4 skill4;

    public float deletethis;

    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip skill1clip;
    [SerializeField] private SkillsUI skillsui;

    private void Awake() {
        audiosource = GetComponent<AudioSource>();
    }

    private void Start() {
        skill1 = GetComponent<Skill1>();
        skill2 = GetComponent<Skill2>();
        skill3 = GetComponent<Skill3>();
        skill4 = GetComponent<Skill4>();
    }

    private void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.Alpha2) || (Input.GetAxisRaw("Skill2") > 0f) && 
           isSkill1 == true && isSkill1Active == false && skillsui.isActive[0] == false) {
        /*if ((Input.GetAxisRaw("Skill2") > 0f) &&
        isSkill1 == true && isSkill1Active == false && skillsui.isActive[0] == false) {*/
            isSkill1Active = true;
            skills = Skills.skill1;
            audiosource.clip = null;
            audiosource.clip = skill1clip;
            audiosource.Play();
            Debug.Log("Skill2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetAxisRaw("Skill1") > 0f)
           && isSkill2 == true && isSkill2Active == false && skillsui.isActive[1] == false)
        {
            isSkill2Active = true;
            skills = Skills.skill2;
            Debug.Log("Skill1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || (Input.GetAxisRaw("Skill3") > 0f)
           && isSkill3 == true && isSkill3Active == false && skillsui.isActive[2] == false)
        {
            isSkill3Active = true;
            skills = Skills.skill3;
            skill3.canThrow = true;
            Debug.Log("Skill3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || (Input.GetAxis("Skill4") > 0f)
            && isSkill4 == true && isSkill4Active == false && skillsui.isActive[3] == false) 
        {
            isSkill4Active = true;
            skills = Skills.skill4;
            Debug.Log("Skill4");
        }
        STM();
    }

    private void STM() {
        switch(skills) {
            case Skills.noskill:
                break;
            case Skills.skill1:
                skill1.Skill1method();
                break;
            case Skills.skill2:
                skill2.Skill2method();
                break;
            case Skills.skill3:
                skill3.Skill3method();
                break;
            case Skills.skill4:
                skill4.Skill4method();
                break;
            default:
                skills = Skills.noskill;
                break;
        }
    }
}
