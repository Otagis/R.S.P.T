using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneLoader instance { get; private set; }
    public int sceneNum;
    private int puntos;
    private int vidas = 4;

    void Awake()
    {
        if (SceneLoader.instance == null)
        {
            SceneLoader.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
        
    public void LoadNextScene()
    {
        sceneNum += 1;
        SceneManager.LoadScene(sceneNum);
        if (sceneNum == 4)
        {
            sceneNum = 1;
        }
    }

    public void OnWin()
    {
        sceneNum += 1;
        SceneManager.LoadScene(sceneNum);
        if (sceneNum == 4)
        {
            sceneNum = 1;
        }
        puntos += 100;
    }

    public void OnLose()
    {
        sceneNum += 1;
        SceneManager.LoadScene(sceneNum);
        if (sceneNum == 4)
        {
            sceneNum = 1;
        }
        vidas -= 1;
    }
}
