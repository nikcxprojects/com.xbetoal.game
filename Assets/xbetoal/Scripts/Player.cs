using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private const float jumpForce = 5.0f;
    private Rigidbody2D Rigidbody { get; set; }

    private int score;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        score = 0;
        scoreText.text = $"{score}";

        Camera.main.transform.position = new Vector3(0, 0, -10);

        Follower.Target = transform;
        Generator.Target = transform;
    }

    private void Update()
    {
        if (Rigidbody.velocity.y < 0)
        {
            return;
        }

        score = Mathf.FloorToInt(transform.position.y);
        if(score <= 0)
        {
            score = 0;
        }

        scoreText.text = $"{score}";
    }

    public void Jump(int direction)
    {
        Rigidbody.velocity = Vector2.zero;

        var jumpDirection = direction > 0 ? new Vector2(1, 1) : new Vector2(-1, 1);
        Rigidbody.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }
}
