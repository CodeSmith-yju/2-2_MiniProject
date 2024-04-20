using UnityEngine;

public class PopupManager : MonoBehaviour
{
    private static PopupManager _instance;

    public static PopupManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("PopupManager");
                _instance = go.AddComponent<PopupManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    // ���⿡ �˾� ���� ������ �߰��մϴ�.
}
