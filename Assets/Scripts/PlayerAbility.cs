using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public string abilityID;
    public bool onCooldown;
    public float cooldownLength;
    public float currentCooldownTime;
    public AudioClip abilitySound;
    public float abilityVolume;
    public PlayerController thisPlayer;
    public KeyCode inputKey;

    public virtual void ActivateAbility()
    {
        if (!onCooldown)
        {
            onCooldown = true;
            currentCooldownTime = cooldownLength;
            AbilityEffects();
            if (abilitySound)
            {
                thisPlayer.stats.audioSource.PlayOneShot(abilitySound, abilityVolume);   
            }
        }
    }

    protected virtual void AbilityEffects()
    {
        
    }
    void Update()
    {
        if (onCooldown)
        {
            currentCooldownTime -= Time.deltaTime;
            if (currentCooldownTime <= 0)
            {
                onCooldown = false;
            }
        }
    }
}