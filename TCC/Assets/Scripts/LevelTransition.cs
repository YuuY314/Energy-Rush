using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    public float transitionTimeFadeOut;
    public static LevelTransition instance;

    void Start()
    {
        instance = this;
    }

    public IEnumerator Transition(string levelName)
    {
        transition.SetBool("Start", true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }

    // public IEnumerator Transition()
    // {
    //     transition.SetBool("Start", true);
    //     yield return new WaitForSeconds(transitionTimeFadeOut);
    //     transition.SetBool("Start", false);
    // }
}
