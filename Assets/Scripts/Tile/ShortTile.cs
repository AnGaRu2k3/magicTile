using UnityEngine;

public class ShortTile : BaseTile
{
    private bool isPress = false;
    public override void OnPress()
    {

        if (isPress) return;
        isPress = true;
       
        animator.SetTrigger("success");
        
        Debug.Log("isTouchBar:" + isTouchingPerfectBar);
        AddScore(1, isTouchingPerfectBar); 

    }
}
