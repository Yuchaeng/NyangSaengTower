using UnityEngine;

namespace NekoLegends
{
    public class Projectile : MonoBehaviour
    {
        public enum ProjectileType
        {
            Straight,
            Arc
        }

        [Header("General Settings")]
        public float projectileSpeed = 10f;
        public float autoDestroyAfterSeconds = 3f;
        public ProjectileType type = ProjectileType.Straight;
        public GameObject explosionPrefab;  // Reference to your explosion prefab

        [Header("Arc Settings")]
        public Transform target; // Optional target for the arc
        public float noTargetArcDistance = 10; //default to a position 10 units forward
        public float arcHeight; // Maximum height of the arc
        public float arcHorizontalRange; // How much left or right the projectile can move from its direct path
        public float arcFrequency; // How fast the projectile oscillates left or right
        public bool rotateOnArc;
        private Vector3 startPosition;
        private float journeyLength;
        private float startTime;
        private bool isActive = false;

        private void Start()
        {
            startPosition = transform.position;
        }

        private void Update()
        {
            if (isActive)
            {
                if (type == ProjectileType.Straight)
                {
                    transform.Translate(transform.forward * projectileSpeed * Time.deltaTime, Space.World);
                }
                else if (type == ProjectileType.Arc && target != null)
                {
                    float distCovered = (Time.time - startTime) * projectileSpeed;
                    float fractionOfJourney = distCovered / journeyLength;

                    Vector3 currentArcPos = Vector3.Lerp(startPosition, target.position, fractionOfJourney);
                    // Modify the Y position based on a parabolic function
                    currentArcPos.y = startPosition.y + (arcHeight * 4 * fractionOfJourney * (1 - fractionOfJourney));
                    currentArcPos.x += arcHorizontalRange * Mathf.Sin(arcFrequency * Mathf.PI * 2 * fractionOfJourney);
                    // You might also adjust the Z position similarly if needed

                    transform.position = currentArcPos;

                    if (rotateOnArc)
                    {
                        // Adjust rotation to align with the tangent of the arc
                        float derivative = (arcHeight * 4 * (1 - 2 * fractionOfJourney));
                        Vector3 forward = target.position - startPosition;
                        forward.y = derivative;
                        Quaternion targetRotation = Quaternion.LookRotation(forward.normalized);
                        transform.rotation = targetRotation;
                    }

                    if (fractionOfJourney >= 1f)
                    {
                        SpawnExplosion();
                        isActive = false;
                        SetVisible(false);
                    }
                }
            }
        }


        public void SetVisible(bool visible)
        {
            this.gameObject.SetActive(visible);
        }

        public void ActivateProjectile()
        {
            isActive = true;
            SetVisible(true);
            Destroy(gameObject, autoDestroyAfterSeconds);

            if (type == ProjectileType.Arc)
            {
                startTime = Time.time;

                if (target == null) // If the target is not set, 
                {
                    target = new GameObject("TemporaryTarget").transform;
                    target.position = transform.position + transform.forward * noTargetArcDistance;
                    Destroy(target.gameObject, autoDestroyAfterSeconds);
                }

                startPosition = transform.position;
                journeyLength = Vector3.Distance(startPosition, target.position);
            }
        }

        private void SpawnExplosion()
        {
            if (explosionPrefab)
            {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
        }

    }
}
