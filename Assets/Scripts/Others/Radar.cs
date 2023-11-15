using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Unity.Mathematics;


public class Radar : MonoBehaviour
{

    [SerializeField] private Transform pfRadarPing;

   private Transform sweepTransform;
   private float rotationSpeed;
   private float radarDistance;
   private List<Collider2D> colliderList;


   private void Awake(){
        sweepTransform = transform.Find("Sweep");
        rotationSpeed = 45;
        radarDistance = 150f;
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
       RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, UtilsClass.GetVectorFromAngle(sweepTransform.eulerAngles.z), radarDistance);
        if (raycastHit2D.collider != null){
            //hit some
            if(!colliderList.Contains(raycastHit2D.collider)){
                //hit this one for the first time
                colliderList.Add(raycastHit2D.collider);
                Debug.Log("ping");
                Instantiate(pfRadarPing, raycastHit2D.point, quaternion.identity);
            }
        }

    }

}


