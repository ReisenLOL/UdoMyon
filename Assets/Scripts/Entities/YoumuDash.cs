using UnityEngine;

public class YoumuDash : PlayerAbility
{
    public float speedIncrease;
    public float dashLength;
    public float currentTime;
    protected override void Update()
    {
        base.Update();
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                thisPlayer.stats.speed -= speedIncrease;
            }
        }
    }

    protected override void AbilityEffects()
    {
        thisPlayer.stats.speed += speedIncrease;
        currentTime += dashLength;
    }
}
