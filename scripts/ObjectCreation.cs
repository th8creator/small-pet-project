using System.Collections;
using UnityEngine;

public class ObjectCreation : MonoBehaviour
{
    public GameObject[] _objectPrefabs;  // 0 - coins || 1 - new gun || 2 - new player 

    public PlayerGunBehaviour playerGunBehaviour;

    public Transform[] _spawnPoints;
    private int randomPoint;
    private int randomObject;
    private int spawnedObject;

    private float randomGunObjectTime;
    private void Start()
    {
        StartCoroutine(CreateObjects());
    }
    IEnumerator CreateObjects()
    {
        while (true)
        {// через for попобровать 

           
           /* Generate random object
            * if randomObject = 0 - Coins Object || if 1 - Gun Object || if 2 - Helper Object;*/

            randomObject = Random.Range(0, 10);
            if (randomObject <= 6)
                spawnedObject = 0;
            else if (randomObject <= 8)
            {
                if (playerGunBehaviour.gunLevel + 1 < playerGunBehaviour._gunPrefab.Length)
                    spawnedObject = 1;
                else
                    spawnedObject = 0;
            }
            else if (randomObject == 9)
                spawnedObject = 0;

   
            yield return new WaitForSeconds(2f);

           

            randomPoint = Random.Range(0, _spawnPoints.Length);
            GameObject Object = Instantiate(_objectPrefabs[spawnedObject], _spawnPoints[randomPoint]);

            switch (spawnedObject)
            {
                case 0:
                    break;
                case 1:
                    if (playerGunBehaviour.gunLevel + 1 < playerGunBehaviour._gunPrefab.Length)
                    {
                        GameObject gun = Instantiate(playerGunBehaviour._gunPrefab[playerGunBehaviour.gunLevel + 1]);
                        gun.transform.position = Object.transform.position + new Vector3(-0.7f, 1f, 0f);
                        gun.transform.localScale = new Vector3(1f, 1f, 1f);
                        gun.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                        gun.transform.SetParent(Object.transform);
                        Object.gameObject.GetComponent<GunObject>().playerGunBehaviour = playerGunBehaviour;
                    }
                    break;
                case 2:
                    break;
                        
            }
        }
    }


}
