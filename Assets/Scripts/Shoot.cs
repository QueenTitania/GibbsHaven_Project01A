using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float shootForce = 1000;
    [SerializeField] ParticleSystem impactParticle;
    [SerializeField] AudioSource impactClip;

    public void ShootCharge(GameObject bullet)
    {
        GameObject shot = Instantiate(bullet, transform.position, transform.rotation);
        shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem particle = Instantiate(impactParticle, this.transform.position, this.transform.rotation);
        AudioSource audio = Instantiate(impactClip, this.transform.position, this.transform.rotation);
        Impact();
        ParticleSystem.Destroy(particle);
        AudioSource.Destroy(audio);
        GameObject.Destroy(this);
    }

    private void Impact()
    {
        impactParticle.Play();
        impactClip.Play();

    }

}
