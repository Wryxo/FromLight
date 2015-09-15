using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (Character2D))]
public class UserControl2D : MonoBehaviour
{
	private Character2D m_Character;
	private bool m_Jump;
	private bool m_Fire;
	private int m_QuickSlot;
	private PlayerScript m_Player;
	private Vector3 m_Position;
	private GameObject projektil;
	private float force;
	
	private void Awake()
	{
		m_Character = GetComponent<Character2D>();
		m_Player = GetComponent<PlayerScript> ();
	}
	
	
	private void Update()
	{
		if (CrossPlatformInputManager.GetButtonUp("Fire1")) {
			m_Fire = false;
			if (!projektil) {
				m_Position = Camera.main.ScreenToWorldPoint(CrossPlatformInputManager.mousePosition);
				projektil = m_Player.Shoot (m_Position, force/2);
			} else {
				var ps = projektil.GetComponent<ProjectileScript>();
				if (ps.getOnFire() != 0) {
					ps.resolve();
				}
			}
			force = 0;
		}
		if (!m_Jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}
		if (!m_Fire) {
			// Read the fire input in Update so button presses aren't missed.
			m_Fire = CrossPlatformInputManager.GetButtonDown("Fire1");
		}
		if (m_Fire) {
			force = Mathf.Clamp(force+Time.deltaTime, 0.7f, 2f);
		}
		if (m_QuickSlot != 0 && CrossPlatformInputManager.GetButtonDown("QuickSlot1")) {
			m_QuickSlot = 0;
		}
		if (m_QuickSlot != 1 && CrossPlatformInputManager.GetButtonDown("QuickSlot2")) {
			m_QuickSlot = 1;
		}
		if (m_QuickSlot != 2 && CrossPlatformInputManager.GetButtonDown("QuickSlot3")) {
			m_QuickSlot = 2;
		}
		if (m_QuickSlot != 3 && CrossPlatformInputManager.GetButtonDown("QuickSlot4")) {
			m_QuickSlot = 3;
		}
		if (m_QuickSlot != 4 && CrossPlatformInputManager.GetButtonDown("QuickSlot5")) {
			m_QuickSlot = 4;
		}
	}
	
	
	private void FixedUpdate()
	{
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		m_Character.Move(h, m_Jump);

		m_Player.SelectedSpell = m_QuickSlot;
		m_Jump = false;
	}
}

