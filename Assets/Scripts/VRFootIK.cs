using UnityEngine;

public class VRFootIK : MonoBehaviour {
    Animator animator;

    [Range(0, 1)]
    public float rightFootPosWeight = 1;
    [Range(0, 1)]
    public float leftFootPosWeight = 1;

    void Start() {
        animator = GetComponent<Animator>();
        Debug.Log($"animator {animator}");
    }

    void OnAnimatorIK(int _) {
        Debug.Log("OnAnimatorIK");
        SetFootIK(AvatarIKGoal.RightFoot, rightFootPosWeight);
        SetFootIK(AvatarIKGoal.LeftFoot, leftFootPosWeight);
    }

    void SetFootIK(AvatarIKGoal goal, float weight) {
        var footPos = animator.GetIKPosition(goal);
        if (Physics.Raycast(footPos + Vector3.up, Vector3.down, out var hit)) {
            animator.SetIKPositionWeight(goal, weight);
            animator.SetIKPosition(goal, hit.point);
        }
        else {
            animator.SetIKPositionWeight(goal, 0);
        }
    }
}
