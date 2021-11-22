using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform leftCheck;

    public Transform rightCheck;

    public Transform teleportLocationLeft;

    public Transform teleportLocationRight;

    public Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Linecast(transform.position, leftCheck.position, 1 << LayerMask.NameToLayer("Edges")))
        {
            player.transform.position = new Vector3(teleportLocationLeft.position.x, player.position.y, teleportLocationLeft.position.z);

        }else if (Physics2D.Linecast(transform.position, rightCheck.position, 1 << LayerMask.NameToLayer("Edges")))
        {
            player.transform.position = new Vector3(teleportLocationRight.position.x, player.position.y, teleportLocationRight.position.z);
        }
    }
}
