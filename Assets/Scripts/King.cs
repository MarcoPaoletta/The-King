using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public float jump_force;
    public GameManager game_manager;

    private Rigidbody2D rigidbody;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("jumping", true);
            rigidbody.AddForce(new Vector2(0, jump_force));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // the tag is like a group or a class_name in godot
        if (collision.gameObject.tag == "floor") 
        {
            animator.SetBool("jumping", false);
        }

        if (collision.gameObject.tag == "obstacle")
        {
            game_manager.game_over = true;
        }
    }
}
