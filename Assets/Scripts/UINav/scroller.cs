using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroller : MonoBehaviour
{
    [SerializeField] private RawImage RawImage;
    [SerializeField] private float x;

void Update()
    {
        RawImage.uvRect = new Rect(RawImage.uvRect.position + new Vector2(x, 0) * Time.deltaTime, RawImage.uvRect.size);
        
    }
}
