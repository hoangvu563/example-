using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public float maxHeath=100f;
    public float heath;
    public Slider SliderOfPlay;
    private void Start()
    {
        heath = maxHeath;
        SliderOfPlay.maxValue = maxHeath;
        SliderOfPlay.value= maxHeath;   
    }
    public void takeDamageOfPlayer(float Damage)
    {
        heath-=Damage;
        SliderOfPlay.value = heath;
        if(heath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
