using UnityEngine;

public class EffectSoundOnActive : MonoBehaviour
{
    public AudioClip soundClip;
    [Range(0.0f, 1.0f)] public float volume = 1.0f; // ������ ������ ������ �߰��մϴ�.

    private void Update()
    {
        if (soundClip != null && gameObject.GetComponent<AudioSource>() == null)
        {
            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        if (soundClip != null)
        {   
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = soundClip;
            audioSource.volume = volume; // ������ �����մϴ�.
            audioSource.Play();

            Destroy(audioSource, soundClip.length);
        }
    }
}
