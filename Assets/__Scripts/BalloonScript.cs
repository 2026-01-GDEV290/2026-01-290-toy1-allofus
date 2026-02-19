using UnityEngine;
using System.Collections;

public class BalloonScript : MonoBehaviour
{
    [Header("Placement")]
    [SerializeField] private Vector3 initialPosition = Vector3.zero;

    [Header("Expand")]
    [SerializeField] private float expandMultiplier = 1.25f;
    [SerializeField] private float expandDuration = 0.25f;

    [Header("Attach")]
    [SerializeField] private float liftImpulse = 5f;
    [SerializeField] private Vector3 attachLocalOffset = Vector3.zero;
    [SerializeField] private bool disableDragOnAttach = true;
    [SerializeField] private float gravityScaleWhenAttached = -0.8f;
    [SerializeField] private bool applyCustomGravityWhenAttached = true;
    [SerializeField] private bool spawnReplacementOnAttach = true;
    [SerializeField] private GameObject balloonSpawnPrefab;

    private bool isAnimating;
    private Vector3 baseScale;
    private Camera mainCamera;
    private float dragDepth;
    private Vector3 dragOffset;
    private bool isDragging;
    private bool isAttached;
    private StringCollided stringCollided;
    private Rigidbody attachedRigidbody;
    private CharacterController attachedController;

    private void Start()
    {
        //transform.position = initialPosition;
        mainCamera = Camera.main;
        baseScale = transform.localScale;
        stringCollided = GetComponentInChildren<StringCollided>();
        if (stringCollided != null)
        {
            stringCollided.OnStringHit += HandleStringHit;
        }
    }

    private void OnDestroy()
    {
        if (stringCollided != null)
        {
            stringCollided.OnStringHit -= HandleStringHit;
        }
    }

    private void OnMouseDown()
    {
        if (isAttached && disableDragOnAttach)
        {
            return;
        }

        BeginDrag();
    }

    private void OnMouseDrag()
    {
        if (isAttached && disableDragOnAttach)
        {
            return;
        }

        if (isDragging)
        {
            UpdateDrag();
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void FixedUpdate()
    {
        if (!isAttached || !applyCustomGravityWhenAttached)
        {
            return;
        }

        if (attachedRigidbody != null)
        {
            attachedRigidbody.AddForce(Vector3.up * liftImpulse, ForceMode.Force);
        }
        else if (attachedController != null)
        {
            attachedController.Move(Vector3.up * liftImpulse * Time.deltaTime);
        }
    }

    private void HandleStringHit(Collider runnerCollider)
    {
        if (isAttached)
        {
            return;
        }

        Transform runnerTransform = runnerCollider.transform;
        transform.SetParent(runnerTransform, true);

        if (attachLocalOffset != Vector3.zero)
        {
            transform.localPosition = attachLocalOffset;
        }

        attachedRigidbody = runnerCollider.GetComponentInParent<Rigidbody>();
        attachedController = runnerCollider.GetComponentInParent<CharacterController>();

        if (attachedRigidbody != null)
        {
            if (applyCustomGravityWhenAttached)
            {
                attachedRigidbody.useGravity = false;
            }

            attachedRigidbody.AddForce(Vector3.up * liftImpulse, ForceMode.Impulse);
        }

        isAttached = true;
        isDragging = false;

        if (spawnReplacementOnAttach)
        {
            SpawnReplacementBalloon();
        }
    }

    private void SpawnReplacementBalloon()
    {
        BaloonThemToy toy = FindFirstObjectByType<BaloonThemToy>();
        if (toy != null)
        {
            toy.SpawnBalloon();
            return;
        }
    }

    private void BeginDrag()
    {
        if (mainCamera == null)
        {
            return;
        }

        isDragging = true;

        Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.position);
        dragDepth = screenPoint.z;

        Vector3 mouseScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragDepth);
        Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(mouseScreen);
        dragOffset = transform.position - mouseWorld;

        if (!isAnimating)
        {
            StartCoroutine(ExpandOnce());
        }
    }

    private void UpdateDrag()
    {
        if (mainCamera == null)
        {
            return;
        }

        Vector3 mouseScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragDepth);
        Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(mouseScreen);
        transform.position = mouseWorld + dragOffset;
    }

    private IEnumerator ExpandOnce()
    {
        isAnimating = true;
        Vector3 start = transform.localScale;
        Vector3 target = baseScale * expandMultiplier;

        float elapsed = 0f;
        while (elapsed < expandDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / expandDuration);
            transform.localScale = Vector3.Lerp(start, target, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }

        transform.localScale = target;
        isAnimating = false;
    }

}
