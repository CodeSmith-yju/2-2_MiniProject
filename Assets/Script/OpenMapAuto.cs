using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMapAuto : MonoBehaviour
{
    private void Start()
    {
        // ���� Ȱ��ȭ�Ǹ� �ڵ����� OnClick �޼��� ȣ��
        OnClick();
    }

    public void OnClick()
    {
        PopupMgr.OpenMap();
    }
}
