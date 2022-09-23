using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color IdleColor;

    public Color HoverColor;

    public Renderer NodeRenderer;

    private GameObject Building = null;

    public Vector3 PositionOffset;

    private void Awake()
    {
        NodeRenderer = this.GetComponent<Renderer>();

        IdleColor = NodeRenderer.material.color;

    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Building != null)
        {
            Debug.Log("Cannot build here!");
            return;
        }
        else
        {
            var towerPrefab = BuildManager.Instance.GetBuilding();

            if(towerPrefab != null)
            {
                Building = Instantiate(towerPrefab, this.transform.position + PositionOffset, Quaternion.identity);
                Building.transform.parent = this.transform;
            }

            
        }
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.Instance.SelectedShopItem == null)
            return;


        NodeRenderer.material.color = HoverColor;

    }

    private void OnMouseExit()
    {
        NodeRenderer.material.color = IdleColor;

    }
}
