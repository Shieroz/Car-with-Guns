using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float turnRate = 1f;
    public Transform CameraTarget, Player;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        //Potential option for invert controls
        mouseX += Input.GetAxis("Mouse X") * turnRate;
        mouseY -= Input.GetAxis("Mouse Y") * turnRate;
        mouseY = Mathf.Clamp(mouseY, -55, 30);

        transform.LookAt(CameraTarget);

        CameraTarget.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
}
