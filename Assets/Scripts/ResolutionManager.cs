using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    // 원하는 해상도 설정
    public int targetWidth = 1920;
    public int targetHeight = 1080;

    // 초기 캔버스 크기
    private Vector2 initialCanvasSize;

    // 초기 자식 객체의 위치 및 크기
    private RectTransform[] childRectTransforms;

    void Start()
    {
        // 초기 캔버스 크기 저장
        initialCanvasSize = GetComponent<RectTransform>().sizeDelta;

        // 초기 자식 객체의 위치 및 크기 저장
        SaveInitialChildRectTransforms();

        // 해상도 설정
        SetResolution();
    }

    void SetResolution()
    {
        // 원하는 해상도로 변경
        Screen.SetResolution(targetWidth, targetHeight, true);

        // 캔버스 크기 및 자식 객체의 위치 및 크기 조절
        AdjustCanvasAndChildRectTransforms();
    }

    void AdjustCanvasAndChildRectTransforms()
    {
        // 원래 크기 대비 비율 계산
        float widthRatio = Screen.width / (float)targetWidth;
        float heightRatio = Screen.height / (float)targetHeight;

        // 캔버스 크기 조절
        GetComponent<RectTransform>().sizeDelta = new Vector2(initialCanvasSize.x * widthRatio, initialCanvasSize.y * heightRatio);

        // 자식 객체의 위치 및 크기 조절
        for (int i = 0; i < childRectTransforms.Length; i++)
        {
            RectTransform childRectTransform = childRectTransforms[i];

            // 원래 크기 대비 비율 계산
            float xRatio = childRectTransform.localPosition.x / initialCanvasSize.x;
            float yRatio = childRectTransform.localPosition.y / initialCanvasSize.y;

            // 새로운 위치 및 크기 설정
            childRectTransform.localPosition = new Vector3(GetComponent<RectTransform>().sizeDelta.x * xRatio, GetComponent<RectTransform>().sizeDelta.y * yRatio, childRectTransform.localPosition.z);
            childRectTransform.sizeDelta = new Vector2(childRectTransform.sizeDelta.x * widthRatio, childRectTransform.sizeDelta.y * heightRatio);
        }
    }

    void SaveInitialChildRectTransforms()
    {
        // 모든 자식 객체의 초기 위치 및 크기 저장
        int childCount = transform.childCount;
        childRectTransforms = new RectTransform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childRectTransforms[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }
    }
}
