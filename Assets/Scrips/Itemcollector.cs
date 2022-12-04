using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Itemcollector : MonoBehaviour
{
    private int banana = 0;
    [SerializeField]private Text bananaText;
    [SerializeField] private AudioSource bananaAudioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("a"))
        {
            Destroy(collision.gameObject);
            banana++;
            bananaText.text="Banana: " + banana;
            bananaAudioSource.Play();
        }
    }
}
