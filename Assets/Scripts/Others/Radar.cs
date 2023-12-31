using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Unity.Mathematics;
using JetBrains.Annotations;

public class Radar : MonoBehaviour
{
    RadarPing radarPing;

    [SerializeField] private Transform pfRadarPing;
    [SerializeField] private LayerMask layerMask;
    // private int layerMask = 1 << 6; 


   private Transform sweepTransform;
   public float rotationSpeed = 180f;
   private float radarDistance = 3000f;
   private List<Collider2D> colliderList;

   private void Awake(){
        rotationSpeed = 180f;
        sweepTransform = transform.Find("Sweep");
        colliderList = new List<Collider2D>();
   }

    private void Update(){

        float previousRotation = (sweepTransform.eulerAngles.z % 360) - 180;
        sweepTransform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        float currentRotation = (sweepTransform.eulerAngles.z % 360) -180;

        if(previousRotation < 0 && currentRotation >=0){
            //half rotation
            colliderList.Clear();
        }

       RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, UtilsClass.GetVectorFromAngle(sweepTransform.eulerAngles.z), radarDistance, layerMask);
        if (raycastHit2D.collider != null){
            //hit some
            if(!colliderList.Contains(raycastHit2D.collider)){
                //hit this one for the first time
                colliderList.Add(raycastHit2D.collider);
                Debug.Log("ping");
                Instantiate(pfRadarPing, raycastHit2D.point, quaternion.identity);
            }
        }
        // radarPing.SetDisappearTimer(360 / rotationSpeed * 2f);
    }
    public void ChangeSpeed(float speed)
    {
        rotationSpeed = speed;
    }
}


