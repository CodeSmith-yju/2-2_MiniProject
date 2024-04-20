using UnityEngine;

public class EffectSoundOnActive_Hover : MonoBehaviour
{
    public AudioClip soundClip;
    [Range(0.0f, 1.0f)] public float volume = 1.0f; // 볼륨을 조절할 변수를 추가합니다.

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
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = soundClip;
            audioSource.volume = volume; // 볼륨을 설정합니다.
            audioSource.enabled = true;

            if(audioSource.enabled)
            {
                audioSource.Play();
            }
          
            if(!audioSource.isPlaying)
            {
                audioSource.enabled = false;
                gameObject.SetActive(false);
            }
            
        }
    }
}
