using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollwingPlayer : MonoBehaviour
{
    public float FollowSpeed=7f;
    public Transform Player;

    private void Update()
    {
        if (this.Player == null) return;
        transform.position = Vector3.Slerp(transform.position, this.Player.position, FollowSpeed * Time.deltaTime);
    }
    //private void FixedUpdate()
    //{
    //    if (this.Player == null) return;
    //    transform.position = Vector3.Slerp(transform.position, this.Player.position, FollowSpeed * Time.deltaTime);

    //}
}
