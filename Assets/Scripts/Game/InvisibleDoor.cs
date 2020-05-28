using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleDoor : MonoBehaviour
{
    [SerializeField] private GameObject invisibledoor;
    [SerializeField] private LevelManager levelmanager;
    [SerializeField] private int killnumber;
    [SerializeField] private GameObject Objective;

    private void Start() {
        invisibledoor.SetActive(true);
        Objective.SetActive(false);
    }

    private void Update() {
        levelmanager = GameObject.Find("GameManager").GetComponent<LevelManager>();
        if (levelmanager.numberofdead == killnumber) {
            invisibledoor.SetActive(false);
            Objective.SetActive(true);
        }
    }
}
