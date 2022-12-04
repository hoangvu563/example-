using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelBoss : MonoBehaviour
{
    private void OnDestroy()
    {
        //load man choi moi them 1 level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
