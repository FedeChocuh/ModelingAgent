using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculando : MonoBehaviour
{

    public GameObject cube;
    Vector3 Light;
    Vector3 CAM;
    Vector3 PoI;
    Vector3 n;
    Vector3 l, v, r;
    void Start()
    {
    Vector3 a = new Vector3(-0.99932f, -0.72055f, -0.01918f);
    Vector3 translationVector = new Vector3(-0.85417f, -0.86190f, -0.33532f);
    Vector3 pivot = new Vector3(-0.73161f, -0.29326f, -0.99138f);
    float angle = 8.0f;

    Vector3 aPrime = a + translationVector;

    Matrix4x4 toOrigin = VectoringOps.TranslateToPositionMatrix(-pivot.x, -pivot.y, -pivot.z);
    Vector3 aPrimeAtOrigin = VectoringOps.ApplyTransform(new List<Vector3> { aPrime }, toOrigin)[0];
    Matrix4x4 rotationMatrix = VectoringOps.RotateZ(angle);
    Vector3 aPrimeRotated = VectoringOps.ApplyTransform(new List<Vector3> { aPrimeAtOrigin }, rotationMatrix)[0];

    Matrix4x4 backToPlace = VectoringOps.TranslateToPositionMatrix(pivot.x, pivot.y, pivot.z);
    Vector3 sphereCenter = VectoringOps.ApplyTransform(new List<Vector3> { aPrimeRotated }, backToPlace)[0];

    Debug.Log(sphereCenter.ToString("F5"));

    Light = GameObject.Find("Point Light").GetComponent<Light>().transform.position;
    CAM = Camera.main.transform.position;
    PoI = new Vector3(-2.364509884f,-2.196779917f,-0.5171407699f);
    n = PoI - cube.transform.position;
    l = Light - PoI;
    v = CAM - PoI;

    Vector3 lp = n.normalized * VectoringOps.Dot(n.normalized, l);
    Vector3 lo = l -lp;
    r = lp - lo;

    Debug.Log("n: " + n.ToString("F5"));
    Debug.Log("l: " + l.ToString("F5"));
    Debug.Log("v: " + v.ToString("F5"));
    Debug.Log("r: " + r.ToString("F5"));

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(PoI, PoI + n, Color.blue);
        Debug.DrawLine(PoI, PoI + l, Color.white);
        Debug.DrawLine(PoI, PoI + v, Color.red);
        Debug.DrawLine(PoI, PoI + r, Color.white);
        
    }
}
