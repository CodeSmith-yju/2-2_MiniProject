using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoRandomRoom : MonoBehaviour
{

    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("RandomRoom"); //이동 할 씬 이름
        Debug.Log("GO Random");
    }
}