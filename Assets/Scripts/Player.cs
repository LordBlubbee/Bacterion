using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    CAM cam;
    private void Start()
    {
        cam = FindObjectOfType<CAM>();
    }
    private void Update()
    {
        float ix = 0f;
        float iy = 0f;
        if (Input.GetKey(KeyCode.W)) iy += 1f;
        if (Input.GetKey(KeyCode.S)) iy -= 1f;
        if (Input.GetKey(KeyCode.A)) ix -= 1f;
        if (Input.GetKey(KeyCode.D)) ix += 1f;
        Vector3 Vec = new Vector3(ix,iy);
        transform.position += Vec * Time.deltaTime * MoveSpeed;
        transform.Rotate(new Vector3(0, 0, 1), AngleBetween(cam.transform.position + new Vector3(0,0,10)));
    }
    protected float AngleBetween(Vector3 towards)
    {
        return AngleBetween(transform.position, towards);
    }
    protected float AngleBetween(Vector3 from, Vector3 towards)
    {
        return Mathf.Abs(Vector2.SignedAngle(getLookVector(), towards - from));
    }
    protected float AngleBetween(Quaternion rotto, Vector3 from, Vector3 towards)
    {
        return Mathf.Abs(Vector2.SignedAngle(getLookVector(rotto), towards - from));
    }
    public float AngleBetween(Vector3 from1, Vector3 towards1, Vector3 from, Vector3 towards)
    {
        return Mathf.Abs(Vector2.SignedAngle(towards1 - from1, towards - from));
    }
    public Vector3 getLookVector()
    {
        return getLookVector(transform.rotation);
    }
    protected Vector3 getLookVector(Quaternion rotref)
    {
        float rot = Mathf.Deg2Rad * rotref.eulerAngles.z;
        float dxf = Mathf.Cos(rot);
        float dyf = Mathf.Sin(rot);
        return new Vector3(dxf, dyf, 0);
    }
}
