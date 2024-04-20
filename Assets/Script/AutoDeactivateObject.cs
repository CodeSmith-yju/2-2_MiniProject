using UnityEngine;

public class AutoDeactivateObject : MonoBehaviour
{
    void Start()
    {
        // 씬이 활성화되면 자동으로 OnSceneActivate 메서드 호출
        OnSceneActivate();
    }

    // 씬 활성화 시 호출될 메서드
    public void OnSceneActivate()
    {
        // objectName과 일치하는 이름을 가진 오브젝트를 찾아서 비활성화
        Time.timeScale = 1;
        GameObject objectToDeactivate = GameObject.Find("");

        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }
        else
        {

        }
    }
}
