using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] public float speed;
    private Vector3 initialPos;
    private SpriteRenderer spr;

    private float realImageSize;
    void Start()
    {
        initialPos = transform.position;
        spr = GetComponent<SpriteRenderer>();

        //compute image size to repeat
        float imageSize = spr.size.x;
        realImageSize = imageSize * transform.localScale.x;  

    }

    // Update is called once per frame
    void Update()
    {
        float shifting = Mathf.Repeat(speed * Time.time, realImageSize);
        transform.position = initialPos + Vector3.left * shifting;
    }
}
