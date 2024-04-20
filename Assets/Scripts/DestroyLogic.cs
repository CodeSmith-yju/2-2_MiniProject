using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLogic : MonoBehaviour
{
    private GameObject destroy_Obj1;
    private GameObject destroy_Obj2;

    void Start()
    {
        destroy_Obj1 = GameObject.Find("Top_Bar");
        destroy_Obj2 = GameObject.Find("PopupMgr");

        Destroy(destroy_Obj1);
        Destroy(destroy_Obj2);
    }
}
