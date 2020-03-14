using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    public Vector3 Offset;

    private void Start()
    {
        Offset = transform.position - Player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Player.transform.position + Offset;
    }
}
