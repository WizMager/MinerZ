using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject crystal;
    [SerializeField] private GameObject latern;
    private int countCrystals;
    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            Instantiate(crystal, CoordSpawnCrystals(), Quaternion.identity);
        }

        for(int i = 0; i < 10; i++)
        {
            Instantiate(latern, CoordSpawnLaterns(), Quaternion.identity);
        }

        countCrystals = 20;
    }

    void Update()
    {
        if (countCrystals < 20)
        {
            Instantiate(crystal);
        }
    }

    private Vector3 CoordSpawnCrystals()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 42f), 2, UnityEngine.Random.Range(-42f, 4f));
    }

    private Vector3 CoordSpawnLaterns()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 42f), 0, UnityEngine.Random.Range(-42f, 4f));
    }
}
