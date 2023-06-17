using UnityEngine;

public class Result : MonoBehaviour
{
    private AudioSource Source { get; set; }

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (SettingsManager.SoundsEnabled)
        {
            Source.Play();
        }
    }
}
