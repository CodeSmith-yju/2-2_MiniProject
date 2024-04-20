using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenMap : MonoBehaviour
{
    Scene scene;
    GameObject map_Btn;
    Button isthis_Btn;

    private void Start()
    {
        isthis_Btn = gameObject.GetComponent<Button>();
        map_Btn = GameObject.Find("PopupMgr/POPUP(map)/MapButtonBack");
    }

    private void Update()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Loading" || scene.name == "Map")
        {
            isthis_Btn.interactable = false;
            map_Btn.SetActive(false);
        }
        else
        {
            isthis_Btn.interactable = true;
        }
    }

    public void OnClick()
    {
       PopupMgr.OpenMap();
    }
}
