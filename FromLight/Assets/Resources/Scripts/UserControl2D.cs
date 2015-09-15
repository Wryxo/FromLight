using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (Character2D))]
public class UserControl2D : MonoBehaviour
{
	private Character2D m_Character;
	private bool m_Jump;
	private bool m_Fire;
	private PlayerScript m_Player;
	private Vector3 m_Position;
	
	private void Awake()
	{
		m_Character = GetComponent<Character2D>();
		m_Player = GetComponent<PlayerScript> ();
	}
	
	
	private void Update()
	{
		if (!m_Jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}
		if (!m_Fire) {
			// Read the fire input in Update so button presses aren't missed.
			m_Fire = CrossPlatformInputManager.GetButtonDown("Fire1");
			m_Position = CrossPlatformInputManager.mousePosition;
		}
	}
	
	
	private void FixedUpdate()
	{
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		m_Character.Move(h, m_Jump);
		m_Player.Shoot (m_Fire, m_Position);
		m_Jump = false;
		m_Fire = false;
	}
}

