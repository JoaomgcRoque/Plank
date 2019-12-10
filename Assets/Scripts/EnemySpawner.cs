using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 5)
        {
            xPos = Random.Range(-20, 0);
            zPos = Random.Range(0, 16);
            Instantiate(theEnemy, new Vector3(xPos, 0.6f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3);
            enemyCount += 1;
        }
    }
}
