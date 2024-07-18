using System.Collections;
using System.Collections.Generic;
using Cainos.LucidEditor;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = UnityEngine.Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (horizontalInput < -0.01)
            transform.localScale = new Vector3(-4, 4, 4);

        if (UnityEngine.Input.GetKey(KeyCode.Space) || UnityEngine.Input.GetKeyDown(KeyCode.W))
            body.velocity = new Vector2(body.velocity.x, speed);

        anim.SetBool("run", horizontalInput != 0);
    }
}
