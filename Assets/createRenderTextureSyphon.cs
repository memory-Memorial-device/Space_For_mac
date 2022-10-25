using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRenderTextureSyphon : MonoBehaviour
{
    public RenderTexture rt;
    public Camera cam;
    public Klak.Syphon.SyphonServer sy;

    // Start is called before the first frame update
    void Start()
    {
        RenderTextureFormat rtf;
        rtf = RenderTextureFormat.Default;
        rt = new RenderTexture(1920, 1080, 24, rtf);
        cam.targetTexture = rt;
        sy.sourceTexture = rt;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
