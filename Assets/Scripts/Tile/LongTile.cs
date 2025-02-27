using UnityEngine;

public class LongTile : BaseTile
{
    public float holdDuration = 1f; 
    private float holdTimer = 0f;
    private bool isPress = false;
    private int point = 0;
    private bool holdDone = false;
    bool isTouchbar = false;

    public override void OnPress()
    {
        if (isPress) return;
        point = 1;
        animator.SetTrigger("press");

    }

    public override void OnRelease()
    {
        if (holdDone) return; // if point had add whenever not release
        Debug.Log("tha ra tr khi done");
        animator.speed = 0;

        isPress = true;
        
        AddScore(point, isTouchingPerfectBar);
    }
    public void AddHoldTileCompletelyEvent()
    {
        Debug.Log("da done");
        point = 3;
        holdDone = true;
        animator.SetTrigger("success"); // compeletely
     
        AddScore(point, isTouchingPerfectBar);
    }
}
