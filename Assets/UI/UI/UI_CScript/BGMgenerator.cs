using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMgenerator : MonoBehaviour
{
    public GameObject bgm;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bgm, this.transform.position, this.transform.rotation);
    }

}
