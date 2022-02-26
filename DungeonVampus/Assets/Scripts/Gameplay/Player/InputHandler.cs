using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal { get; set; }
    public float vertical { get; set; }
    public bool leftMouseButton { get; set; }
    public bool rightMouseButton { get; set; }


    void Update()
    {
        leftMouseButton = Input.GetMouseButtonDown(0);
        rightMouseButton = Input.GetMouseButtonDown(1);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        

    }
}
