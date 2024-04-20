using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CustomMapper : MonoBehaviour
{
    [System.Serializable]
    public class MapButton
    {
        public Button button;
        public List<GameObject> associatedMapObjects = new List<GameObject>();
        public string sceneToLoad;
        public bool activateObjectsOnPress;
        public bool deactivateObjectsOnPress;
    }

    public List<MapButton> mapButtons = new List<MapButton>();
    private bool isTransitioning = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadObjectStates(); // 씬 시작 시 오브젝트 상태를 불러옵니다.
        SetButtonListeners();
    }

    void SetButtonListeners()
    {
        foreach (var button in mapButtons)
        {
            button.button.onClick.AddListener(() => OnMapButtonClick(button));
        }
    }

    void OnMapButtonClick(MapButton selectedButton)
    {
        if (isTransitioning)
            return;

        StartCoroutine(TransitionToMap(selectedButton));
        SaveObjectStates(); // 버튼이 눌렸을 때 오브젝트 상태를 저장합니다.
    }

    IEnumerator TransitionToMap(MapButton selectedButton)
    {
        isTransitioning = true;

        if (!string.IsNullOrEmpty(selectedButton.sceneToLoad))
        {
            SceneManager.LoadScene(selectedButton.sceneToLoad);
            yield break;
        }

        if (selectedButton.activateObjectsOnPress)
        {
            foreach (var mapObject in selectedButton.associatedMapObjects)
            {
                mapObject.SetActive(true);
            }
        }

        if (selectedButton.deactivateObjectsOnPress)
        {
            foreach (var mapObject in selectedButton.associatedMapObjects)
            {
                mapObject.SetActive(false);
            }
        }

        isTransitioning = false;
    }

    // 오브젝트 상태를 저장합니다.
    void SaveObjectStates()
    {
        foreach (var button in mapButtons)
        {
            foreach (var mapObject in button.associatedMapObjects)
            {
                PlayerPrefs.SetInt(mapObject.name, mapObject.activeSelf ? 1 : 0);
            }
        }
    }

    // 저장된 오브젝트 상태를 불러와 적용합니다.
    void LoadObjectStates()
    {
        foreach (var button in mapButtons)
        {
            foreach (var mapObject in button.associatedMapObjects)
            {
                int objectState = PlayerPrefs.GetInt(mapObject.name, 1); // 기본값은 활성화
                mapObject.SetActive(objectState == 1);
            }
        }
    }
}
