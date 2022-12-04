using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //khi vien dan cham vao doi tuong co gan tag enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //goi class enemy ben kia
            gameObject.TryGetComponent<Enemy>(out Enemy component);
            
            component.Takedamage(1);
            Destroy(gameObject);
        }

    }
}
