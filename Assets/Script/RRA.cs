using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RRA : MonoBehaviour
{

    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("RRA"); //�̵� �� �� �̸�
        Debug.Log("GO-RRA");
    }
}