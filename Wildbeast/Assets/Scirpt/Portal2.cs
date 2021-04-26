using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal2 : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("Stage_3_Beach");
        }
    }
}
