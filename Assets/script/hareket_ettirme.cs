using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class hareket_ettirme : MonoBehaviour
{
    CharacterController karakterkontrol;
    public Animator anim;
    public float speed;
    float speedilk;
    public float runspeeed;  
    public Transform tabandaki_nesne;
    UnityEngine.Vector3 oyuncu_konumu;
    bool yere_degdimi;
    public float ziplama_yuksekligi;
    public float yercekimi_degeri;
    public float kutlesi;
    public float yere_olan_mesafesi=0.4f;
    public LayerMask layer_ismi;

    void Start()
    {
        karakterkontrol = GetComponent<CharacterController>();
        speedilk=speed;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Animations();

        yere_degdimi=Physics.CheckSphere(tabandaki_nesne.position,yere_olan_mesafesi,layer_ismi);
        if(oyuncu_konumu.y<0 && yere_degdimi){
            oyuncu_konumu.y=-1;
        }

        float x=Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float z=Input.GetAxis("Vertical")*speed*Time.deltaTime;
        
        UnityEngine.Vector3 move=transform.right*x +transform.forward*z;
        karakterkontrol.Move(move*speed*Time.deltaTime);

        oyuncu_konumu.y += yercekimi_degeri*kutlesi*Time.deltaTime;

        karakterkontrol.Move(oyuncu_konumu*speed*Time.deltaTime);


        

        if(Input.GetKeyUp(KeyCode.Space)&& yere_degdimi){
            oyuncu_konumu.y += Mathf.Sqrt(yercekimi_degeri*-2*ziplama_yuksekligi);
        }

    void Run(){
        if(Input.GetKey(KeyCode.LeftShift)){
            speed=Mathf.Lerp(speed,runspeeed,Time.deltaTime);
        }
        else speed=speedilk;
    }
    void Animations(){
        if((Input.GetKey(KeyCode.W))){
            anim.SetFloat("yk_hareket",speed/(runspeeed*2));
            if(Input.GetKey(KeyCode.LeftShift)){
                anim.SetFloat("yk_hareket",Mathf.Lerp(speed/runspeeed,1f,Time.deltaTime));
            }
        }
        else anim.SetFloat("yk_hareket",0f);
         
        if(Input.GetKeyDown(KeyCode.S)){
            anim.SetTrigger("geri_yuru");
        }
        if(Input.GetKeyDown(KeyCode.A)){
            anim.SetTrigger("sola_yuru");
        }
        if(Input.GetKeyDown(KeyCode.D)){
            anim.SetTrigger("saga_yuru");
        }
    }
    }
}
