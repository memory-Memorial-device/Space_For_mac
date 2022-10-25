using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class Alpha_Control : MonoBehaviour
{

    public VisualEffect VFXGraph;
    public GameObject OSCIN;
    public bool target;
    // Start is called before the first frame update
    void Start()
    {
        VFXGraph = this.gameObject.GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == false) VFXGraph.SetInt("Switch", OSCIN.GetComponent<OscSimpl.Examples.GettingStartedReceiving>().switch01);
        else VFXGraph.SetInt("Switch", OSCIN.GetComponent<OscSimpl.Examples.GettingStartedReceiving>().switch02);
    }
}
