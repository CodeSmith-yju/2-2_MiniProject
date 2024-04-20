using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RRA : MonoBehaviour
{

    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("RRA"); //이동 할 씬 이름
        Debug.Log("GO-RRA");
    }
}