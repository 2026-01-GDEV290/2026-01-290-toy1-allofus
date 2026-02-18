using UnityEngine;

public class Grappler : MonoBehaviour
{
    //[SerializeField] GrappleThemToy grappleToy;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Camera mainCamera;

    Runner lastGrappledRunner = null;
    bool isDragging = false;

    void Awake()
    {
        if (!mainCamera) mainCamera = Camera.main;
        //if (!grappleToy) grappleToy = FindFirstObjectByType<GrappleThemToy>();

        if (!lineRenderer)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
        }

        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (!lineRenderer || !mainCamera) return;

        SpringJoint joint = GetComponent<SpringJoint>();
        bool hasAttachedJoint = joint && joint.connectedBody;
        lineRenderer.enabled = isDragging || hasAttachedJoint;

        if (!lineRenderer.enabled) return;

        lineRenderer.SetPosition(0, transform.position);

        if (isDragging)
        {
            Plane plane = new Plane(Vector3.forward, transform.position);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float enter))
            {
                Vector3 hit = ray.GetPoint(enter);
                lineRenderer.SetPosition(1, hit);
            }
        }
        else if (hasAttachedJoint)
        {
            Vector3 connectedWorldAnchor = joint.connectedBody.transform.TransformPoint(joint.connectedAnchor);
            lineRenderer.SetPosition(1, connectedWorldAnchor);
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        if (lineRenderer) lineRenderer.enabled = true;
        //
        Debug.Log("Grappler: Started dragging at " + Input.mousePosition);
        if (lastGrappledRunner)
        {
            // Cache velocity FIRST before destroying anything
            Rigidbody rb = lastGrappledRunner.GetComponent<Rigidbody>();
            Vector3 cachedVelocity = Vector3.zero;
            if (rb)
            {
                cachedVelocity = rb.linearVelocity;
            }

            // Remove SpringJoint from Grappler
            SpringJoint joint = GetComponent<SpringJoint>();
            if (joint) Destroy(joint);

            // Remove Rigidbody from Runner AFTER caching velocity
            // Restore rotation and remove Rigidbody
            //Rigidbody rb = lastGrappledRunner.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.constraints = RigidbodyConstraints.None;
                Destroy(rb);
            }

            // Re-enable CharacterController and apply cached velocity
            lastGrappledRunner.SetIgnoreGrounding(false, cachedVelocity);

            lastGrappledRunner = null;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        //if (grappleToy) grappleToy.
        OnGrapplerMouseUp(Input.mousePosition);

        if (lineRenderer)
        {
            SpringJoint joint = GetComponent<SpringJoint>();
            lineRenderer.enabled = joint && joint.connectedBody;
        }
    }

    public void OnGrapplerMouseUp(Vector3 mouseScreenPos)
    {
        if (!mainCamera) return;

        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Runner"))
            {
                Transform target = hit.collider.transform.parent ? hit.collider.transform.parent : hit.collider.transform;

                // Add Rigidbody to Runner
                Rigidbody runnerRb = target.GetComponent<Rigidbody>();
                if (!runnerRb)
                {
                    runnerRb = target.gameObject.AddComponent<Rigidbody>();
                }

                runnerRb.isKinematic = false;
                runnerRb.useGravity = true;
                runnerRb.constraints = RigidbodyConstraints.FreezeRotation;

                // Add Rigidbody to Grappler (this object)
                Rigidbody grapplerRb = GetComponent<Rigidbody>();
                if (!grapplerRb)
                {
                    grapplerRb = gameObject.AddComponent<Rigidbody>();
                }

                grapplerRb.isKinematic = false;
                grapplerRb.constraints = RigidbodyConstraints.FreezePosition;
                grapplerRb.useGravity = false;

                // Add SpringJoint to Grappler and connect to Runner
                SpringJoint joint = GetComponent<SpringJoint>();
                if (!joint)
                {
                    joint = gameObject.AddComponent<SpringJoint>();
                }

                joint.connectedBody = runnerRb;
                joint.autoConfigureConnectedAnchor = false;
                joint.anchor = Vector3.zero; // Local anchor on Grappler
                joint.connectedAnchor = runnerRb.transform.InverseTransformPoint(hit.point); // Local anchor on Runner at hit point
                joint.spring = 25f;
                joint.damper = 5f;
                joint.massScale = 1f;
                // Set min/max distance to prevent collision
                joint.minDistance = 1f; // Minimum distance before spring pushes back
                joint.maxDistance = 5f; // Maximum distance before spring pulls

                Runner runner = target.GetComponent<Runner>();
                if (runner)
                {
                    runner.SetIgnoreGrounding(true);
                    lastGrappledRunner = runner;
                }
            }
        }
    }
}