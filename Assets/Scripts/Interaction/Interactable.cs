using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[Header("Interaction Data")]
	public string interactableName="";
	public float interactionDistance = 2;
	[SerializeField] bool isInteractable = true;

	InteractableNameText interactableNameText;
	GameObject interactableNameCanvas;

	public virtual void Start()
	{
		interactableNameCanvas = GameObject.FindGameObjectWithTag("Canvas");
		interactableNameText = interactableNameCanvas.GetComponentInChildren<InteractableNameText>();
	}

	public void TargetOn()
	{
        interactableNameText.ShowText(this);
        interactableNameText.SetInteractableNamePosition(this);
		//Debug.Log("ShowText ");
	}

	public void TargetOff()
	{
        interactableNameText.HideText();
		//Debug.Log("HideText ");

	}

	public void Interact()
	{
		if (isInteractable) Interaction();
	}

	protected virtual void Interaction()
	{
		Debug.Log("interact with: " + this.name);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position,interactionDistance);
	}
	private void OnDestroy()
	{
		TargetOff();
    }
}
