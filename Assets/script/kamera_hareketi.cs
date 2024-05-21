using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_hareketi : MonoBehaviour
{
   public Transform insan_karakteri;
   [Range(1,100)]
   public float hassasiyet;
   float kamera_acisi=0f;

    void Start()
    {
      
    }

    void Update()
    {
        float X=Input.GetAxis("Mouse X")*hassasiyet*Time.deltaTime;
        float Y=Input.GetAxis("Mouse Y")*hassasiyet*Time.deltaTime;
        kamera_acisi -= Y;
        kamera_acisi=Mathf.Clamp(kamera_acisi,-80f,80f);

        transform.localRotation=Quaternion.Euler(kamera_acisi,0f,0f);

        insan_karakteri.Rotate(Vector3.up*X);



        
    }
}
