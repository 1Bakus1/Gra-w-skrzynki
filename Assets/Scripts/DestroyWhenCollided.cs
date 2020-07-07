using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenCollided : MonoBehaviour {


    /*
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.GetType() == typeof(CapsuleCollider))
            {
            if (hit.transform.CompareTag("box"))
            {
                Destroy(hit.gameObject);
            }
        }
        else
        {

        }
    }
    */

    
 

    

    void OnControllerColliderHit(Collision other)
    {
        if (other.gameObject.name == "Postac")
        {
            this.gameObject.SetActive(false);
        }

    }
    
}
