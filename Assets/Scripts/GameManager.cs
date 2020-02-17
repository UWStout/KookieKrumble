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
    public GameObject Text;
    public string WinSendScreen;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // This is a singleton
            DestroyImmediate(this.gameObject);
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
        Text.GetComponent<Text>().text = BabyCookies.ToString() + "/" + TotalBabyCookies.ToString() + " Cookies Left To Save";
        if (BabyCookies == 0)
        {
            SceneManager.LoadScene(WinSendScreen);
        }
    }
}
