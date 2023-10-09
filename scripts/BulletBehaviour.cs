using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody bulletRigidBody;
    private float lifeTime = 3f;

    public int damage { get; private set; } = 5;
    private void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 15f);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
        
    }


}
