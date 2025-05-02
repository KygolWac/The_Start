using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeCheck : MonoBehaviour
{
    public bool isOnSlope = false;
    public Vector2 slopeNormalPerp;

    [SerializeField]
    private float maxSlopeAngle;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float slopeCheckDistance;


    private float slopeDownAngle;
    private float slopeSideAngle;
    private float lastSlopeAngle;

    // private int LayerID;
    // whatIsGround = LayerMask.GetMask("Ground");

    private Vector2 capsuleColliderSize;
    private CapsuleCollider2D cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CapsuleCollider2D>();
        capsuleColliderSize = cc.size;
        // LayerID = LayerMask.NameToLayer("Ground");
        // whatIsGround = 1<<LayerID;

    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }
    private void Check()
    {
        Vector2 checkPos = transform.position - (Vector3)(new Vector2(0.0f, capsuleColliderSize.y / 2));
        //Debug.Log("Checking slope");
        SlopeCheckHorizontal(checkPos);
        SlopeCheckVertical(checkPos);
    }

    private void SlopeCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, slopeCheckDistance, whatIsGround);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, slopeCheckDistance, whatIsGround);

        if (slopeHitFront)
        {
            //Debug.Log("SlopeHitFront");
            isOnSlope = true;

            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);

        }
        else if (slopeHitBack)
        {
            //Debug.Log("SlopeHitBack");
            isOnSlope = true;

            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }
        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }

    }

    private void SlopeCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, whatIsGround);

        if (hit)
        {

            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;

            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if (slopeDownAngle != lastSlopeAngle)
            {
                isOnSlope = true;
            }

            lastSlopeAngle = slopeDownAngle;

            Debug.DrawRay(hit.point, slopeNormalPerp, Color.blue);
            Debug.DrawRay(hit.point, hit.normal, Color.green);

        }
    }
}
