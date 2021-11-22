using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Button restart;

    public Text gameOver;

    public GameObject player;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));

        if (player.transform.position.y + 1.0f < screenBounds.y)
        {
            gameOver.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
    }
}
