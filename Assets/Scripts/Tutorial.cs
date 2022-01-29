using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    string[] txt;
    [SerializeField]
    GameObject elementToShow;
    [SerializeField]
    Text displayedTxt;

    private void Start()
    {
        displayedTxt.text = "";
        for (int i = 0; i < txt.Length; i++)
        {
            displayedTxt.text += txt[i];
            if(i< txt.Length -1) displayedTxt.text += "\n";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        elementToShow.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
