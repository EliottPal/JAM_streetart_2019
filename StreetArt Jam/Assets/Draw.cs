using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject Brush;
    public float BrushSize = 0.1f;
   
    public Vector3 positions;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
    }

    void CreateLine()
    {
        positions = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var tempBrush = Instantiate(Brush, positions, Quaternion.identity);
        tempBrush.transform.localScale = Vector3.one * BrushSize;
    }
}
