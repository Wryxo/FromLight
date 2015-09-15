using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (Character2D))]
public class UserControl2D : MonoBehaviour
{
	private Character2D m_Character;
	private bool m_Jump;
	private bool m_Fire;
	
	
	private void Awake()
	{
		m_Character = GetComponent<Character2D>();
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
			m_Fire = CrossPlatformInputManager.GetButtonDown("Fire");
		}
	}
	
	
	private void FixedUpdate()
	{
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		m_Character.Move(h, m_Jump);
		m_Character.Fire (m_Fire);
		m_Jump = false;
	}
}

