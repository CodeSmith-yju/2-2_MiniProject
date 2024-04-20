using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoBox : MonoBehaviour
{

    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("Box"); //이동 할 씬 이름
        Debug.Log("GO Box");
    }
}