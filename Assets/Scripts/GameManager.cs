using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [HideInInspector]public BoardManager boardScript;

    private GameObject menuImage;
    private Button playButton;
    private Button resumeButton;

    private bool pause = true;

    void Awake () {
        boardScript = GetComponent<BoardManager>();
        menuImage = GameObject.Find("Menu");
        playButton = GameObject.Find("Play").GetComponent<Button>();
        resumeButton = GameObject.Find("Resume").GetComponent<Button>();
	}

    public void Pause()
    {
        Time.timeScale = 0;
        pause = true;
        menuImage.SetActive(true);
    }

    public void Play()
    {
        menuImage.SetActive(false);
        playButton.interactable = false;
        resumeButton.interactable = true;
        InitGame();
    }

    public void Resume()
    {
        menuImage.SetActive(false);
        pause = false;
        Time.timeScale = 1;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void InitGame()
    {
        boardScript.SetupScene();
        pause = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            Pause();
        }
	}
}
