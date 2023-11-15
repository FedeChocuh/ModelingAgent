using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illumination : MonoBehaviour
{

    public GameObject cube;
    Vector3 Light;
    Vector3 CAM;
    Vector3 PoI;
    Vector3 n;
    Vector3 l, v, r;
    // Start is called before the first frame update
    void Start()
    {
        Light = GameObject.Find("Point Light").GetComponent<Light>().transform.position;
        CAM = Camera.main.transform.position;
        PoI = new Vector3(3.5f,3,0);
        n = PoI - cube.transform.position;
        l = Light - PoI;
        v = CAM - PoI;

        Vector3 lp = n.normalized * VectoringOps.Dot(n.normalized, l);
        Vector3 lo = l -lp;
        r = lp - lo;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(PoI, PoI + n, Color.blue);
        Debug.DrawLine(PoI, PoI + l, Color.white);
        Debug.DrawLine(PoI, PoI + v, Color.red);
        
    }
}
