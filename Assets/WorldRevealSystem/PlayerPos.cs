using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    
    private void Update()
    {
        Shader.SetGlobalVector("_PlayerPos", this.transform.position);
    }
}
