using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    // ���ϴ� �ػ� ����
    public int targetWidth = 1920;
    public int targetHeight = 1080;

    // �ʱ� ĵ���� ũ��
    private Vector2 initialCanvasSize;

    // �ʱ� �ڽ� ��ü�� ��ġ �� ũ��
    private RectTransform[] childRectTransforms;

    void Start()
    {
        // �ʱ� ĵ���� ũ�� ����
        initialCanvasSize = GetComponent<RectTransform>().sizeDelta;

        // �ʱ� �ڽ� ��ü�� ��ġ �� ũ�� ����
        SaveInitialChildRectTransforms();

        // �ػ� ����
        SetResolution();
    }

    void SetResolution()
    {
        // ���ϴ� �ػ󵵷� ����
        Screen.SetResolution(targetWidth, targetHeight, true);

        // ĵ���� ũ�� �� �ڽ� ��ü�� ��ġ �� ũ�� ����
        AdjustCanvasAndChildRectTransforms();
    }

    void AdjustCanvasAndChildRectTransforms()
    {
        // ���� ũ�� ��� ���� ���
        float widthRatio = Screen.width / (float)targetWidth;
        float heightRatio = Screen.height / (float)targetHeight;

        // ĵ���� ũ�� ����
        GetComponent<RectTransform>().sizeDelta = new Vector2(initialCanvasSize.x * widthRatio, initialCanvasSize.y * heightRatio);

        // �ڽ� ��ü�� ��ġ �� ũ�� ����
        for (int i = 0; i < childRectTransforms.Length; i++)
        {
            RectTransform childRectTransform = childRectTransforms[i];

            // ���� ũ�� ��� ���� ���
            float xRatio = childRectTransform.localPosition.x / initialCanvasSize.x;
            float yRatio = childRectTransform.localPosition.y / initialCanvasSize.y;

            // ���ο� ��ġ �� ũ�� ����
            childRectTransform.localPosition = new Vector3(GetComponent<RectTransform>().sizeDelta.x * xRatio, GetComponent<RectTransform>().sizeDelta.y * yRatio, childRectTransform.localPosition.z);
            childRectTransform.sizeDelta = new Vector2(childRectTransform.sizeDelta.x * widthRatio, childRectTransform.sizeDelta.y * heightRatio);
        }
    }

    void SaveInitialChildRectTransforms()
    {
        // ��� �ڽ� ��ü�� �ʱ� ��ġ �� ũ�� ����
        int childCount = transform.childCount;
        childRectTransforms = new RectTransform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childRectTransforms[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }
    }
}
