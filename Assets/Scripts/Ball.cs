using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.66f;
    public float moveSpeed = 1.0f;
    public float maxYStart = 3.5f;
    public float startX = 0;
    public float speedMultiplier = 1.1f;



    void Start()
    {
        InitialPush();
        GameManager.instance.onReset += ResetBall;

    }
    private void ResetBallPosition()
    {
        float posY = Random.Range( -maxYStart, maxYStart );
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }
    private void InitialPush()
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.right : Vector2.left;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.velocity = dir * moveSpeed;
    }
    private void ResetBall()
    {
        ResetBallPosition();
        InitialPush();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();  
        if (scoreZone) {
            GameManager.instance.OnScoreZoneReached(scoreZone.id);
            ResetBall();
            InitialPush();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if (paddle)
        {
            rb2d.velocity *= speedMultiplier;

        }
    }
}
