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
        LoadObjectStates(); // �� ���� �� ������Ʈ ���¸� �ҷ��ɴϴ�.
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
        SaveObjectStates(); // ��ư�� ������ �� ������Ʈ ���¸� �����մϴ�.
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

    // ������Ʈ ���¸� �����մϴ�.
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

    // ����� ������Ʈ ���¸� �ҷ��� �����մϴ�.
    void LoadObjectStates()
    {
        foreach (var button in mapButtons)
        {
            foreach (var mapObject in button.associatedMapObjects)
            {
                int objectState = PlayerPrefs.GetInt(mapObject.name, 1); // �⺻���� Ȱ��ȭ
                mapObject.SetActive(objectState == 1);
            }
        }
    }
}
