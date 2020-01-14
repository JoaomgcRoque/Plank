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
        while (enemyCount < 50)
        {
            xPos = Random.Range(-90, 90);
            zPos = Random.Range(-55, -75);
            Instantiate(theEnemy, new Vector3(xPos, 0.6f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3);
            enemyCount += 1;
        }
    }
}
