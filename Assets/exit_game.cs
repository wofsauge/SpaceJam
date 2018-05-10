using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit_game : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject.Find("Button_Exit").GetComponent<Button>().onClick.AddListener(delegate { closeGame(); });
    }
	
	// Update is called once per frame
	void closeGame()
    {
    }
}
