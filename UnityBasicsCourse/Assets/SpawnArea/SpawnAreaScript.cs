using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAreaScript : MonoBehaviour
{

    public GameObject shootingObjectPrefab;
    List<GameObject> spawnedShootingObjects = new();
    Vector2 spawnArea;

    // Start is called before the first frame update
    void Start()
    {
        spawnArea = new Vector2
        {
            x = transform.lossyScale.x / 2,
            y = transform.lossyScale.y / 2
        };
    }

    // Update is called once per frame
    void Update()
    {
        while(spawnedShootingObjects.Count < 1)
        {
            SpawnShootingObjects();
        }
    }

    private void SpawnShootingObjects()
    {
        GameObject shootingObject = GameObject.Instantiate(shootingObjectPrefab);
        shootingObject.transform.position = transform.position;
        shootingObject.transform.position += new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0);
        shootingObject.transform.parent = gameObject.transform;
        shootingObject.GetComponent<ShootingObjectScript>().SpawnAreaScript = this;
        spawnedShootingObjects.Add(shootingObject);
    }

    public void RemoveShootingObjectFromList(GameObject shootingObject)
    {
        spawnedShootingObjects.Remove(shootingObject);
    }
}
