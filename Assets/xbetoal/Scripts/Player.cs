using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float jumpForce = 5.0f;
    private Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);
        Follower.Target = transform;
    }

    public void Jump(int direction)
    {
        Rigidbody.velocity = Vector2.zero;

        var jumpDirection = direction > 0 ? new Vector2(1, 1) : new Vector2(-1, 1);
        Rigidbody.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }
}
