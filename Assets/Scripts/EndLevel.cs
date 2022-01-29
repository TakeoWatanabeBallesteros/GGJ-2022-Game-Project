using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    int nextLvl;
    [SerializeField]
    float transitionTime = 1.0f;
    [SerializeField]
    bool player1;
    [SerializeField]
    bool player2;

    [SerializeField]
    Animator transition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer ("Player_1")){
            player1 = true;
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer ("Player_2")){
            player2 = true;
        }
        if(player1 && player2) StartCoroutine(LoadLevel());
        
        //SceneManager.LoadSceneAsync(nextLvl);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer ("Player_1")){
            player1 = true;
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer ("Player_2")){
            player2 = true;
        }
    }

    IEnumerator LoadLevel(){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextLvl);
    }
}
