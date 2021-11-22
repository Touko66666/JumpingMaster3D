using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    public float score;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (score < player.transform.position.y)
        {
            scoreText.text = "Score: " + score.ToString("0");
            score = player.transform.position.y;
        }
    }
}
