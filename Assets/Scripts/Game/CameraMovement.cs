using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform john;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = john.position;
        newPosition.x = 0;
        newPosition.z = -1;
        if (newPosition.y < transform.position.y)
            newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
