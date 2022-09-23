using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager _instance = null;

    public static BuildManager Instance => _instance;

    private void Awake()
    {
        if(_instance != null)
        {
            Debug.LogError("More than 1 BuildManager in scene!");
        }

        _instance = this;

       

    }



    public GameObject SelectedShopItem;

    public GameObject GetBuilding()
    {
        if(SelectedShopItem != null)
        {
            GameObject buildingResult = SelectedShopItem;
            SelectedShopItem = null;
            return buildingResult;
        }
        return null;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
