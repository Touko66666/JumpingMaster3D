using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTimer : MonoBehaviour
{
    private float secondCounter;
    private float seconds;

    private GameObject player;

    private bool playerMoved = false;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startPos = player.transform.position;
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(startPos, player.transform.position) > 0.1f)
        {
             playerMoved = true;
        }

        if (playerMoved)
        {
            secondCounter = 1f;
            seconds += secondCounter * Time.deltaTime;

            if (seconds > 8)
            {
                transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}

