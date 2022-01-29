using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    int nextLvl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadSceneAsync(nextLvl);
    }
}
