using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAble : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField]
    private float freaquency = 5f;
    [SerializeField]
    private float magnitude = 5f;
    [SerializeField]
    private float offset = 0f;
    [SerializeField]
    private bool leftright = true;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        if (leftright) transform.position = startPosition + transform.right*Mathf.Sin(Time.time*freaquency+offset) * magnitude;
        else transform.position = startPosition + transform.up * Mathf.Sin(Time.time * freaquency + offset) * magnitude;
    }
}
