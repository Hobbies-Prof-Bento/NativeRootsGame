using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Arm : MonoBehaviour {
    public GameObject rootInHand;
    
    public bool player1WithItem = false;
    private Player1Controller _player1Controller;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        _player1Controller = GetComponent<Player1Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    public void GetItem()
    {
        player1WithItem = true;
        rootInHand.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void PutItem()
    {
        player1WithItem = false;
        rootInHand.GetComponent<SpriteRenderer>().enabled = false;
    }
}
