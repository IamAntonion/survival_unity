using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    [Header("Camera")]
    public Camera mainCamera;

    [Header("Player options")]
    public float rotationSpeed = 1000.0f;
    public float heightPlayer = 1.0f;
    public float stopStart = 1.5f;
    public float speed = 5.0f;

    //Raycast
    private Ray ray;
    private RaycastHit hit;

    //Vector3
    private Vector3 target = new Vector3();
    private Vector3 lastTarget = new Vector3();
    private Vector3 dir = new Vector3();

    //angle
    private float angleToTarget;
    private float mag;

    //animation
    private Animator playerAnim;
    private bool walk;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                target = hit.point;
            }
        }
        LookAtThis();
        MoveTo();
    }

    private void LookAtThis()
    {
        if (target != lastTarget)
        {
            CalculateAngle(target);
            if (angleToTarget>3)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * UnityEngine.Time.deltaTime);
        }
    }

    private void CalculateAngle(Vector3 temp)
    {
        dir = new Vector3(temp.x, transform.position.y, temp.z) - transform.position;
        angleToTarget = Vector3.Angle(dir, transform.forward);
    }

    private void MoveTo()
    {
        if (target != lastTarget)
        {
            if ((transform.position - target).sqrMagnitude > heightPlayer + 0.1f)
            {
                if (!walk)
                {
                    playerAnim.SetBool("Move",true);
                    walk = true;
                }
                mag = (transform.position - target).magnitude;
                transform.position = Vector3.MoveTowards(transform.position, target, mag > stopStart ? speed * Time.deltaTime : Mathf.Lerp(speed * 0.5f, speed, mag / stopStart) * Time.deltaTime);
                ray = new Ray(transform.position, -Vector3.up);
                
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    transform.position = new Vector3(transform.position.x, hit.point.y + heightPlayer, transform.position.z);
                }
            }
            else
            {
                lastTarget = target;
                if (walk)
                {
                    playerAnim.SetBool("Move", false);
                    walk = false;
                }
            }
        }
    }
}
