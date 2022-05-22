using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControls : MonoBehaviour
{
    public GameObject AnimatioObject;
    Animator Anim;
    private void Awake()
    {
        Anim = AnimatioObject.GetComponent<Animator>();
    }
    private void Start()
    {
        SetShrug();
    }
    public void TriggerIdle() { Anim.SetTrigger("TriggerIdle"); }
    public void TriggerHappy() { Anim.SetTrigger("TriggerHappy"); }
    public void TriggerBored() { Anim.SetTrigger("TriggerBored"); }
    public void TriggerIdle2() { Anim.SetTrigger("TriggerIdle2"); }
    //
    
    void SetIdle() { Anim.SetBool("IdleActivated",true); Anim.SetBool("SadActivated", false); Anim.SetBool("ShrugActivated", false); Anim.SetBool("WalkActivated", false); Anim.SetBool("SwingActivated", false); }
    void SetSwing() { Anim.SetBool("SwingActivated", true); Anim.SetBool("IdleActivated", false); Anim.SetBool("SadActivated", false); Anim.SetBool("ShrugActivated", false); Anim.SetBool("WalkActivated", false); }
    void SetSad() { Anim.SetBool("SadActivated", true); Anim.SetBool("IdleActivated",false); Anim.SetBool("ShrugActivated", false); Anim.SetBool("WalkActivated", false); Anim.SetBool("SwingActivated", false); }
    void SetShrug() { Anim.SetBool("ShrugActivated", true); Anim.SetBool("IdleActivated", false); Anim.SetBool("SadActivated", false); Anim.SetBool("WalkActivated", false); Anim.SetBool("SwingActivated", false); }
    void SetWalk() { Anim.SetBool("WalkActivated", true); Anim.SetBool("IdleActivated", false); Anim.SetBool("SadActivated", false); Anim.SetBool("ShrugActivated", false); Anim.SetBool("SwingActivated", false); }
    public void OnToggleChangeIdle() { SetIdle();  }
    public void OnToggleChangeSwing() { SetSwing(); }
    public void OnToggleChangeSad() { SetSad(); }
    public void OnToggleChangeShrug() { SetShrug(); }
    public void OnToggleChangeWalk() { SetWalk(); }
}
