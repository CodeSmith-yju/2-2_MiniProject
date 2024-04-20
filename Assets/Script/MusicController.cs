using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // 지정한 음악 AudioSource
    public AudioSource musicSource;

    // 오브젝트 1
    public GameObject object1;

    // 오브젝트 2
    public GameObject object2;

    public GameObject object3;

    // 페이드 아웃 시간
    public float fadeOutTime = 2.0f;

    // 음악이 현재 페이드 중인지 여부
    private bool isFadingOut = false;

    void Update()
    {
        // 특정 오브젝트 중 하나라도 활성화되면 음악을 페이드 아웃
        if (!isFadingOut && (object1.activeSelf || object2.activeSelf || object3.activeSelf))
        {
            isFadingOut = true;
            StartCoroutine(FadeOutMusic(musicSource));
        }
    }

    // 음악을 페이드 아웃하는 코루틴
    private IEnumerator FadeOutMusic(AudioSource audioSource)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeOutTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
        isFadingOut = false;
    }
}
