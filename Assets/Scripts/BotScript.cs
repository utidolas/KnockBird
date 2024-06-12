using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 

public class BotScript : MonoBehaviour
{
    [SerializeField] UnityEvent whenPassObstacle;
    [SerializeField] UnityEvent whenCollide;

    private Animator anim;
    public StatusScript status_controller;
    private PlayerController player_controller;
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce;

    private bool canGoUp;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        status_controller = GetComponent<StatusScript>();
        rb = GetComponent<Rigidbody2D>();
        player_controller = FindFirstObjectByType<PlayerController>();
        StartCoroutine(Boost());
    }

    void Update()
    {
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

    //********** Flying **********

    private void GoUp(float jumpForce)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void DoGoUp()
    {
        canGoUp = true;
    }

    private IEnumerator Boost()
    {
        while (true)
        {
            yield return new WaitForSeconds(.7f);
            DoGoUp();

        }
    }
    //******************************

    //********** Restart **********
    public void Restart()
    {
        rb.simulated = true;
        status_controller.isAlive = true;
        transform.position = initialPosition;
    }
    //******************************

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.simulated = false;
        status_controller.isAlive = false;
        if (!status_controller.isAlive && !player_controller.status_controller.isAlive)
        {
            whenCollide.Invoke();
        }
    }

    public void OnTriggerEnter2D()
    {
        whenPassObstacle.Invoke();
    }
}
