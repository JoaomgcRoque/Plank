using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] private int enemycount;
    [SerializeField] private GameObject wavegameobject;
    [SerializeField] private EnemySpawner enemyspawner;
    [SerializeField] private LevelManager levelmanager;

    private void Awake() {
        wavegameobject.SetActive(false);
    }

    private void Start() {
        enemyspawner = GetComponent<EnemySpawner>();
        levelmanager = GetComponent<LevelManager>();
    }

    private void Update() {
        enemycount = enemyspawner.enemyCount;
        if(levelmanager.numberofdead == enemyspawner.enemyCount) {
            wavegameobject.SetActive(true);
        }
    }
}
