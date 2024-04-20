using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour
{
    public float hoverScale = 1.2f; // 호버 시 크기 조절 비율
    public float transitionSpeed = 5f; // 크기 조절 속도

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        // 현재 크기
        Vector3 currentScale = transform.localScale;

        // 마우스가 버튼 위에 있는지 체크
        bool isMouseOver = RectTransformUtility.RectangleContainsScreenPoint(
            GetComponent<RectTransform>(),
            Input.mousePosition,
            Camera.main
        );

        // 호버 시 크기 조절
        if (isMouseOver)
        {
            currentScale = Vector3.Lerp(
                currentScale,
                originalScale * hoverScale,
                Time.deltaTime * transitionSpeed
            );
        }
        // 마우스가 벗어날 때 크기 원래대로 돌림
        else
        {
            currentScale = Vector3.Lerp(
                currentScale,
                originalScale,
                Time.deltaTime * transitionSpeed
            );
        }

        // 크기 조절 적용
        transform.localScale = currentScale;
    }
}
