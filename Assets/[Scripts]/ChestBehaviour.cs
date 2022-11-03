using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    
    public GameObject openChest;
    
    
    public float count;
    public float radius;
    public bool checkPlayer;
    public LayerMask mask;

   
    void FixedUpdate()
    {
        Interaction();
        if (checkPlayer) 
        {
            count = 2;
            if (Input.GetKey(KeyCode.E)&& count == 2)
            {
                openChest.SetActive(true);
                count++;
                this.gameObject.SetActive(false);
            }
           
        }
           
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
    void Interaction()
    {
        checkPlayer =  Physics2D.OverlapCircle(this.transform.position, radius, mask);
    }
    

}
