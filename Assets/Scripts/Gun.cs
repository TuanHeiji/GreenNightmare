using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Gun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float rotateOffset = 180f;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotDelay = 0.15f;
    [SerializeField] private int maxAmmo = 20;
    [SerializeField] private TextMeshProUGUI bulletScore;
    private float nextShot;
    public int curentAmmo;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Start()
    {
        curentAmmo = maxAmmo;
        UpdateBulletScore();
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        Shot();
        ReLoad();
    }

    void RotateGun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);
        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        } 
    }

    void Shot()
    {
        if(Input.GetMouseButtonDown(0) && curentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefab.transform, firePos.position, firePos.rotation);
            audioManager.PlayShotSound();
            curentAmmo--;
            UpdateBulletScore();
        }
        
    }

    void ReLoad()
    {
        if(Input.GetMouseButtonDown(1) && curentAmmo == 0)
        {
            curentAmmo = maxAmmo;
            UpdateBulletScore();
        }
    }

    private void UpdateBulletScore()
    {
        bulletScore.text = curentAmmo.ToString();
    }
}
