using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    [SerializeField] private PlayerController playerinstance;
    [SerializeField] private SkillsSTM stminstance;
    [SerializeField] private GameObject bomb;
    [SerializeField] private float skilltime;
    [SerializeField] public bool canThrow = true;
    [SerializeField] private Transform hand;

    public float deletethis;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
    }

    public void Skill3method() {
        StartCoroutine(SkillTime());
        Debug.Log("skill3");
        Throw();
    }

    private void Throw() {
        if(canThrow == true) {
            Debug.Log("Throw");
            Instantiate(bomb, hand.transform.position, hand.transform.rotation);
            canThrow = false;
        }
    }

    IEnumerator SkillTime() {
        float timePassed = 0;
        while (timePassed < skilltime) {
            timePassed += Time.deltaTime;
            deletethis = timePassed;
            yield return null;
        }
        if (timePassed >= skilltime) {
            canThrow = false;
            timePassed = skilltime;
        }
    }
 }

