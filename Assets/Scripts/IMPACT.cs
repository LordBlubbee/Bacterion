using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMPACT : MonoBehaviour
{
    public SpriteRenderer spr;
    public float FadeSpeed = 2f;
    float Fade = 1f;
    void Update()
    {
        Fade -= Time.deltaTime;
        spr.color = new Color(1, 1, 1, Fade);
        if (Fade < 0f)
        {
            Destroy(gameObject);
        }
    }
}
