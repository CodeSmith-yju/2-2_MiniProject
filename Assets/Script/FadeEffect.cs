using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public float fadeDuration; // ���̵� �ð� (��)
    public CanvasGroup canvasGroup;
    public float deactivateDelay; // ��Ȱ��ȭ ������ �ð� (��)

    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f; // �ʱ� ������ 0���� ����

        FadeIn(); // ������ �� ���̵� ��
        Invoke("FadeOutAndDeactivate", fadeDuration + deactivateDelay);
    }

    void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1, fadeDuration));
    }

    void FadeOutAndDeactivate()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0, fadeDuration));
        Invoke("DeactivateObject", fadeDuration);
    }


    void DeactivateObject()
    {
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime)
    {
        float startTime = Time.time;
        float endTime = startTime + lerpTime;

        while (Time.time < endTime)
        {
            float progress = (Time.time - startTime) / lerpTime;
            cg.alpha = Mathf.Lerp(start, end, progress);
            yield return null;
        }
        cg.alpha = end;
    }
}
