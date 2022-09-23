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

        LoadPrefabTowers();

    }

    private void LoadPrefabTowers()
    {
        PREFAB_Tower0 = Resources.Load<GameObject>("Towers/Tower0");
    }

    private GameObject PREFAB_Tower0;


    public GameObject GetTowerPrefab()
    {
        return PREFAB_Tower0;
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
