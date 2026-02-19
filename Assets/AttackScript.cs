using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class AttackScript : MonoBehaviour
{
    [SerializeField]
    float Timer = 0.25f;
    [SerializeField]
    CinemachineShake cinemachineShake;
    [SerializeField]
    AudioSource AudioHit;

    private void Start()
    {
        cinemachineShake = GameObject.FindGameObjectWithTag("Camera").GetComponent<CinemachineShake>();
    }
    public void pitchSet(float pitch)
    {
        AudioHit.pitch = pitch;
    }

    public void stutterFrame(float mult)
    {
        StartCoroutine(refrsh(mult));
        cinemachineShake.ShakeCamera(1.5f);
        AudioHit.Play();
    }


    IEnumerator refrsh(float mult)
    {
        yield return new WaitForSecondsRealtime((Timer * mult));
        cinemachineShake.StopShake();
    }
}
