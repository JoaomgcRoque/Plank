using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    [SerializeField] private PlayerController playerinstance;
    [SerializeField] private SkillsSTM stminstance;
    [SerializeField] private GameObject burp;
    [SerializeField] private float burptime;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
    }

    public void Skill4method() {
        Debug.Log("skill4");
        StartCoroutine(SkillTime());
        Burp();
    }

    void Burp() {
        burp.SetActive(true);
    }

    IEnumerator SkillTime() {
        yield return new WaitForSeconds(burptime);
        burp.SetActive(false);
        stminstance.skills = SkillsSTM.Skills.noskill;
    }
}
