using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector2 position = rigidBody.position;
        position.x = position.x + speed * horizontalMove * Time.deltaTime;
        position.y = position.y + speed * verticalMove * Time.deltaTime;

        rigidBody.MovePosition(position);
    }
}
