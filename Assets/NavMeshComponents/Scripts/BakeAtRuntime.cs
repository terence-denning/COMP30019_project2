using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class BakeAtRuntime : MonoBehaviour
{
    private void OnEnable()
    {
        this.GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
