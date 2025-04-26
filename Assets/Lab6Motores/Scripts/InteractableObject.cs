using System;
using UnityEngine;
using UnityEngine.Audio;


public class InteractableObject : MonoBehaviour
{
    [SerializeField] private AudioData audioData;
    [SerializeField] private AudioSettings audioSettings;

    public static event Action<AudioMixerGroup, AudioClip> OnCollisionMusic;
    public static event Action OnPlayNewMusic;
    public static event Action OnExitCollisionMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollisionMusic?.Invoke(audioSettings.AudioMixerGroup, audioData.AudioClip);
            OnPlayNewMusic?.Invoke();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            OnExitCollisionMusic?.Invoke();
        }
    }


}







