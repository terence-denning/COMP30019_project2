
using System.Collections;
using UnityEngine;


public class EnemyDrop : MonoBehaviour
{
    private GameObject dropitem;
    public GameObject[] items;
    public void DropItem()
    {
        int drop = Random.Range(0, items.Length);
        if (drop > items.Length-1)
        {
            Debug.Log("badLuck");
        }
        else
        {
            dropitem = items[drop];
        }

        transform.rotation *= Quaternion.Euler(0,0,-30);
        GameObject go = Instantiate(dropitem, transform.position, transform.rotation) as GameObject;
        go.AddComponent<RedPotion>();
        

    }

    
}
