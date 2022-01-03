using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float maxX;

    [SerializeField]
    float SpawnInterval;

    public GameObject[] Candies;

    public static CandySpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        StartSpawningCandies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, Candies.Length);
        float randX = Random.Range(-maxX, maxX);

        Vector3 randomPos = new Vector3(randX, transform.position.y, transform.position.z); 
        Instantiate(Candies[rand], randomPos, transform.rotation);

    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while(true)
        {
            SpawnCandy();

            yield return new WaitForSeconds(SpawnInterval);
        }

    }

    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
