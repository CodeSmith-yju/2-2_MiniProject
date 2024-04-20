using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMapAuto : MonoBehaviour
{
    private void Start()
    {
        // 씬이 활성화되면 자동으로 OnClick 메서드 호출
        OnClick();
    }

    public void OnClick()
    {
        PopupMgr.OpenMap();
    }
}
