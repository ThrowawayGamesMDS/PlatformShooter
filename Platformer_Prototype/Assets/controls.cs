using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controls : MonoBehaviour {
    public Button backButton;
    // Use this for initialization
    void Start () {
        Button Back = backButton.GetComponent<Button>();

        Back.onClick.AddListener(mainmenu);
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
