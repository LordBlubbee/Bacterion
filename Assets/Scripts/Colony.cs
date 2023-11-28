using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{
    public float colonySize;
    private float colonyMax = 6f;
    [SerializeField] private Transform colonyBlobTrans;
    [SerializeField] private SpriteRenderer colonyBlobSprite;
    [SerializeField] private SpriteRenderer colonySprite;

    private void Start()
    {
        updateColony();
    }
    void Update()
    {
        if (colonySize < colonyMax)
        {
            colonySize += Time.deltaTime*0.2f;
            updateColony();
        }
    }

    private void updateColony()
    {
        float scale = Mathf.Clamp01(colonySize);
        transform.localScale = new Vector3(scale, scale, 1);
        colonySprite.color = new Color(scale, scale, scale, scale);
        float fade = Mathf.Clamp01(colonySize * 0.25f-0.25f);
        colonyBlobSprite.color = new Color(fade, fade, fade, fade);
        scale = Mathf.Clamp(colonySize*0.5f-0.5f,0f,5f);
        colonyBlobTrans.localScale = new Vector3(scale, scale, 1);
    }
    public void takeDamage(float dmg)
    {
        colonySize -= dmg;
        if (colonySize < 0f)
        {
            Destroy(gameObject);
            return;
        }
        updateColony();
    }
}
