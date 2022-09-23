using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool doMovement = false;

    public float PanSpeed = 30f;

    public float PanBorderThickness = 15f;

    public float ScrollSpeed = 5f;

    public float MinimumY = 10f;
    public float MaximumY = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        ZoomCamera();

        if (!doMovement)
            return;


        MoveCamera();

        


    }

    private void ZoomCamera()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = this.transform.position;


        pos.y -= scrollValue * 1000f * ScrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, MinimumY, MaximumY);

        this.transform.position = pos;

    }

    private void MoveCamera()
    {
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - PanBorderThickness)
        {
            this.transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= PanBorderThickness)
        {
            this.transform.Translate(Vector3.back * PanSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= PanBorderThickness)
        {
            this.transform.Translate(Vector3.left * PanSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - PanBorderThickness)
        {
            this.transform.Translate(Vector3.right * PanSpeed * Time.deltaTime, Space.World);
        }
    }

}
