using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Director director_controller;
    private Animator anim;
    private Vector3 initialPosition;
    private bool canGoUp;

    [SerializeField] public float jumpForce;

    void Start(){
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        director_controller = FindFirstObjectByType<Director>();
    }
    void Update(){
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if (canGoUp)
        {
            GoUp(jumpForce);
            canGoUp = false;
        }
    }
    public void GoUpKey()
    {
        canGoUp = true;
    }

    public void GoUp(float jumpForce){
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
