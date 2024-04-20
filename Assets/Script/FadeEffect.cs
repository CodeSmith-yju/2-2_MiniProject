using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public float fadeDuration; // 페이드 시간 (초)
    public CanvasGroup canvasGroup;
    public float deactivateDelay; // 비활성화 딜레이 시간 (초)

    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f; // 초기 투명도를 0으로 설정

        FadeIn(); // 시작할 때 페이드 인
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
