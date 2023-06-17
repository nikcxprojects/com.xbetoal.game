using System;
using UnityEngine;

public class OverZone : MonoBehaviour
{
    public static Action OnCollisisonEnter { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollisisonEnter?.Invoke();
    }
}
