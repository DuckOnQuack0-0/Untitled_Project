using UnityEngine;

public class PrototypeGun : MonoBehaviour
{
    [SerializeField] private GameObject gunBarrel;
    public Camera mainCam;

    [SerializeField] private float range = 100f;
    public float damage = 10f;

    [SerializeField] private float fireRate = 15f;
    [SerializeField] private float nextTimeToFire = 0f;

    public GameObject bangStandin;


    private void Awake()
    {
        bangStandin.SetActive(false);
        gunBarrel = GameObject.FindGameObjectWithTag("PrototypeBarrel");
        mainCam = Camera.FindObjectOfType<PlayerLook>().GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            FireWeapon();
            bangStandin.SetActive(true);
            if(bangStandin)
            print("Shot Fired!");
        }
        else
        {
            bangStandin.SetActive(false);
        }
    }

    private void FireWeapon()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward, Color.cyan);

           Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Damage(damage);
            }
        }
            
    }
}
