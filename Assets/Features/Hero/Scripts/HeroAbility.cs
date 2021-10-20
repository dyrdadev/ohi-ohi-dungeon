using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Sensor))]
[RequireComponent(typeof(Collider2D))]
public class HeroAbility : MonoBehaviour
{
	private Collider2D col;
	private Sensor activationCause;

	[SerializeField] private float duration = 0.5f;
	[SerializeField] private float strength = 1f;
	[SerializeField] AnimationCurve speedChangeCurve;

	[Space(5)]
	[SerializeField] private float cooldownDuration = 4;


	[Space(5)]
	[SerializeField] private GameObject abilityVFX;

	private void Start()
	{
		col = GetComponent<Collider2D>();
		activationCause = GetComponent<Sensor>();
		activationCause.SensorTriggered.Subscribe(ActivateAbility).AddTo(this);

		StartCoroutine(StartCooldown());
	}

	public void ActivateAbility(EventArgs args)
	{
		if (GameData.Instance.abilityAvailable.Value == true)
		{
			EnemyMovement[] allEnemies = Array.ConvertAll(GameObject.FindGameObjectsWithTag("Enemy"), (go) => go.GetComponent<EnemyMovement>());
			if (allEnemies.Length != 0)
				StartCoroutine(PushBackEnemies(allEnemies));

			abilityVFX.SetActive(true);
			StartCoroutine(StartCooldown());
		}
	}

	private IEnumerator PushBackEnemies(EnemyMovement[] enemies)
	{
		float timer = 0;

		float originalSpeed = enemies[0].speed;

		while (timer < duration)
		{
			for (int i = 0; i < enemies.Length; i++)
				enemies[i].speed = originalSpeed - (speedChangeCurve.Evaluate(timer / duration) * originalSpeed * strength * 2);

			yield return new WaitForSecondsRealtime(Time.deltaTime);
			timer += Time.deltaTime;
		}

		for (int i = 0; i < enemies.Length; i++)
			enemies[i].speed = originalSpeed;
	}

	private IEnumerator StartCooldown()
	{
		GameData.Instance.SetAbilityAvailable(false);
		col.enabled = false;
		yield return new WaitForSeconds(cooldownDuration);
		GameData.Instance.SetAbilityAvailable(true);
		col.enabled = true;
	}
}
