using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Change : MonoBehaviour
{
    public GameObject reward1;
    public GameObject reward2;
    public Text reward1_skip_text;

    private void Update()
    {
        if (reward1.gameObject.activeSelf == true || reward2.gameObject.activeSelf == true)
        {
            reward1_skip_text.text = "���� �ѱ��";
        }
        else {
            reward1_skip_text.text = "���� ������";
        }
    }

}
