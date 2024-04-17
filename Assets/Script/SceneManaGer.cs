using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaGer : MonoBehaviour
{
    public static SceneManaGer instance;

    private Animator m_Animator;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        m_Animator = GetComponentInChildren<Animator>();
    }
    public void NextLevel()
    {
        StartCoroutine(Load());
    }
    public void ResetLevel()
    {
        StartCoroutine(ResetScene());
    }
    private IEnumerator ResetScene()
    {
        m_Animator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        m_Animator.SetTrigger("Start");
    }
    private IEnumerator Load()
    {
        m_Animator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        m_Animator.SetTrigger("Start");
    }
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadSceneAsync(nameScene);
    }
}
