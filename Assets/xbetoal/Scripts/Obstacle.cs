using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 RotDirection { get; set; }

    private void Start()
    {
        RotDirection = Random.Range(0, 100) > 50 ? Vector3.forward : Vector3.back;
    }

    private void Update()
    {
        transform.Rotate(120.0f * Time.deltaTime * RotDirection);
    }
}
