using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
{
    public AnimationClipOverrides(int capacity) : base(capacity) { }

    public AnimationClip this[string name]
    {
        get { return this.Find(x => x.Key.name.Equals(name)).Value; }
        set
        {
            int index = this.FindIndex(x => x.Key.name.Equals(name));
            if (index != -1)
                this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
        }
    }
}

public class Anima
{
    public AnimationClip singleAttack;
    public AnimationClip comboAttack;
    public AnimationClip dashAttack;
    public AnimationClip smashAttack;
}


public class animatorOverrideController : MonoBehaviour
{
    public Anima[] anima;

    protected Animator animator;
    protected AnimatorOverrideController animaOverrideController;

    protected int weaponIndex;

    protected AnimationClipOverrides clipOverrides;
    public void Start()
    {
        animator = GetComponent<Animator>();
        weaponIndex = 0;

        animaOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animaOverrideController;

        clipOverrides = new AnimationClipOverrides(animaOverrideController.overridesCount);
        animaOverrideController.GetOverrides(clipOverrides);
    }

    public void Update()
    {
        if (Input.GetButtonDown("NextWeapon"))
        {
            weaponIndex = (weaponIndex + 1) % anima.Length;
            clipOverrides["SingleAttack"] = anima[weaponIndex].singleAttack;
            clipOverrides["ComboAttack"] = anima[weaponIndex].comboAttack;
            clipOverrides["DashAttack"] = anima[weaponIndex].dashAttack;
            clipOverrides["SmashAttack"] = anima[weaponIndex].smashAttack;
            animaOverrideController.ApplyOverrides(clipOverrides);
        }
    }

}
