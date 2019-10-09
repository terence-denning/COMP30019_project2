
using System.Collections;
using UnityEngine;


public class EnemyDrop : MonoBehaviour
{
    private GameObject dropitem;
    public GameObject item0;
    public GameObject item1;
    public void DropItem()
    {
        bool Isitdrop = true;
        int drop = Random.Range(0, 2);
        switch (drop)
        {
            case 0:
                dropitem = item0;
                break;
            case 1:
                dropitem = item1;
                break;
            default:
                Isitdrop = false;
                break;
                
        }
       
        if (Isitdrop)
        {
            transform.rotation *= Quaternion.Euler(0,0,-30);
            GameObject go = Instantiate(dropitem, transform.position, transform.rotation) as GameObject;
            go.AddComponent<RedPotion>();
        }

    }

    
}
