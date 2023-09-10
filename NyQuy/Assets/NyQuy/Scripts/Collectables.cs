using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables: MonoBehaviour
{
    AudioSource sonido;
    void Start()
    {
        sonido = GetComponent<AudioSource>();
        GetComponent<MeshFilter>().enabled = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            sonido.Play();
            GetComponent<MeshFilter>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
}
