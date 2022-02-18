using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Spawner : MonoBehaviour
{
    public float spawnCoolDown;
    public float currentTime;
    public float destroyTime;
    public float Height;
    public float minWidth;
    public float maxWidth;
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCoolDown < currentTime)
        {
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = transform.position + new Vector3(Random.Range(minWidth, maxWidth), Height, 0);
            Destroy(newObstacle, destroyTime);
            currentTime = 0;
        }

        currentTime += Time.deltaTime;
    }
}
