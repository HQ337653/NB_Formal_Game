using UnityEngine;
using System.Collections;
using Spine;
using Spine.Unity;

public class KnightControl : MonoBehaviour
{
    #region Inspector
    public float AtkSpeed;
    public float MoveSpeed;

    // [SpineAnimation] attribute allows an Inspector dropdown of Spine animation names coming form SkeletonAnimation.
    [SpineAnimation]
    public string runAnimationName;

    [SpineAnimation]
    public string idleAnimationName;

    [SpineAnimation]
    public string walkAnimationName;

    [SpineAnimation]
    public string atkAnimationName_1;

    [SpineAnimation]
    public string atkAnimationName_2;

    [SpineAnimation]
    public string jumpAnimationName;

    [SpineAnimation]
    public string hitAnimationName;

    [SpineAnimation]
    public string deathAnimationName;

    [SpineAnimation]
    public string stunAnimationName;

    [SpineAnimation]
    public string skillAnimationName_1;
    [SpineAnimation]
    public string skillAnimationName_2;
    [SpineAnimation]
    public string skillAnimationName_3;

    #endregion


   [SerializeField] SkeletonAnimation skeletonAnimation;

    // Spine.AnimationState and Spine.Skeleton are not Unity-serialized objects. You will not see them as fields in the inspector.
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    // Start is called before the first frame update
    void Start()
    {
        spineAnimationState = skeletonAnimation.AnimationState;
        spineAnimationState.SetAnimation(0, idleAnimationName, true);
        skeleton = skeletonAnimation.Skeleton;
    }

    public void running()
    {
      spineAnimationState.SetAnimation(0, runAnimationName, true).TimeScale = MoveSpeed;
    }
    public void walking()
    {
        spineAnimationState.SetAnimation(0, walkAnimationName, true).TimeScale = MoveSpeed;
    }
    public void idle()
    {
        spineAnimationState.SetAnimation(0, idleAnimationName, true);
    }
    public void jump()
    {
        spineAnimationState.SetAnimation(0, jumpAnimationName, true);
    }
    public void getHit()
    {
        spineAnimationState.SetAnimation(0, hitAnimationName, true);
    }
    public void death()
    {
        spineAnimationState.SetAnimation(0, deathAnimationName, true);
    }
    public void stun()
    {
        spineAnimationState.SetAnimation(0, stunAnimationName, true);
    }
    public void attack_1()
    {
        spineAnimationState.SetAnimation(0, atkAnimationName_1, true).TimeScale = AtkSpeed;
    }
    public void attack_2()
    {
        spineAnimationState.SetAnimation(0, atkAnimationName_2, true).TimeScale = AtkSpeed;
    }
    public void skill_1()
    {
        spineAnimationState.SetAnimation(0, skillAnimationName_1, true).TimeScale = AtkSpeed;
    }
    public void skill_2()
    {
        spineAnimationState.SetAnimation(0, skillAnimationName_2, true).TimeScale = AtkSpeed;
    }
    public void skill_3()
    {
        spineAnimationState.SetAnimation(0, skillAnimationName_3, true).TimeScale = AtkSpeed;
    }

    public void changeWalkSpeed(float speed)
    {
        if (speed>=0) {
            MoveSpeed = speed;
            changeSpeed(MoveSpeed);
        }
    }
    public void changeAtkSpeed(float speed)
    {
        if (speed >= 0)
        {
            AtkSpeed = speed;
            changeSpeed(AtkSpeed);
        }
    }
    private void changeSpeed(float speed)
    {
      //TrackEntry trackEntry=  spineAnimationState.GetCurrent(0);
        //trackEntry.TimeScale = speed;
    }


}
