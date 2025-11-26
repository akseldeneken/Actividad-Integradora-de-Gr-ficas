using UnityEngine;


public static class Vector2Extensions
{
    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        Quaternion rotation = Quaternion.AngleAxis(degrees, Vector3.forward);
        return rotation * v;
    }
}