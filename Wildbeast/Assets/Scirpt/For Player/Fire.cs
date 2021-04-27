using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{

    public float range = 20f;
    public float force = 20f;
    public GameObject hitFX;
    public AudioClip hitSound;
    public float hitValue = 1f;

    AudioSource fire;

    void Start()
    {
        fire = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")
            && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.green);
            RaycastHit hit;
            fire.PlayOneShot(hitSound);
            if (Physics.Raycast(ray, out hit, range))
            {
                Instantiate(hitFX, hit.point, Quaternion.identity);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(force * ray.direction,
                                                     hit.point, ForceMode.Impulse);
                    hit.transform.SendMessage("Hit", hitValue);
                }
            }
        }
    }
}