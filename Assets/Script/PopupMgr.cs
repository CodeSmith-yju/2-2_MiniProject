using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMgr : MonoBehaviour
{
    private static PopupMgr single;
    [SerializeField] GameObject popupMap;

    private void Awake()
    {
        single = this;
        DontDestroyOnLoad(this);
    }

    public static void OpenMap()
    {
        single.popupMap.SetActive(true);
    }

    public static void CloseAll()
    {
        single.popupMap.SetActive(false);
    }
}
