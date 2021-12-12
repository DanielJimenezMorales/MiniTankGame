using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TankShoot
{
    #region Dependencies
    private TankSoundsData soundsData = null;
    private AudioConsumer firingAudioConsumer = null;
    #endregion

    #region Variables
    private Transform shootPointTransform = null;
    private GameObject explosionPrefab = null;
    private GameObject tankExplosion = null;
    private bool isAbleToShoot = true;
    #endregion

    public TankShoot(Transform shootPoint, TankSoundsData sounds, AudioConsumer audioConsumer, GameObject explosion, GameObject tank)
    {
        shootPointTransform = shootPoint;
        soundsData = sounds;
        firingAudioConsumer = audioConsumer;
        explosionPrefab = explosion;
        tankExplosion = tank;

        firingAudioConsumer.Initialize();
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0) && isAbleToShoot)
        {
            isAbleToShoot = false;
            Fire();
        }
    }

    private void Fire()
    {
        firingAudioConsumer.PlayAudio(soundsData.GetFiringSound());
        GameObject.Instantiate(tankExplosion, shootPointTransform.position, Quaternion.identity);
        Ray bulletRay = new Ray(shootPointTransform.position, shootPointTransform.forward);
        RaycastHit hit;
        if(Physics.Raycast(bulletRay, out hit, 100f))
        {
            Debug.Log("Hit something");
            GameObject.Instantiate(explosionPrefab, hit.point, Quaternion.identity);
        }

        Reload();
    }

    private void Reload()
    {
        ReloadDelay();
    }

    private async void ReloadDelay()
    {
        await Task.Delay(3000);
        isAbleToShoot = true;
    }

    private void ApplyCannonRecoil()
    {

    }
}
