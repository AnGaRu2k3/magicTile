    using UnityEngine;

    public abstract class BaseTile : MonoBehaviour
    {
        public float fallSpeed = 5f; // Tốc độ rơi của tile
        public Animator animator;
        public TileObjectPool tilePool;
        protected bool isTouchingPerfectBar = false;

        public virtual void Start()
        {
            animator = GetComponent<Animator>();
            
        }
        protected virtual void Update()    
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime; // fall down
        }

        protected virtual void MoveTile()
        {
        
        }

        public abstract void OnPress();

        public virtual void OnRelease() { }

        protected void AddScore(int scoreValue, bool isTouchBar)
        {
            GameManager.Instance.AddScore(scoreValue, isTouchBar);
        }
        public virtual void  OnBecameInvisible()
        {
            tilePool.ReturnTile(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PerfectBar"))
            {
                isTouchingPerfectBar = true;
            }
        }

        // Khi Tile rời khỏi PerfectBar
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("PerfectBar"))
            {
                isTouchingPerfectBar = false;
            }
        }


}
