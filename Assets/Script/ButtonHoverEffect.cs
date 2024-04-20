using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour
{
    public float hoverScale = 1.2f; // ȣ�� �� ũ�� ���� ����
    public float transitionSpeed = 5f; // ũ�� ���� �ӵ�

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        // ���� ũ��
        Vector3 currentScale = transform.localScale;

        // ���콺�� ��ư ���� �ִ��� üũ
        bool isMouseOver = RectTransformUtility.RectangleContainsScreenPoint(
            GetComponent<RectTransform>(),
            Input.mousePosition,
            Camera.main
        );

        // ȣ�� �� ũ�� ����
        if (isMouseOver)
        {
            currentScale = Vector3.Lerp(
                currentScale,
                originalScale * hoverScale,
                Time.deltaTime * transitionSpeed
            );
        }
        // ���콺�� ��� �� ũ�� ������� ����
        else
        {
            currentScale = Vector3.Lerp(
                currentScale,
                originalScale,
                Time.deltaTime * transitionSpeed
            );
        }

        // ũ�� ���� ����
        transform.localScale = currentScale;
    }
}
