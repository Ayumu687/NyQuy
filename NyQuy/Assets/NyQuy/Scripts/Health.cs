using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health: MonoBehaviour
{
    public int health;
    public int numOfHearts;

    [SerializeField]
    private pauseManager canvas;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float iframesDuration;
    private bool isInvicible = false;
    private float iframesTimer = 0.0f;

    private bool isPlayerActive = true; // Add a flag to track player's active state.

    void Update()
    {
        if(isPlayerActive)
        {
            if (isInvicible)
            {
                iframesTimer -= Time.deltaTime;
                if(iframesTimer <= 0)
                {
                    isInvicible = false;
                }
            }

            for(int i = 0; i < hearts.Length; i++)
            {
            	if(i < health)
            	{
            		hearts[i].sprite = fullHeart;
            	}
            	else
            	{
            		hearts[i].sprite = emptyHeart;
            	}

                if(i < numOfHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }

            if(health < 1)
            {
                DeactivatePlayer();
                canvas.gameOver();

            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    { 
        if (isInvicible) return;

        if (hit.gameObject.tag == "Enemy")
        {
            health -= 1;

            //Activate i-frames
            isInvicible = true;
            iframesTimer = iframesDuration;
        }
    }

    private void DeactivatePlayer()
    {
        isPlayerActive = false;

        // Disable player's control script or components here.
        // For example, if you have a PlayerMovement script, you can disable it like this:
        CarMovement playerMovement = GetComponent<CarMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // You can also disable rendering components like MeshRenderer or other scripts as needed.
    }
}
