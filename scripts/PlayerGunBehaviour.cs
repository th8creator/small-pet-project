using System.Collections;
using UnityEngine;
public class PlayerGunBehaviour : MonoBehaviour
{
    private Transform gunObjectPosition;
    public Transform bulletsStorage;

    public int gunLevel { get; private set; }
    private GameObject gunModel;

    public GameObject[] bulletPrefab;
    public GameObject[] _gunPrefab;

    private Vector3[] _gunModelPosition = new Vector3[] { new Vector3(-0.156f, 0.3f, -0.398f), new Vector3(-0.023f, 0.337f, 0.168f), new Vector3(-0.083f, 0.3f, 0.117f), new Vector3(-0.033f, 0.3f, 0.023f) };
    private string[] _gunName = new string[] {"pistol","uzi","sniper rifle","Ak-47" };
    private float[] _fireSpeed = new float[] { 0.5f, 0.1f, 0.8f, 0.3f };//0.5 
    private int[] _gunDamage = new int[] { 2, 5, 2, 8 };
    private float[] _bulletSpeed = new float[] { 10f, 15f, 15f, 20 };
    private void Start()
    {

        gunModel = Instantiate(_gunPrefab[gunLevel]);
        gunModel.transform.position = _gunModelPosition[gunLevel];// + new Vector3(0.029f, 0.565f, -0.159f);
        gunModel.transform.SetParent(transform);
        gunObjectPosition = gameObject.transform.GetChild(1).GetChild(2);
        StartCoroutine(BulletCreation());
    }

    public void UpgradeGun()
    {
        StopCoroutine(BulletCreation());
        gunLevel++;
        Destroy(gunModel);
        Destroy(gameObject.transform.GetChild(1));
      
        gunModel = Instantiate(_gunPrefab[gunLevel]);      
        gunModel.transform.position = gameObject.transform.position + _gunModelPosition[gunLevel];// + new Vector3(0.029f, 0.565f, -0.159f);
        gunModel.transform.SetParent(transform);
    
 
    }
    IEnumerator BulletCreation()
    {
        while (true)
        {
            Debug.Log(gameObject.transform.GetChild(1).GetChild(2).name);
            if (gunObjectPosition != null)
            {
                GameObject Go = Instantiate(bulletPrefab[0], gunObjectPosition.transform);
                Go.transform.SetParent(bulletsStorage);
            }
            else
                gunObjectPosition = gameObject.transform.GetChild(1).GetChild(2);
            yield return new WaitForSeconds(_fireSpeed[gunLevel]);
        }

    }
}
