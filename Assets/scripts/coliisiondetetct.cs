using System.Security.Cryptography;
using UnityEngine;

public class coliisiondetetct : MonoBehaviour
{
    [SerializeField] GameObject AstroidVFX;
    [SerializeField] GameObject PlayerVFX;
    [SerializeField] GameObject EnemyVFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            GameManager.instance.AddScore(100);
            Instantiate(EnemyVFX, other.gameObject.transform.position, Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("astroid"))
        {
            Instantiate(AstroidVFX, gameObject.transform.position, Quaternion.identity);
            GameManager.instance.AddScore(50);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.mort();
            Instantiate(PlayerVFX, gameObject.transform.position, Quaternion.identity);

        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.mort();
            Instantiate(AstroidVFX, gameObject.transform.position, Quaternion.identity);
            Instantiate(PlayerVFX, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
