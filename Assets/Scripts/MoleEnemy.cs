using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleEnemy : MonoBehaviour
{

    public float lifespan = 10f;

    private float lifetime;

    public SpriteRenderer spriteRenderer;
    public Sprite hitSprite;
    public Sprite defaultSprite;

    void OnMouseDown()
    {
        ChangeSprite();
        StartCoroutine(HitTime());


    }

    private void OnEnable()
    {
        lifetime = 0f;
        ReturnSprite();
    }

    void ChangeSprite()
    {


        spriteRenderer.sprite = hitSprite;


    }

    void ReturnSprite()
    {


        spriteRenderer.sprite = defaultSprite;


    }

    void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime >= lifespan)
        {
            MolePool.Instance.ReturnToPool(this);

        }


    }

    IEnumerator HitTime()
    {
        yield return new WaitForSeconds(1);
        MolePool.Instance.ReturnToPool(this);
    }
}
