using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform thisTransform;

    private float fingerPosition;


    private Rigidbody playerRigidBody;

    private Vector3 targetPosition;

    private float screenWidth;

   

    private void Start()
    {
        thisTransform = transform;
        playerRigidBody = GetComponent<Rigidbody>();
        screenWidth = Screen.width;
        
    }
    private void LateUpdate()
    {

        if (Input.GetMouseButton(0))  //movement
        {
            fingerPosition = Input.mousePosition.x;
            

            if (fingerPosition > screenWidth/2)
            {
                targetPosition = new Vector3(2.5f, 0.25f, 0f);
                
            }
            if(fingerPosition < screenWidth/2)
            {
                targetPosition = new Vector3(-2.5f, 0.25f, 0f);
            }
            thisTransform.position = Vector3.MoveTowards(transform.position, targetPosition, 2f * Time.deltaTime);

        }

     
    }


   

}
