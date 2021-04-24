using UnityEngine.SceneManagement;
using UnityEngine;

public class Partol_ChangeNextScene : MonoBehaviour
{
    void OnCollisionEnter(Collision obj)
    {
        if (obj.collider.tag == "Portal")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
