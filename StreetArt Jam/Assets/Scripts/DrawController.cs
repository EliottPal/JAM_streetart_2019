using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
    [SerializeField] private BlueSprayScript blueBar;
    public GameObject Brush;
    public GameObject Spray;
    public float BrushSize = 0.1f;
    public RenderTexture RTexture;
    public float SprayAmmo;
    public AudioSource SpraySound;
    private char type = 'b';

    // Use this for initialization
    void Start()
    {
        blueBar.SetSize(SprayAmmo / 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            if (type == 'b')
                type = 'g';
            else
                type = 'b';
        }
        if (Input.GetMouseButton(0) && SprayAmmo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (SprayAmmo > 0)
                    SpraySound.Play();
                if (SprayAmmo < 0)
                    SpraySound.Stop();
            }

            //cast a ray to the plane
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit))
            {
                //instanciate a brush
                if (type == 'b')
                {
                    var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                    go.transform.localScale = Vector3.one * BrushSize;
                    go.transform.Rotate(-90, 0, 0);
                } else
                {
                    var go = Instantiate(Spray, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                    go.transform.localScale = Vector3.one * BrushSize;
                    go.transform.Rotate(-90, 0, 0);
                }
            }
            if (SprayAmmo > 0)
            {
                SprayAmmo -= 0.5f;
                blueBar.SetSize(SprayAmmo / 100);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            SpraySound.Pause();
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

    public void UpdateBar(float value)
    {
        SprayAmmo = value;
        blueBar.SetSize(SprayAmmo / 100);
    }
}
