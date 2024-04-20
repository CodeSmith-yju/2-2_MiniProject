using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateObjectOnNextSceneLoad : MonoBehaviour
{
    public string objectNameToDeactivate = "ObjectName"; // 비활성화할 오브젝트의 이름

    void Start()
    {
        // SceneManager의 sceneLoaded 이벤트에 OnSceneLoaded 메서드를 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드될 때 호출되는 메서드

        // objectNameToDeactivate 이름의 오브젝트를 찾아서 비활성화
        GameObject objectToDeactivate = GameObject.Find(objectNameToDeactivate);

        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Object not found: " + objectNameToDeactivate);
        }

        // 스크립트가 비활성화되거나 파괴될 때 이벤트 등록 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
