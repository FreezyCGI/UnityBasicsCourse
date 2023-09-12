using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float mouseXSpeed = 10;

    public float jumpHeight = 10;

    public GameObject bulletPrefab;
    public float bulletSpeed = 1;

    public GameObject mainCamera;

    private Rigidbody Rigidbody { get; set; }

    // Start is called before the first frame update
    void Start()
    {    
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalMouseInput = Input.GetAxis("Mouse X");
       
        transform.position += transform.forward * verticalInput * movementSpeed * Time.deltaTime;
        transform.position += transform.right * horizontalInput * movementSpeed * Time.deltaTime;

        transform.Rotate(0, horizontalMouseInput * mouseXSpeed * Time.deltaTime * 60, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector3.up * jumpHeight);
        }
    }

    void Shoot()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        bullet.transform.position = mainCamera.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * bulletSpeed);
    }
}
