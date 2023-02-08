using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEditorInternal;

public class Player1Controller : MonoBehaviour
{

    public float moveSpeed = 15f;
    private float _smoothFactor = 0.5f;

    public Transform GetItemPoint;
    private Camera _mainCamera;
    private bool _cameraIsDefined;
    private player1Arm _player1Arm;
    public bool p2 = false;
    
    void Awake()
    {
        _cameraIsDefined = (Camera.main != null);
        if(_cameraIsDefined)
            _mainCamera = Camera.main;
        _player1Arm = GetComponent<player1Arm>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = 0f;
        var moveY = 0f;
        if (p2)
        {
            moveX = Input.GetAxis("HorizontalP2");
            moveY = Input.GetAxis("VerticalP2");
        }
        else
        {
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical"); 
        }
        var translation = Vector3.Normalize(new Vector2(moveX, moveY)) * moveSpeed * Time.deltaTime;
        var smoothTranslation = Vector3.Lerp(Vector3.zero, translation, _smoothFactor);
        transform.Translate(smoothTranslation, Space.World);

    }
}
