﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCol : MonoBehaviour
{
    [SerializeField] Transform playerLocation;
    [SerializeField] float distanceToPlayer;
    [SerializeField] daniel danielScript;
    public float asteroidExplosionRadius;
    public GameObject particle;

    private void Awake()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerLocation.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        if (distanceToPlayer < asteroidExplosionRadius)
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        Destroy(GameObject.FindGameObjectWithTag("temporalIndicator"));
        Destroy(gameObject);
    }
}
