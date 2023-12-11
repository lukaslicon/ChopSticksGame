using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject heldObject;
    private Rigidbody heldObjectRb;
    private Vector3 objectOffset;
    private bool isHolding = false;

    private float grabDistance = 5f;
    private float throwForce = 1f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (!isHolding && Physics.Raycast(ray, out hit, grabDistance) && hit.collider.gameObject == gameObject)
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();

                if (heldObjectRb != null)
                {
                    isHolding = true;
                    heldObjectRb.useGravity = false;
                    objectOffset = hit.point - heldObject.transform.position;
                }
            }
            else if (isHolding && heldObjectRb != null)
            {
                heldObjectRb.useGravity = true;
                Vector3 throwDirection = mainCamera.transform.forward + mainCamera.transform.up * 0.5f;
                heldObjectRb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
                isHolding = false;
                heldObject = null;
                heldObjectRb = null;
            }
        }

        if (isHolding && heldObjectRb != null)
        {
            // Update the held object's position
            Vector3 targetPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, grabDistance));
            heldObjectRb.MovePosition(targetPosition - objectOffset);
        }
    }
}
