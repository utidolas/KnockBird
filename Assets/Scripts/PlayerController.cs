using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Director director_controller;
    private Vector3 initialPosition;

    [SerializeField] public float jumpForce;

    void Start(){
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        director_controller = FindFirstObjectByType<Director>();
    }
    void Update(){
        if (Input.GetButtonDown("Fire1"))
        {
            GoUp(jumpForce);
        } 
    }

    void GoUp(float jumpForce){
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        rb.simulated = false;
        director_controller.EndGame();  
    }

    public void Restart()
    {
        rb.simulated = true;
        transform.position = initialPosition;
    }
}
