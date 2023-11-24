using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneLoader instance { get; private set; }
    public int sceneNum;
    private int puntos;
    private int vidas;
    public Text scoreText;
    public Text livesText;
    public GameObject gameOverCanvas;
    public GameObject scoreAndLivesCanvas;
    public GameObject mainHud;
    public AudioSource src;
    public AudioClip sfxMeteorite;

    void Update()
    {
        scoreText.text = "Score: " + puntos.ToString();
        livesText.text = "Lives: " + vidas.ToString();
        if (sceneNum == 0)
        {
            scoreAndLivesCanvas.SetActive(false);
            gameOverCanvas.SetActive(false);
            puntos = 0;
            vidas = 4;
        }
        if (vidas <= 0)
        {
            StartCoroutine(WaitBeforeMenuScreen());
        }
    } 

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
        mainHud.SetActive(false);
        sceneNum += 1;
        SceneManager.LoadScene(sceneNum);
        if (sceneNum == 4)
        {
            sceneNum = 0;
        }
        scoreAndLivesCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Explosion()
    {
        src.clip = sfxMeteorite;
        src.Play();
    }

    public void OnWin()
    {
        sceneNum += 1;
        if (sceneNum == 4)
        {
            sceneNum = 1;
        }
        puntos += 100;
        StartCoroutine(WaitBeforeTransition());
    }

    public void OnLose()
    {
        if (vidas > 0)
        {
            sceneNum += 1;
            if (sceneNum == 4)
            {
                sceneNum = 1;
            }
            vidas -= 1;
            StartCoroutine(WaitBeforeTransition());
        }
        else if (vidas == 0)
        {
            Debug.Log("Game over sending you to the menu");
        }
    }

    private IEnumerator WaitBeforeTransition()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneNum);
        Debug.Log("Done!");
        StopAllCoroutines();
    }
    private IEnumerator WaitBeforeMenuScreen()
    {
        gameOverCanvas.SetActive(true);
        Debug.Log("Waiting");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
        sceneNum = 0;
        mainHud.SetActive(true);
        Debug.Log("Done!");
        StopAllCoroutines();
    }
}
