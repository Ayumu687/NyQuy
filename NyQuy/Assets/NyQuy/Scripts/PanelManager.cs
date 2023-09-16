using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static int panel;
    AudioSource audi;
    public void LoadController()
    {
        for (int i = 1; i < this.transform.childCount; i++)
        {
            if (i != panel)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            } else
            {
                gameObject.transform.GetChild(panel).gameObject.SetActive(true);
            }
        }
    }

}
