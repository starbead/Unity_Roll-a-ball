using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int TotalItemCount;
    public int stage;
    public Text stageCountText;
    public Text playerCountText;

    void Awake(){
        stageCountText.text = "/ " + TotalItemCount.ToString();
    }

    public void GetItem(int count){
        playerCountText.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other){
        
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(stage);
        }
    }
}
