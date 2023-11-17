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

        
    public void LoadNextScene()
    {
        sceneNum += 1;
        SceneManager.LoadScene(sceneNum);
        if (sceneNum == 4)
        {
            sceneNum = 1;
        }
    }
}
