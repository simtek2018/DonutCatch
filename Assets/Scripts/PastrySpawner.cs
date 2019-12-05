using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastrySpawner : MonoBehaviour
{
    float maxX = 7.5f;
    [SerializeField] GameObject[] pastries;
    [SerializeField] float spawnInterval = 3f;
    public static PastrySpawner pastrySpawner;
   

    private void Awake() {
        if (pastrySpawner == null) {
            pastrySpawner = this;
        }
    }

    private void Start() {
        StartSpawning();
    }
   
    IEnumerator SpawnPasteries() {
        yield return new WaitForSeconds(spawnInterval);
        while (true) {
            SpawnPastry();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnPastry() {
        int index = Random.Range(0, pastries.Length);       
        float xPos = Random.Range(-maxX, maxX);
        Vector3 randPos = new Vector3(xPos, transform.position.y, transform.position.z);
        Instantiate(pastries[index], randPos, transform.rotation);
    }

    public void StartSpawning() {
        StartCoroutine("SpawnPasteries");
    }

    public void StopSpawning() {
        StopCoroutine("SpawnPasteries");
    }
}
