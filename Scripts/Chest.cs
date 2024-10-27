using UnityEngine;

public class Chest : MonoBehaviour
{
    private readonly int OpenTrigger = Animator.StringToHash("Open");

    [SerializeField] private Animator animator;

    public void Open()
    {
        animator.SetTrigger(OpenTrigger);
    }
}
