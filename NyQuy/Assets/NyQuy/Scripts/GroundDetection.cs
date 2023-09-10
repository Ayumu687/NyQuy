using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
	public PlayerController playerController;


    private void OnTriggerStay(Collider other)
    {
    	playerController.isJumping = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
    	playerController.isJumping = false;
    }
}
