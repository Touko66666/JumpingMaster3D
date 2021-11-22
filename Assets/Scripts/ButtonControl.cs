using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Button start;
    public Button continu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)) && start.isActiveAndEnabled)
        {
            start.onClick.Invoke();
        }
        else if((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)) && continu.isActiveAndEnabled)
        {
            continu.onClick.Invoke();
        }
    }
}
