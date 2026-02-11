using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate;


    private void Awake()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(fireRate);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        StartCoroutine(Shoot());
    }
}
