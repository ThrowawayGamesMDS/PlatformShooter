using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour {

    public Button PlayButton, HelpButton, QuitButton;
    // Use this for initialization
    void Start () {
        Debug.Log("star1");
        Button play = PlayButton.GetComponent<Button>();
        Button help = HelpButton.GetComponent<Button>();
        Button quit = QuitButton.GetComponent<Button>();

        Debug.Log("star2");
        play.onClick.AddListener(Letplay);
        help.onClick.AddListener(HELP);
        quit.onClick.AddListener(Leave);

        Debug.Log("star3");
    }
    void Update()
    {
    }

        // Update is called once per frame
        void Letplay()
    {
        Debug.Log("go");
        SceneManager.LoadScene("game");
        
    }
    void HELP()
    {
        Debug.Log("help");
        SceneManager.LoadScene("mainmenu");

    }
    void Leave()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
