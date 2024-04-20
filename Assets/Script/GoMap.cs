using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoMap : MonoBehaviour
{

    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("Map"); //이동 할 씬 이름
        Debug.Log("GO Map");
    }
}