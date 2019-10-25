using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroywhenfinish : MonoBehaviour
{
    public ParticleSystem PS;
    private string currentscene;
    public GameObject player;
    private List<GameObject> objs;
    public GameObject UI;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
        PS = GetComponent<ParticleSystem>();
        UI = GameObject.FindWithTag("GameController");
        GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        GetComponent<AudioSource>().volume = GlobalOptions.volume;
        if (!PS.IsAlive())
        {
            player.transform.position = new Vector3(0,0.15f,0);
            objs = dunDestroy._ddolObjects;
            if ((objs.Find((x) => x.CompareTag("Player")) == null))
            {
                dunDestroy.DontDestroyOnLoad(player);
            }

            if ((objs.Find((x) => x.CompareTag("GameController")) == null))
            {
                dunDestroy.DontDestroyOnLoad(UI);
            }
            
            currentscene = SceneManager.GetActiveScene().name;
            if (currentscene == "GameScene")
            {
                SceneManager.LoadScene("SecondLevel");
            }
            if (currentscene == "SecondLevel")
            {
                SceneManager.LoadScene("ThirdLevel");
            }
            if (currentscene == "ThirdLevel")
            {
                dunDestroy.DestroyAll();
                SceneManager.LoadScene("GameWin");
            }
            
        }
    }
}
