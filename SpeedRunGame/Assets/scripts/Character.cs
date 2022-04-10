using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    const float moveSpeed = 4.0f;
    const float jumpPower = 12.5f;
    private bool jumpCheck = false;
    Rigidbody2D rg;
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && rg.velocity.y == 0)
        {
            jumpCheck = true;
            Jump();
        }
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
            moveVelocity = Vector3.left;
        else if (Input.GetAxisRaw("Horizontal") > 0)
            moveVelocity = Vector3.right;

        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if (!jumpCheck)
            return;

        rg.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rg.AddForce(jumpVelocity, ForceMode2D.Impulse);

        jumpCheck = false;
    }
}