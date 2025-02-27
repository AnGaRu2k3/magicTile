using UnityEngine;

public class TileInputHandler : MonoBehaviour
{
    private BaseTile tile;

    private void Awake()
    {
        tile = GetComponent<BaseTile>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                tile?.OnPress();
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            tile?.OnRelease();
        }
    }
}
