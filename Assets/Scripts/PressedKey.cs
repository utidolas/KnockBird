using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressedKey : MonoBehaviour
{
    private PlayerController player_controller;

    [SerializeField] private KeyCode keyPlayerJump;
    private void Start()
    {
        player_controller = GetComponent<PlayerController>();
    }

   
    private void Update()
    {
        if (Input.GetKeyDown(keyPlayerJump))
        {
            player_controller.GoUpKey();
        }
    }
}
