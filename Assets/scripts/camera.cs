using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    
    public GameObject player;
    Vector3 offset;
    private bool flip = false;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
