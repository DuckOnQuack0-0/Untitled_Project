using UnityEngine;
using UnityEngine.UI;

public class PrototypeGun : MonoBehaviour
{
    [SerializeField] private GameObject gunBarrel;
    public Camera mainCam;

    public float range = 100f;
    public float damage = 10f;
    [SerializeField]private float maxAmmo = 85f;

    [SerializeField] private float fireRate = 20f;
    [SerializeField] private float nextTimeToFire = 0f;
    public int bulletsLeft = 17;

    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private ParticleSystem muzzleParticles;
    
    public Image crosshair;
    private AudioSource gunShot;
    public GameObject reloadText;

    [SerializeField] private bool needsToReload = false;
    public bool firedGun = false;

    public GameObject impactParticle;



    private void Awake()
    {
        #region TempCode
        /*Using Temperary UI for the muzzle flash 
        bangStandin.SetActive(false);*/
        #endregion
        //Finding the game object in the heirarchy via Tag 
        gunBarrel = GameObject.FindGameObjectWithTag("PrototypeBarrel");
        //Finding the camera via component on to where the player look script is located
        mainCam = Camera.FindObjectOfType<PlayerLook>().GetComponent<Camera>();
        //Finding the gunShot audio source attached to the gameobject 
        gunShot = GetComponent<AudioSource>();
        //GameObject containing the muzzlefalsh particles
        muzzleFlash = GameObject.FindGameObjectWithTag("PrototypeMuzzleFlash");
        //The particle system component with in the muzzleFlash gameObject 
        muzzleParticles = muzzleFlash.GetComponent<ParticleSystem>();
        //Setting the text inactive until called later in the script 
        reloadText.SetActive(false);
        #region Test Animator Code
        //Getting the animatior component
        //animator = GetComponent<Animator>();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && needsToReload == false && bulletsLeft > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            FireWeapon();
            firedGun = true;
            muzzleParticles.Play();
            gunShot.Play();
            bulletsLeft -= 1;
            //maxAmmo -= 1f;
            #region TestCode
            /*bangStandin.SetActive(true);
            if (bangStandin)
                print("Shot Fired!");*/
            #endregion
        }

        if (bulletsLeft == 0)
        {
            needsToReload = true;
            reloadText.SetActive(true);
        }
        else if(bulletsLeft > 0)
        {
            needsToReload = false;
            reloadText.SetActive(false);
        }

        Reload();

        RaycastHit hit;

        if(Physics.Raycast(mainCam.transform.position,mainCam.transform.forward, out hit, range))
        {
            Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * range, Color.cyan);
            Target target = hit.transform.GetComponent<Target>();
            

            if(target != null)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
            }
        }
    }

    private void FireWeapon()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * range, Color.cyan);

           Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Damage(damage);
            }

            GameObject impactGO = Instantiate(impactParticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

        }
            
    }

    private void Reload()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            bulletsLeft = 17;
        } 
        
    }
}
