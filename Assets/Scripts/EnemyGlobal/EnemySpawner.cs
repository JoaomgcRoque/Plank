using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int enemyCount;

    public int xPos;
    public int xPosLesserLimit;
    public int xPosBiggerLimit;

    public int zPos;
    public int zPosLesserLimit;
    public int zPosBiggerLimit;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount > 0)
        {
            xPos = Random.Range(xPosLesserLimit, xPosBiggerLimit);
            zPos = Random.Range(zPosLesserLimit, zPosBiggerLimit);
            Instantiate(theEnemy, new Vector3(xPos, 0.6f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5);
            enemyCount -= 1;
        }
        if(enemyCount <= 0) {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject go in gos) {
                Destroy(go);
            }
        }
    }
}
