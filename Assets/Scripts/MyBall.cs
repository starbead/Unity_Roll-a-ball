                                                                                                                using System.Collections;
                                                                                                            
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBall : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    public float jumpPower;
    bool isJump;
    public int itemCount;
    AudioSource audio;
    public GameManager manager;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update(){
        if(Input.GetButtonDown("Jump") && isJump == false){
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate(){
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);

        rigid.AddForce(vec, ForceMode.Impulse);
    }

   void OnCollisionEnter(Collision collision){
       if(collision.gameObject.tag == "Floor"){
           isJump = false;
       }
   }
   
   void OnTriggerEnter(Collider other){

       if(other.tag == "Item"){
           itemCount++;
           audio.Play();
           other.gameObject.SetActive(false);
           manager.GetItem(itemCount);
       }

       else if(other.tag == "Goal"){
           if(itemCount == manager.TotalItemCount){
               //Game Cler!
               if(manager.stage == 2){
                   SceneManager.LoadScene(0);
               }
               else{
                   SceneManager.LoadScene(manager.stage+1);
               }
           }
           else{
               //Game Restart
                SceneManager.LoadScene(manager.stage);
           }
       }
   }
}
