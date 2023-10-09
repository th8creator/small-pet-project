using TMPro;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    public int healthPoints = 20;
    public TextMeshProUGUI healthText;
    
    private void Start()
    {
        healthText = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        healthPoints = Random.Range(5, 31);
        healthText.text = healthPoints.ToString();
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 5f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
            healthPoints -= collision.gameObject.GetComponent<BulletBehaviour>().damage;
            if (healthPoints <= 0)
            {
                GetPrizeOnDestroy();
                Destroy(gameObject);
            }
            healthText.text = healthPoints.ToString();
            Destroy(collision.gameObject);

        }

    }

    public virtual void GetPrizeOnDestroy() { }
}
