using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static Vector3 IntersectXY(this Ray ray)
    {
        return ray.origin + ray.direction * (-ray.origin.z / ray.direction.z);
    }


}
