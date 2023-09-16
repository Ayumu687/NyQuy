using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruta : MonoBehaviour
{
    
    //public GameObject efecto;
    public float cantidadPuntos;
    public ContadorItems contador;

    private void OnTriggerEnter(Collider other){

        if(other.CompareTag("Player"))
        {
            //Instantiate(efecto, transform.position, Quaternion.identity);
            contador.Sumaritems();
            //AudioManager.Instance.PlaySFX("coin");
            Destroy(gameObject);
        }
    }
}
