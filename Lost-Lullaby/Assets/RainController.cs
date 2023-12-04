using System.Collections;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    public float rainActiveDuration = 30f; // Active for 30 sec
    public float rainInactiveDuration = 120f; // Inactive for 2 mins

    private void Start()
    {
        StartCoroutine(ManageRain());
    }

    private IEnumerator ManageRain()
    {
        while (true)
        {
            Debug.Log("Start rain");
            rainParticleSystem.Play(); 
            yield return new WaitForSeconds(rainActiveDuration); // Wait for active duration

            Debug.Log("Stop rain");
            rainParticleSystem.Stop();
            yield return new WaitForSeconds(rainInactiveDuration); // Wait for inactive duration
        }
    }
}
