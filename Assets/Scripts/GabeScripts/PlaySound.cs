using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public static PlaySound instance;
    public static AudioClip[] clip_list;
    public AudioClip[] clips;

    /*Example implementation
    PlaySound.OneShot(thisCustomer, footstepClip); //This will play a one shot clip of the footstepClip sound from the referenced GameObject thisCustomer.

    PlaySound.OneShot(Player, 0, .6f); //This will play the first AudioClip in the PlaySound clip_list at the player location, at pitch 0.6 (60% playback speed).

    PlaySound.OneShot(pokerTable, dealCardClip, Random.Range(0.7f,1.3f)); //This will play the dealCardClip sound at the pokerTable position, at a random pitch for a textured effect.
    */

    // PlaySound.OneShot(thisCustomer, Footstep1_Marker 01 Copy);


    public static void OneShot(GameObject source, AudioClip? clip = null, int clip_ID = -1, float pitch = 1f)
    {
        try
        {
            if (!source.GetComponent<AudioSource>()) source.AddComponent<AudioSource>();

            try { source.GetComponent<AudioSource>().pitch = pitch; }
            catch
            {
                Debug.Log("No AudioSource at Reference.");
                return;
            }

            if (clip != null) source.GetComponent<AudioSource>().PlayOneShot(clip, 1f);
            else if (clip_ID > -1 && clip_ID < clip_list.Length) source.GetComponent<AudioSource>().PlayOneShot(clip_list[clip_ID], 1f);
            else Debug.Log("Missing AudioClip Reference.");
        }
        catch { Debug.Log("Source or Clip not found."); }
    }

    public static IEnumerator DelayedOneShot(GameObject source, AudioClip? clip = null, int clip_ID = -1, float pitch = 1f, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        OneShot(source, clip, clip_ID, pitch);
    }

    void Start()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
        clip_list = clips;
    }
}