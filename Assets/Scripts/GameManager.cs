using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int BabyCookies = 0;
    public int TotalBabyCookies = 0;
    public GameObject CookiesText;
    public GameObject DeathImage;
    public GameObject WinImage;

    public enum GameStates
    {
        Playing,
        PlayerDead,
        LevelBeat
    }

    private GameStates gameState = GameStates.Playing;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("BabyCookie");
        foreach (GameObject cookie in objs)
        {
            BabyCookies += 1;
            TotalBabyCookies += 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        CookiesText.GetComponent<Text>().text = BabyCookies.ToString() + "/" + TotalBabyCookies.ToString() + " Cookies Left To Save";

        if (BabyCookies == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameState = GameStates.LevelBeat;
        }

        if (gameState == GameStates.PlayerDead)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (gameState == GameStates.LevelBeat)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("The player peat level " + SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                DeathImage.SetActive(true);
                gameState = GameStates.Playing;
            }
        }
    }

    public void OnPlayerDeath()
    {
        Debug.Log("The player just died");
        WinImage.SetActive(true);
        gameState = GameStates.PlayerDead;
    }
}
