using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TrackingSphere : MonoBehaviour
{

    public GameObject Object;
    private VisualEffect vs;
    // Start is called before the first frame update
    void Start()
    {
        vs = this.GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        vs.SetVector3("Masking_Position", Object.transform.position);
    }
}
