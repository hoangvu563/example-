using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] AudioSource Finishsound;
    private void Start()
    {
        Finishsound=GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Finishsound.Play();
            // dung lai 2s moi kich hoat man moi.
            Invoke("CompleteLevel1", 2f);
            if (SceneManager.GetActiveScene().buildIndex <= 1)
            {
                MovePlayer.LastCheckPoint = new Vector2(-11, 1);
                Debug.Log("hoang");
            }
        }  
    }
    private void CompleteLevel1()
    {
        //ham load man moi ==SceneManager.LoadScene
        //ham kich hoat man moi: SceneManager.GetActiveScene().buildIndex+1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
