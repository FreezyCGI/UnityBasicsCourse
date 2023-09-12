using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float mouseYSpeed = 10;

    [Range(0f, 90f)] 
    public float yRotationLimit = 88f;

    private Vector2 cameraRotation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMouseInput = Input.GetAxis("Mouse Y");

        cameraRotation.y += verticalMouseInput * mouseYSpeed * Time.deltaTime * 60;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -yRotationLimit, yRotationLimit);
        var yQuat = Quaternion.AngleAxis(cameraRotation.y, Vector3.left);
        Camera.main.transform.localRotation = yQuat;
    }
}
