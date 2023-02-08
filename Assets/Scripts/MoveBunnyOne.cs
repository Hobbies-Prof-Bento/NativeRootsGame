using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBunnyOne : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 moveVector = Vector2.right;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveVector*speed);
    }
}
