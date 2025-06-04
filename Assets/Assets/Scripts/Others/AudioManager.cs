using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    [Header("------- Player ------")]
    public AudioClip PlayerAttackSFX;
    public AudioClip PlayerAttackFireSFX;
    public AudioClip PlayerDeathSFX;
    public AudioClip PlayerHitSFX;
    public AudioClip PlayerJumpSFX;
    [Header("------- Diamonds -------")]
    public AudioClip DiamondCollectSFX;
    [Header("------- Skeleton -------")]
    public AudioClip SkeletonHitSFX;
    public AudioClip SkeletonAttackSFX;
    public AudioClip SkeletonDeathSFX;
    public AudioClip SkeletonBoneScatterSFX;
    [Header("------- Moss Giant -------")]
    public AudioClip GiantHitSFX;
    public AudioClip GiantAttackSFX;
    public AudioClip GiantDeathSFX;
    [Header("------- Spider -------")]
    public AudioClip SpiderFlareUpSFX;
    public AudioClip SpiderDeathSFX;
    [Header("------- Shop -------")]
    public AudioClip ShopSelectionSFX;
    [Header("------- Others -------")]
    public AudioClip ItemCollectionSFX;

    public void PlaySFX(AudioClip clip) {
    	source.PlayOneShot(clip);
    }
}
