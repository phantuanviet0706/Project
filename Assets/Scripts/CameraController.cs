using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        
        transform.position = new Vector3(Mathf.Max(player.position.x, 20f), player.position.y, transform.position.z);
    }
}
