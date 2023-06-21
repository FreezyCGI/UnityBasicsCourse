using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float mouseXSpeed = 10;
    public float mouseYSpeed = 10;

    public GameObject mainCamera;

    public GameObject bulletPrefab;
    public float bulletSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.transform.rotation = Quaternion.identity;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalMouseInput = Input.GetAxis("Mouse X");
        float verticalMouseInput = Input.GetAxis("Mouse Y");

        transform.position += transform.forward * verticalInput * movementSpeed * Time.deltaTime;
        transform.position += transform.right * horizontalInput * movementSpeed * Time.deltaTime;

        transform.Rotate(0, horizontalMouseInput * mouseXSpeed * Time.deltaTime, 0);
        mainCamera.transform.Rotate(-verticalMouseInput * mouseYSpeed * Time.deltaTime, 0, 0);

        if(mainCamera.transform.rotation.eulerAngles.x > 80 && mainCamera.transform.rotation.eulerAngles.x < 160)
        {
            mainCamera.transform.rotation = Quaternion.Euler(80, mainCamera.transform.rotation.y, mainCamera.transform.rotation.z);
        }
        if (mainCamera.transform.rotation.eulerAngles.x >= 160 && mainCamera.transform.rotation.eulerAngles.x < 280)
        {
            mainCamera.transform.rotation = Quaternion.Euler(280, mainCamera.transform.rotation.y, mainCamera.transform.rotation.z);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        bullet.transform.position = mainCamera.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * bulletSpeed);
    }
}
