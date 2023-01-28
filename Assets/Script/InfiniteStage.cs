using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStage : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 2;
    public float levelWidth = 3f;
    public float minY = 18f;
    public float maxY = 35f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
