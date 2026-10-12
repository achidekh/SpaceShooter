
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayrControllr : MonoBehaviour
{
    [SerializeField] float speed = 4;
    [SerializeField] float forwardlimit;
    [SerializeField] float backwardlimit;
    [SerializeField] float rightlimit;
    [SerializeField] float leftlimit;
    [SerializeField] float uplimit;
    [SerializeField] float downlimit;
    [SerializeField] float tilt;
    [SerializeField] GameObject Laser;
    [SerializeField] float shotdelay;
    [SerializeField] GameObject crosshair;

    float lastshottime = 0;
    Vector3 move;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (GameManager.instance.playerState == GameManager.PlayerState.Play)
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {

        Vector3 direction = move.normalized;

        GetComponent<Rigidbody>().linearVelocity = direction * speed;

        float xclamp = Mathf.Clamp(gameObject.transform.position.x, leftlimit, rightlimit);
        float zclamp = Mathf.Clamp(gameObject.transform.position.z, backwardlimit, forwardlimit);
        float yclamp = Mathf.Clamp(gameObject.transform.position.y, downlimit, uplimit);


        gameObject.transform.position = new Vector3(xclamp, yclamp, zclamp);
        Quaternion newRotation = Quaternion.Euler(0, 0, -direction.x * tilt);
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, newRotation, 0.05f);
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector3>();
    }

    public void OnAttack(InputValue value)
    {
        if ((Time.time - lastshottime) > shotdelay)
        {
            GetComponent<AudioSource>().Play();
            Vector3 direction;

            Camera mainCamera = Camera.main;
            Ray ray = new Ray(mainCamera.transform.position, ((crosshair.transform.position-mainCamera.transform.position).normalized));
            Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity);

            if (hitInfo.collider != null)
            {
                Vector3 hitPoint = hitInfo.point;
                direction = (hitPoint - (gameObject.transform.position+ new Vector3(0, 0, 1))).normalized;
            }
            else
            {
                direction = (crosshair.transform.position - mainCamera.transform.position).normalized;
            }

            Vector3 spawnPosition = gameObject.transform.position + new Vector3(0, 0, 1);
            Quaternion spawnrotation = Quaternion.LookRotation(direction);
            
            Instantiate(Laser, spawnPosition, spawnrotation);
            lastshottime = Time.time;
        }
    }

}
