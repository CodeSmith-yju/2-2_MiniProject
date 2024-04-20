using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActiveObj_2 : MonoBehaviour
{
    public GameObject reward_page1;
    public GameObject reward_page2;

    public void DeActiveObj()
    {
        Time.timeScale = 1;
        reward_page1.SetActive(true);
        reward_page2.SetActive(false);
    }
}
