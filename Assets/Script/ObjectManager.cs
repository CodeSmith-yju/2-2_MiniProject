using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    // 부모 오브젝트 및 자식 오브젝트들에 대한 레퍼런스
    public GameObject parentObject;
    public GameObject childObject1;

    // 자식 오브젝트들의 초기 상태를 저장할 변수
    private bool child1Active = true;

    // 싱글톤 패턴을 사용하여 게임 매니저 인스턴스를 저장

    private void Start()
    {
        // 초기화 함수 호출
        InitializeObjects();
    }

    // 자식 오브젝트들을 초기 상태로 설정하는 함수
    private void InitializeObjects()
    {
        childObject1.SetActive(child1Active);
    }

    // 버튼 클릭 시 호출될 함수
    public void OnButton1Click()
    {
    }

    // 다음 씬으로 이동하는 함수
    public void LoadNextScene()
    {
        // 다음 씬으로 이동하기 전에 자식 오브젝트들의 상태 저장
        child1Active = childObject1.activeSelf;

        // 다음 씬으로 이동
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // 다음 씬으로 이동 후 호출될 함수
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 다음 씬으로 이동 후 자식 오브젝트들을 초기 상태로 설정
        InitializeObjects();
    }
}
