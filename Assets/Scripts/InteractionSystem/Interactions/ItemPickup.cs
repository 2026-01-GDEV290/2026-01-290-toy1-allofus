using DG.Tweening;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    [SerializeField]
    private float _animationDuration = 05f;
    private bool _hasInteracted = false;
    public bool CanInteract()
    {
        if (_hasInteracted)
        {
            return false;
        }
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        transform.DOMove(interactor.transform.position, _animationDuration).OnComplete(() => Destroy(gameObject));
        return true;
    }
}
