using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPage(string buttonName)
    {
        soundEffect.Play();

        if (buttonName == "Tutorial")
        { 
            Debug.Log("tutorial");
        }

        if (buttonName == "Play")
        {
            SceneManager.LoadScene("Game");
        }
        //SceneManager.LoadScene(game);

        if (buttonName == "Exit")
        { 
            Application.Quit();
        }
    }
}
