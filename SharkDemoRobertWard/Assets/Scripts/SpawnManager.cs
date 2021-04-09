using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> objects;
    public float MaxZ;
    public float MinZ;
    public float MaxY;
    public float MinY;
    public float timeBetweenSpawns;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime<=0)
        {
            SpawnObject();
            currentTime = timeBetweenSpawns;
        }
    }
    void SpawnObject()
    {
        GameObject obj =GameObject.Instantiate(objects[Random.Range(0,objects.Count-1)]);
        if(Random.Range(0,10)<=5.1f)
        {
            Debug.Log("smaller");
            obj.transform.position = new Vector3(0, Random.Range(MinY,MaxY), MaxZ);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
            obj.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            obj.transform.position = new Vector3(0, Random.Range(MinY, MaxY), MinZ);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
        }
    }
}
