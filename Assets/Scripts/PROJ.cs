using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROJ : MonoBehaviour
{
    public float Speed;
    public float Duration;
    public IMPACT Boom;
    void Start()
    {
        
    }
    void Update()
    {
        Duration -= Time.deltaTime;
        if (Duration < 0f) Destroy(gameObject);
        transform.position += Speed * getLookVector() * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Macrophage>(out Macrophage mac))
        {
            Instantiate(Boom,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
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
