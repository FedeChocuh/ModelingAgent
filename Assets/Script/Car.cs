using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Car : MonoBehaviour
{
    public GameObject car;

    GameObject car1;
    GameObject car2;
    List<Vector3> carOrig;
    List<Vector3> carOrig2;
    float dx;
    float dy2;
    void Start()
    {
        car1 = Instantiate(car);
        car2 = Instantiate(car);
        carOrig = car1.GetComponent<MeshFilter>().mesh.vertices.ToList();
        carOrig2 = car2.GetComponent<MeshFilter>().mesh.vertices.ToList();
        dx = 0;
        dy2 = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        dx -= 1f;
        dy2 += 1f;
        Matrix4x4 tm = VectoringOps.TranslateToPositionMatrix(dx, 0, 0);
        Matrix4x4 rm = VectoringOps.RotateZ(90);
        Matrix4x4 sm = VectoringOps.TranslateToPositionMatrix(dy2, 0, 0);
        car1.GetComponent<MeshFilter>().mesh.vertices = VectoringOps.ApplyTransform(carOrig, tm).ToArray();
        car2.GetComponent<MeshFilter>().mesh.vertices = VectoringOps.ApplyTransform(carOrig2, rm * sm).ToArray();

    }
}
