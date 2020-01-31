using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    Rigidbody2D rigidBody;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontalMove, verticalMove);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        
        Vector2 position = rigidBody.position;
        position = position + move * speed * Time.deltaTime;

        rigidBody.MovePosition(position);
    }
}
