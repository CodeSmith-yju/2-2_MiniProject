using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoDounut : MonoBehaviour
{

    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("Dounut"); //이동 할 씬 이름
        Debug.Log("GO Dounut");
    }
}