using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VectoringOps{
    public static float Dot(Vector3 a, Vector3 b) {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    public static float Magnitude(Vector3 v) {
        return Mathf.Sqrt(v.x*v.x+v.y*v.y+v.z*v.z);
    }

    public static Vector3 Unitary(Vector3 v) {
        float vm = Magnitude(v);
        return new Vector3(v.x / vm, v.y / vm, v.z / vm);
    }

    public static float Angle(Vector3 a, Vector3 b) {
        Vector3 ua = Unitary(a);
        Vector3 ub = Unitary(b);
        return Mathf.Acos(Dot(ua, ub));
    }

    public static Vector3 Cross(Vector3 a, Vector3 b) {
        float x = a.y * b.z - a.z * b.y;
        float y = a.z * b.x - a.x * b.z;
        float z = a.x * b.y - a.y * b.x;
        return new Vector3(x, y, z);
    }

    //Translate, Scale y Rotate
    public static Matrix4x4 TranslateToPositionMatrix(float dx, float dy, float dz) {
        Matrix4x4 tm = Matrix4x4.identity;
        tm[0, 3] = dx;
        tm[1, 3] = dy;
        tm[2, 3] = dz;

        return tm;
    }

    public static Matrix4x4 ScaleToSizeMatrix(float dx, float dy, float dz) {
        Matrix4x4 tm = Matrix4x4.identity;
        tm[0, 0] = dx;
        tm[1, 1] = dy;
        tm[2, 2] = dz;

        return tm;
    }

    public static Matrix4x4 RotateX(float degrees) {
        float radians = degrees * Mathf.Deg2Rad;
        Matrix4x4 rm = Matrix4x4.identity;

        rm[1, 1] = Mathf.Cos(radians);
        rm[1, 2] = -Mathf.Sin(radians);
        rm[2, 1] = Mathf.Sin(radians);
        rm[2, 2] = Mathf.Cos(radians);

        return rm;
    }

    public static Matrix4x4 RotateY(float degrees) {
        float radians = degrees * Mathf.Deg2Rad;
        Matrix4x4 rm = Matrix4x4.identity;

        rm[0, 0] = Mathf.Cos(radians);
        rm[0, 2] = Mathf.Sin(radians);
        rm[2, 0] = -Mathf.Sin(radians);
        rm[2, 2] = Mathf.Cos(radians);

        return rm;
    }

    public static Matrix4x4 RotateZ (float degrees) {
        float radians = degrees * Mathf.Deg2Rad;
        Matrix4x4 rm = Matrix4x4.identity;

        rm[0, 0] = Mathf.Cos(radians);
        rm[0, 1] = -Mathf.Sin(radians);
        rm[1, 0] = Mathf.Sin(radians);
        rm[1, 1] = Mathf.Cos(radians);

        return rm;
    }
    
    public static List<Vector3> ApplyTransform(List<Vector3> originals, Matrix4x4 m) {
        List<Vector3> result = new List<Vector3>();
        foreach(Vector3 o in originals)
        {
            Vector4 temp = new Vector4(o.x, o.y, o.z, 1);
            temp = m * temp;
            result.Add(temp);
        }
        return result;
    }
}