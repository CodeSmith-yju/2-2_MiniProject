using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Scene_Btn_2 : MonoBehaviour
{
    public void LoadNextScene(string sceneName)
    {
        FadeAndLoad(sceneName);
    }

    private void FadeAndLoad(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
