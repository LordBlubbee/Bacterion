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
}
