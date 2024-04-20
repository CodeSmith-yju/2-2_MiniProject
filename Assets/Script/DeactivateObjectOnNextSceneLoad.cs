using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateObjectOnNextSceneLoad : MonoBehaviour
{
    public string objectNameToDeactivate = "ObjectName"; // ��Ȱ��ȭ�� ������Ʈ�� �̸�

    void Start()
    {
        // SceneManager�� sceneLoaded �̺�Ʈ�� OnSceneLoaded �޼��带 ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� �ε�� �� ȣ��Ǵ� �޼���

        // objectNameToDeactivate �̸��� ������Ʈ�� ã�Ƽ� ��Ȱ��ȭ
        GameObject objectToDeactivate = GameObject.Find(objectNameToDeactivate);

        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Object not found: " + objectNameToDeactivate);
        }

        // ��ũ��Ʈ�� ��Ȱ��ȭ�ǰų� �ı��� �� �̺�Ʈ ��� ����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
