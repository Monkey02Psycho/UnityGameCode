using System;

public class HealthSystem {
	/* How to use:
	 * create a new public Transform pfHealthBar, doesnt have to be pfHealthBar.
	 * 
	 * create a new Health System. the var is the total health. private HealthSystem healthSystem = new HealthSystem (100);
	 * 
	 * this is so you can move the health bar, private Transform healthBarTransform;
	 * 
	 * this is the actual health bar, private HealthBar healthBar;
	 * 
	 * the vector two is where it spawns relitive to the player, healthBarTransform = Instantiate (pfHealthBar, new Vector3 (0, 2), Quaternion.identity);
	 * use this in update to keep it relive to player healthBarTransform.position = transform.position + new Vector3(0, 0.5f);
	 * 
	 * Im not sure why you have to do this, healthBar = healthBarTransform.GetComponent<HealthBar> ();
	 * 
	 * sets up the healthbar healthBar.Setup (healthSystem);
	 * 
	 * would not recoment for players. but for enemys where you want it to appere over them.
	 */
	private int health;
	private int healthMax;
	public event EventHandler OnHealthChanged;

	public HealthSystem(int healthMax){	
		this.healthMax = healthMax;
		health = healthMax;
	}

	public int getHealth(){
		return health;
	}

	public float GetHealthPercent(){
		return (float)health / (float)healthMax;
	}

	public void Damage(int damageAmount){
		health -= damageAmount;
		if (health < 0) health = 0;
		if (OnHealthChanged != null) OnHealthChanged (this, EventArgs.Empty);
	}

	public void Heal(int healAmount) {
		health += healAmount;
		if (health > healthMax) health = healthMax;
		if (OnHealthChanged != null) OnHealthChanged (this, EventArgs.Empty);
	}

}
