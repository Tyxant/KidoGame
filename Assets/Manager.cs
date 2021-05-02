using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseObject;

    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnPause();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void OnPause()
    {
        if (pauseObject.activeInHierarchy)
        {
            pauseObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
