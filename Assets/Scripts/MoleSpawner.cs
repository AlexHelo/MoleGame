using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{


    public float spawnTime = 2f;
    public float timeBetween = 0f;
    public List<GameObject> holes = new List<GameObject>();
    int randomPos;
    void Start()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            holes.Add(child.gameObject);
        }
    }
    void Update()
    {
        timeBetween += Time.deltaTime;

        if (timeBetween >= spawnTime)
        {

            SpawnMole();
            timeBetween = 0f;
        }

    }

    private void SpawnMole()
    {
        randomPos = Random.Range(0, 10);
        var mole = MolePool.Instance.GetMole();
        mole.transform.rotation = holes[randomPos].transform.rotation;
        mole.transform.position = holes[randomPos].transform.position;
        mole.gameObject.SetActive(true);


    }
}
