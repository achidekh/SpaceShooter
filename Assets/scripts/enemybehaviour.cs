using UnityEngine;

public class enemybehaviour : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed;
    [SerializeField] float intervalle = 2f;
    [SerializeField] AudioClip son;

    GameObject player;
    float lastshot = 0;

    private void Start()
    {
        lastshot = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            gameObject.transform.forward = direction;

            if (Vector3.Distance(transform.position, player.transform.position) > 8f)
            {
                gameObject.transform.position = gameObject.transform.position + direction * speed * Time.deltaTime;

            }

            if (Time.time - lastshot > intervalle)
            {
                lastshot = Time.time;
                Instantiate(bulletPrefab, transform.position + direction + (transform.right / 4), transform.rotation);
                Instantiate(bulletPrefab, transform.position + direction + (transform.right / -4), transform.rotation);
                AudioSource.PlayClipAtPoint(son, transform.position,1f);
            }
        }
    }
}
