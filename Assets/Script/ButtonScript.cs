using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string objectName = "ObjectName";

    // ��ư Ŭ�� �� ȣ��� �޼���
    public void OnButtonClick()
    {
        // objectName�� ��ġ�ϴ� �̸��� ���� ������Ʈ�� ã�Ƽ� ��Ȱ��ȭ
        GameObject objectToDisable = GameObject.Find(objectName);

        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
            Debug.Log(objectName + " ��Ȱ��ȭ��");
        }
        else
        {
            Debug.LogWarning("ã�� �� ���� ������Ʈ: " + objectName);
        }
    }
}
