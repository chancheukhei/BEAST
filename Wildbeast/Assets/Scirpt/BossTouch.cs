using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossTouch : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Collision Detected");
            playerHealth playerData = col.gameObject.GetComponent<playerHealth>();
            playerData.causeDead();
        }
    }


}