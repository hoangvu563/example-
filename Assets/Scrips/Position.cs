using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
   private static Position intance;
    public static Position Intance { get { return intance; } }
     public Transform positionOfPlayer;
    private void Awake()
    {
        Position.intance = this;
    }
    //private void Start()
    //{
    //    this.positionOfPlayer = transform.parent;
    //}
    void Update()
    {
        this.positionOfPlayer = transform.parent;
    }
}
