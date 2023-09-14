using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    int _rotationSpeed = 30;

    // Update is called once per frame
    void Update()
    {
            transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
