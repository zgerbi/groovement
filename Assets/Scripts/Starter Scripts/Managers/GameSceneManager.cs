using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    //Like the GameManager, this should be it's own gameobject

    [Tooltip("The black screen transition that will be used")]
    public GameObject Transition;

    public Button start;
    public Button credits;
    public Button quit;
    public Button back;

    [Tooltip("If you want to open this scene with a fade in")]
    public bool startWithFadeIn = true;
    // Start is called before the first frame update
    void Start()
    {
        if (startWithFadeIn)
        {
            StartCoroutine(FadeIn());
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            splash();
        }

        if (start)
            start.onClick.AddListener(newGame);
        if (credits)
            credits.onClick.AddListener(creditScreen);
        if (quit)
            quit.onClick.AddListener(quitGame);
        if (back)
            back.onClick.AddListener(goBack);
    }

    void newGame()
    {
        LoadScene(0);
    }

    void creditScreen()
    {
        LoadScene(3);
    }

    void quitGame()
    {
        Application.Quit();
    }

    void goBack()
    {
        LoadScene(2);
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        goBack();
    }

    void splash()
    {
        StartCoroutine(waiter());
    }

    //This function should be called to other scripts so that way you have the transition working
    public void LoadScene(int SceneIndex)
    {
        StartCoroutine(FadeOut());
        StartCoroutine(LoadAsyncScene(SceneIndex));
    }

    IEnumerator LoadAsyncScene(int SceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        Transition.SetActive(true);
        Transition.GetComponent<Animator>().SetBool("FadeIn", true);
        yield return new WaitForSeconds(1);
        Transition.GetComponent<Animator>().SetBool("FadeIn", false);
        Transition.SetActive(false);
    }

    public IEnumerator FadeOut()
    {
        Transition.SetActive(true);
        Transition.GetComponent<Animator>().SetBool("FadeOut", true);
        yield return new WaitForSeconds(1);
        Transition.GetComponent<Animator>().SetBool("FadeOut", false);
    }
}
