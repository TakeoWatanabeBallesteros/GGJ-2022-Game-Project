using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    int nextLvl;
    [SerializeField]
    float transitionTime;

    [SerializeField]
    Animator transition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadLevel());
        //SceneManager.LoadSceneAsync(nextLvl);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadLevel(){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(nextLvl);
    }
}
