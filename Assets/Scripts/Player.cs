using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float forceImpucle = 10;
    [SerializeField] float delay = 3;
    [SerializeField] float speed = 3;
    Vector2 move;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Jump());
    }

    private void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        rb.AddForce(move * speed, ForceMode2D.Force);
    }

    private IEnumerator Jump()
    {
        yield return new WaitForSecondsRealtime(delay);
        rb.AddForce(Vector2.up * forceImpucle, ForceMode2D.Impulse);
        StartCoroutine(Jump());
    } 
}
