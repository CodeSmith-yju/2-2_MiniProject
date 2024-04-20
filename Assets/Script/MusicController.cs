using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // ������ ���� AudioSource
    public AudioSource musicSource;

    // ������Ʈ 1
    public GameObject object1;

    // ������Ʈ 2
    public GameObject object2;

    public GameObject object3;

    // ���̵� �ƿ� �ð�
    public float fadeOutTime = 2.0f;

    // ������ ���� ���̵� ������ ����
    private bool isFadingOut = false;

    void Update()
    {
        // Ư�� ������Ʈ �� �ϳ��� Ȱ��ȭ�Ǹ� ������ ���̵� �ƿ�
        if (!isFadingOut && (object1.activeSelf || object2.activeSelf || object3.activeSelf))
        {
            isFadingOut = true;
            StartCoroutine(FadeOutMusic(musicSource));
        }
    }

    // ������ ���̵� �ƿ��ϴ� �ڷ�ƾ
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
