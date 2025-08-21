using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Executioner : Boss
{
    public int minNumberOfAttacks;
    public int maxNumberOfAttacks;
    private int numberOfAttacks;
    private float xPosition;
    private bool didChooseX;
    private MovementState state;

    private void Start()
    {
        numberOfAttacks = UnityEngine.Random.Range(minNumberOfAttacks, maxNumberOfAttacks);
        didChooseX = false;
        state = MovementState.Entering;
    }

    public override void Move()
    {
        switch (state)
        {
            case MovementState.Entering:
                Debug.Log("entering!");
                if (Mathf.Abs(transform.position.y - yPosition) < 0.1f || transform.position.y > yPosition)
                {
                    transform.position += Vector3.up * DeltaY();
                    break;
                }
                else
                {
                    state = MovementState.MovingToX;
                    break;
                }

            case MovementState.MovingToX:
                if (!didChooseX)
                {
                    xPosition = GameManager.instance.Thor.transform.position.x;
                    didChooseX = true;
                    break;
                }
                else
                {
                    if (Mathf.Abs(xPosition - transform.position.x) < 0.1f)
                    {
                        didChooseX = false;
                        if (numberOfAttacks <= 0)
                        {
                            state = MovementState.Exiting;
                            break;
                        }
                        else
                        {
                            state = transform.position.y > -4f ? MovementState.ComingDown : MovementState.ComingUp;
                            break;
                        }
                    }
                    else
                    {
                        horizontalDirection = xPosition > transform.position.x ? 1 : -1;
                        transform.position += Vector3.right * DeltaX();
                        break;
                    }
                }

            case MovementState.ComingDown:
                Debug.Log("comin down");
                if (transform.position.y > -8.5f)
                {
                    transform.position += Vector3.up * DeltaY(2);
                    break;
                }
                else
                {
                    state = MovementState.MovingToX;
                    break;
                }

            case MovementState.ComingUp:
                Debug.Log("cumoin up");
                if (transform.position.y < yPosition)
                {
                    transform.position += Vector3.up * DeltaY(-2);
                    break;
                }
                else
                {
                    state = MovementState.MovingToX;
                    numberOfAttacks--;
                    break;
                }

            case MovementState.Exiting:
                Debug.Log("buee");
                transform.position += Vector3.up * DeltaY(2);
                break;
        }
    }

    public enum MovementState
    {
        Entering,
        MovingToX,
        ComingDown,
        ComingUp,
        Exiting,
    }
}