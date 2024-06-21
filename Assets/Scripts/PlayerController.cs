using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    [SerializeField] UnityEvent whenGameOver;
    [SerializeField] UnityEvent whenPassObstacle;
    [SerializeField] UnityEvent whenFailObstacle;
    private BotScript bot_controller;
    public StatusScript status_controller;
    private PressedKey pressedKey_controller;
    private Animator anim;
    private Vector3 initialPosition;
    private bool canGoUp;
    

    [SerializeField] public float jumpForce;

    void Start(){
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pressedKey_controller = GetComponent<PressedKey>();
        status_controller = GetComponent<StatusScript>();
        bot_controller = FindFirstObjectByType<BotScript>();
    }
    void Update(){
        anim.SetFloat("yVelocity", rb.velocity.y);

        //Debug.Log(string.Format("Player: {0} / Bot: {1}", status_controller.isAlive, bot_controller.status_controller.isAlive));
    }

    private void FixedUpdate()
    {
        if (canGoUp)
        {
            GoUp(jumpForce);
            canGoUp = false;
        }
    }
    public void DoGoUp()
    {
        canGoUp = true;
    }

    public void GoUp(float jumpForce){
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        whenFailObstacle.Invoke();
        rb.simulated = false;
        status_controller.isAlive = false;
        pressedKey_controller.enabled = false;
        if (!status_controller.isAlive && !bot_controller.status_controller.isAlive)
        {
            whenGameOver.Invoke();  
        }
    }

    public void Restart()
    {
        rb.simulated = true;
        pressedKey_controller.enabled = true;
        status_controller.isAlive = true;
        transform.position = initialPosition;
    }

    public void OnTriggerEnter2D()
    {
        whenPassObstacle.Invoke();
    }

    public void Falling()
    {
        float yPos = transform.position.y;
        while(yPos > -3.9f)
        {
            yPos--;
        }
    }
}
