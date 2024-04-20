using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoBanana : MonoBehaviour
{

    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("Banana"); //이동 할 씬 이름
        Debug.Log("GO Banana");
    }
}