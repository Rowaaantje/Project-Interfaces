using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textScroller : MonoBehaviour
{
    public GameObject TextMeshPro;
    public int ScrollSpeed;
    public int MaxHeight;
    public int StartHeight;
    private TMP_Text Text;
    private Vector3 _myVector3;
    private Vector3 _startVector3;
    private int index = 0;


    private string[] NameList = { "Rowan", "Tim", "Nolan" };
    void Start()
    {
        _myVector3 = new(0, ScrollSpeed, 0);
        _startVector3 = new(0, StartHeight, 0);
    }
    void Update()
    {
        RectTransform myRectTransform = GetComponent<RectTransform>();
        myRectTransform.localPosition += _myVector3 * Time.deltaTime;
        if (myRectTransform.localPosition.y > MaxHeight)
        {
            Text = GetComponent<TMP_Text>()!;
            myRectTransform.localPosition = _startVector3;
            Text.text = NameList[index];
            index++;
            if (index == 3)
            {
                index = 0;
            }
        }
    }
}
