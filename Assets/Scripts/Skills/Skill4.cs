using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    [SerializeField] private PlayerController playerinstance;
    [SerializeField] private SkillsSTM stminstance;
    [SerializeField] private GameObject burp;
    [SerializeField] private float burptime;

    public float deletethis;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
    }

    public void Skill4method() {
        Debug.Log("skill4");
        StartCoroutine(SkillTime());
    }

    IEnumerator SkillTime() {
        float timePassed = 0;
        while (timePassed < burptime) {
            timePassed += Time.deltaTime;
            deletethis = timePassed;
            burp.SetActive(true);
            yield return null;
        }
        if (timePassed >= burptime) {
            burp.SetActive(false);
            timePassed = burptime;
            stminstance.isSkill4Active = false;
        }
    }
}
