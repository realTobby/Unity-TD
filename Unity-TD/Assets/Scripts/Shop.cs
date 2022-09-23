using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject PREFAB_Tower0;


    private void Awake()
    {

        LoadPrefabTowers();
    }

    private void LoadPrefabTowers()
    {
        PREFAB_Tower0 = Resources.Load<GameObject>("Towers/Tower0");
    }

    public void PurchaseTower0()
    {
        BuildManager.Instance.SelectedShopItem = PREFAB_Tower0;
    }

    

    

}
