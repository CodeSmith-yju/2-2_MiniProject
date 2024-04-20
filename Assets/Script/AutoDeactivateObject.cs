using UnityEngine;

public class AutoDeactivateObject : MonoBehaviour
{
    void Start()
    {
        // ���� Ȱ��ȭ�Ǹ� �ڵ����� OnSceneActivate �޼��� ȣ��
        OnSceneActivate();
    }

    // �� Ȱ��ȭ �� ȣ��� �޼���
    public void OnSceneActivate()
    {
        // objectName�� ��ġ�ϴ� �̸��� ���� ������Ʈ�� ã�Ƽ� ��Ȱ��ȭ
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
