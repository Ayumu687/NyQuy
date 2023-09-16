using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoItems : MonoBehaviour
{
    public ContadorItems contadorItem;
    public int ItemsNecesarios;
    public Material Material1;
    //public Desactivar des;

    private void OnTriggerEnter(Collider other)
    {
        ContadorItems contadorItem = other.GetComponent<ContadorItems>();

        if(contadorItem != null)
        {
            contadorItem.Sumaritems();
            gameObject.SetActive(false);
        }
    }

}
