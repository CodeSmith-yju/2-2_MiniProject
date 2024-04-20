using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string objectName = "ObjectName";

    // 버튼 클릭 시 호출될 메서드
    public void OnButtonClick()
    {
        // objectName과 일치하는 이름을 가진 오브젝트를 찾아서 비활성화
        GameObject objectToDisable = GameObject.Find(objectName);

        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
            Debug.Log(objectName + " 비활성화됨");
        }
        else
        {
            Debug.LogWarning("찾을 수 없는 오브젝트: " + objectName);
        }
    }
}
