using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorItems : MonoBehaviour
{
    public int items {get; private set;}
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = items.ToString("0");
    }

    public void Sumaritems()
    {
        items += 1;
    }
}
