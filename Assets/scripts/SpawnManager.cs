using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroid : MonoBehaviour
{
    [SerializeField] List<GameObject> astroidPrefabs = new List<GameObject>();
    [SerializeField] float intervalle = 2;
    [SerializeField] GameObject enemyprefab;

    float asteroidetime = 0;


    void Start()
    {
        asteroidetime = Time.time;

    }

    void Update()
    {
        if ((Time.time-asteroidetime)>intervalle)
        {
            int rand = Mathf.RoundToInt(Random.Range(0, 3));
            float porand = Random.Range(-10f, 10f);
            float yrand = Random.Range(-12f, 12f);

            if (Random.Range(0, 75) < 1)
            {
                Instantiate(enemyprefab, new Vector3(Random.Range(-6f, 6f), 0.5f, 50), Quaternion.identity);
            }
            else 
            {
                Instantiate(astroidPrefabs[rand], new Vector3(porand, yrand, 50), Quaternion.identity);
            }
            asteroidetime = Time.time;
        }


    }
}
