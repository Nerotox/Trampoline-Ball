using UnityEngine;

namespace Level
{
    public class CollisionHandler : MonoBehaviour
    {
    
        public BoxCollider2D finishFlagCollider2D;
        public EdgeCollider2D leftEdgeCollider2D;
        public EdgeCollider2D rightEdgeCollider2D;
        public EdgeCollider2D bottomEdgeCollider2D;
        public EdgeCollider2D topEdgeCollider2D;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == finishFlagCollider2D)
            {
                Debug.Log("hit the finish line!");
            }
            else if (other == leftEdgeCollider2D || other == rightEdgeCollider2D || other == bottomEdgeCollider2D ||
                     other == topEdgeCollider2D)
            {
                Debug.Log("hit an outside wall");
            }
        }
    }
}
