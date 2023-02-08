using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public AudioSource endGameSound;
    public AudioSource gameSound;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Xama;
    public GameObject TextoPlayer1;
    public GameObject TextoPlayer2;
    public GameObject Timer;
    public GameObject EndGame;
    
    public List<GameObject> Roots = new List<GameObject>();
    public int pointsP1 = 0;
    public int pointsP2 = 0;
    private int activeRoots = 0;
    private int timer = 180;
    private float sCounter = 0;
    


    private void Start()
    {
        SpawnRoots();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var value in Roots)
        {
            var dist = Vector2.Distance(Player1.transform.position, value.transform.position);
            if (dist < 0.5 && Input.GetKeyDown("f") && !Player1.GetComponent<player1Arm>().player1WithItem)
            {
                Player1.GetComponent<player1Arm>().GetItem();
                value.GetComponent<SpriteRenderer>().enabled = false;
            }
            dist = Vector2.Distance(Player2.transform.position, value.transform.position);
            if (dist < 0.5 && Input.GetKeyDown(KeyCode.Return) && !Player2.GetComponent<player1Arm>().player1WithItem)
            {
                Player2.GetComponent<player1Arm>().GetItem();
                value.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        var distXamaP1 = Vector2.Distance(Player1.transform.position, Xama.transform.position);
        var distXamaP2 = Vector2.Distance(Player2.transform.position, Xama.transform.position);

        if (distXamaP1 < 0.5 && Player1.GetComponent<player1Arm>().player1WithItem)
        {
            Player1.GetComponent<player1Arm>().PutItem();
            pointsP1++;
            TextoPlayer1.GetComponent<TextMeshProUGUI>().text = "Player 1: " + pointsP1.ToString();
            SpawnRoots();
            activeRoots--;
        }
        if (distXamaP2 < 0.5 && Player2.GetComponent<player1Arm>().player1WithItem)
        {
            Player2.GetComponent<player1Arm>().PutItem();
            pointsP2++;
            TextoPlayer2.GetComponent<TextMeshProUGUI>().text = "Player 2: " + pointsP2.ToString();
            SpawnRoots();
            activeRoots--;
        }

        sCounter += Time.deltaTime;
        if (sCounter > 1)
        {
            sCounter = 0f;
            timer--;

            var minutes = math.floor(timer / 60);
            var seconds = timer % 60;

            if (timer <= 0)
            {
                Time.timeScale = 0;
                EndGame.SetActive(true);
                gameSound.Stop();
                endGameSound.Play();
            }
            else
            {
                endGameSound.Stop();
                gameSound.Play();
            }
            
            Timer.GetComponent<TextMeshProUGUI>().text = minutes.ToString() + ":" + seconds.ToString("D2");
            
        }
    }

    void SpawnRoots()
    {
        foreach (var value in Roots)
        {
            var result = Random.Range(0, 2);
            if (result == 1 && activeRoots <2 && value.GetComponent<SpriteRenderer>().enabled == false)
            {
                activeRoots++;
                value.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        if (activeRoots < 2)
        {
            SpawnRoots();
        }
    }
}
