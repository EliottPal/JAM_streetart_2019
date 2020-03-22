﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
    [SerializeField] private BlueSprayScript blueBar;
    public GameObject Brush;
    public float BrushSize = 0.1f;
    public RenderTexture RTexture;
    public float SprayAmmo;

    // Use this for initialization
    void Start()
    {
        blueBar.SetSize(SprayAmmo / 100);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && SprayAmmo > 0)
        {
            //cast a ray to the plane
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit))
            {
                //instanciate a brush
                var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * BrushSize;
                go.transform.Rotate(-90, 0, 0);
            }
            if (SprayAmmo > 0)
            {
                SprayAmmo--;
                blueBar.SetSize(SprayAmmo / 100);
            }
        }
    }

    public void Save()
    {
        StartCoroutine(CoSave());
    }

    private IEnumerator CoSave()
    {
        //wait for rendering
        yield return new WaitForEndOfFrame();

        //set active texture
        RenderTexture.active = RTexture;

        //convert rendering texture to texture2D
        var texture2D = new Texture2D(RTexture.width, RTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
        texture2D.Apply();

    }
}