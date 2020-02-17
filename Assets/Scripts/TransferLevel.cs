using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferLevel : MonoBehaviour
{
    [SerializeField]
    private string sceneName = "";

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log(sceneName + " loading...");
            SceneManager.LoadScene(sceneName);
        }
    }
}
