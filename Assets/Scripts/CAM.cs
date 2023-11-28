using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM : MonoBehaviour
{
    Player pl;
    private void Start()
    {
        pl = FindObjectOfType<Player>();
    }

    private void Update()
    {
        transform.position = pl.transform.position + new Vector3(0, 0, -10);
    }
}
