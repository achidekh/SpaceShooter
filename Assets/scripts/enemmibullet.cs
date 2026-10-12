using UnityEngine;

public class enemmibullet : MonoBehaviour
{

    [SerializeField] float speed = 35;
    void Update()
    {
        gameObject.transform.position = gameObject.transform.position + gameObject.transform.forward * speed * Time.deltaTime;
    }
}
