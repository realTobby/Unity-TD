using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(Building != null)
        {
            Debug.Log("Cannot build here!");
            return;
        }
        else
        {
            Building = Instantiate(BuildManager.Instance.GetTowerPrefab(), this.transform.position + PositionOffset, Quaternion.identity);
            Building.transform.parent = this.transform;
        }
    }


    private void OnMouseEnter()
    {
        NodeRenderer.material.color = HoverColor;

    }

    private void OnMouseExit()
    {
        NodeRenderer.material.color = IdleColor;

    }
}
