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


    void Start()
    {
        InitialPush();
    }
    private void ResetBall()
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();  
        if (scoreZone) {
            ResetBall();
            InitialPush();
        }
    }
}
