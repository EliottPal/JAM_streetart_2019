using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSprayScript : MonoBehaviour
{
    private Transform bar;

    private void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
