using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    // �θ� ������Ʈ �� �ڽ� ������Ʈ�鿡 ���� ���۷���
    public GameObject parentObject;
    public GameObject childObject1;

    // �ڽ� ������Ʈ���� �ʱ� ���¸� ������ ����
    private bool child1Active = true;

    // �̱��� ������ ����Ͽ� ���� �Ŵ��� �ν��Ͻ��� ����

    private void Start()
    {
        // �ʱ�ȭ �Լ� ȣ��
        InitializeObjects();
    }

    // �ڽ� ������Ʈ���� �ʱ� ���·� �����ϴ� �Լ�
    private void InitializeObjects()
    {
        childObject1.SetActive(child1Active);
    }

    // ��ư Ŭ�� �� ȣ��� �Լ�
    public void OnButton1Click()
    {
    }

    // ���� ������ �̵��ϴ� �Լ�
    public void LoadNextScene()
    {
        // ���� ������ �̵��ϱ� ���� �ڽ� ������Ʈ���� ���� ����
        child1Active = childObject1.activeSelf;

        // ���� ������ �̵�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // ���� ������ �̵� �� ȣ��� �Լ�
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� ������ �̵� �� �ڽ� ������Ʈ���� �ʱ� ���·� ����
        InitializeObjects();
    }
}
