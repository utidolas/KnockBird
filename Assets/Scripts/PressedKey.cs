using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PressedKey : MonoBehaviour
{
    [SerializeField] private UnityEvent whenKeyPressed;

    [SerializeField] private KeyCode keyPlayerJump;

   
    private void Update()
    {
        if (Input.GetKeyDown(keyPlayerJump))
        {
            whenKeyPressed.Invoke();
        }
    }
}
