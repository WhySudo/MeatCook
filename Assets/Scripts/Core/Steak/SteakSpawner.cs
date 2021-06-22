using System;
using System.Collections;
using System.Collections.Generic;
using Core.Steak;
using UnityEngine;

public class SteakSpawner : MonoBehaviour
{
    public Steak prefab;
    public Transform[] spawnPosition;
    public Bounds movementBounds;
    public Bounds rotationBounds;
    public Transform parent;

    private void Awake()
    {
        SpawnSteaks();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(movementBounds.center, movementBounds.extents*2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(rotationBounds.center, rotationBounds.extents*2);
        Gizmos.color = Color.blue;
        foreach (var pos in spawnPosition)
        {
            Gizmos.DrawSphere(pos.position, 0.3f);
        }

    }

    private void SpawnSteaks()
    {
        foreach (var pos in spawnPosition)
        {
            var steak = Instantiate(prefab);
            if (!(parent is null))
                steak.transform.parent = parent;
            var transform1 = steak.transform;
            transform1.position = pos.position;
            transform1.rotation = pos.rotation;
            steak.SetUp(movementBounds, rotationBounds);
        }
    }
}
