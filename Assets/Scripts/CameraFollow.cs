using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody2D target;

    private Vector3 defaultPosition;
    private float playerPosY;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosY < target.transform.position.y)
        {
            if (target.transform.position.y > 4.8)
            {
                transform.position = new Vector3(defaultPosition.x, target.transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = defaultPosition;
            }
            playerPosY = target.position.y;
        }
    }
}