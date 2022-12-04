using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Traps : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource diesound;
   
    private void Start()
    {
        rb=transform.GetComponent<Rigidbody2D>();   
        ani =transform.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
            diesound.Play();
        }
    }
    private void Die()
    {
        ani.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void RestartLevel()
    {
        //SU KIEN XAY RA TRONG ANIMOTOR
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.LogWarning("hoang");
    }
}
