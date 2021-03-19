using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAlienAnimation : GiantAlienAnimator {

    protected override void Start()
    {
            base.Start();
    }
    protected override void Update()
    {
            base.Update();
    }
    
    public void OnAttack()
    {
        animator.SetTrigger("attack");
    }
   
  


   
}
