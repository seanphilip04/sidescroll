using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorizontalMovement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    float t;
    public float distance, speed;
    private float originalPos;

    void Start()
    {
        originalPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;
        var x = originalPos + Mathf.Sin(t) * distance;
        transform.position = new Vector2(x, transform.position.y);
        if (x < (originalPos-(distance - 0.01)))
        {
            spriteRenderer.flipX = false;
        }
        else if (x > (originalPos+(distance - 0.01)))
        {
            spriteRenderer.flipX = true;
        }
    }
}
