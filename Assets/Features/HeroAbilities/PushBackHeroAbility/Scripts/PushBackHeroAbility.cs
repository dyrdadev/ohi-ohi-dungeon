using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Sensor))]
[RequireComponent(typeof(Collider2D))]
public class PushBackHeroAbility : MonoBehaviour
{
	private Collider2D _collider;
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
		_collider = GetComponent<Collider2D>();
		activationCause = GetComponent<Sensor>();
		activationCause.SensorTriggered.Subscribe(ActivateAbility).AddTo(this);

		StartCoroutine(StartCooldown());
	}

	public void ActivateAbility(EventArgs args)
	{
		if (GameData.Instance.abilityAvailable.Value == true)
		{
			// To the future people: Implement a nicer way to access the enemies here.
			EnemyMovement[] allEnemies = Array.ConvertAll(GameObject.FindGameObjectsWithTag("Enemy"), (go) => go.GetComponent<EnemyMovement>());
			for (int i = 0; i < allEnemies.Length; i++)
			{
				allEnemies[i].PushBack(duration, strength, speedChangeCurve);
			}

			abilityVFX.SetActive(true);
			StartCoroutine(StartCooldown());
		}
	}

	private IEnumerator StartCooldown()
	{
		GameData.Instance.SetAbilityAvailable(false);
		_collider.enabled = false;
		yield return new WaitForSeconds(cooldownDuration);
		GameData.Instance.SetAbilityAvailable(true);
		_collider.enabled = true;
	}
}
