using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierController : MonoBehaviour
{
    public static void ResetModifiers()
    {
        Modifiers.CanMoveForward = true;
        Modifiers.CanMoveBackward = true;
        Modifiers.CanMoveRight = true;
        Modifiers.CanMoveLeft = true;

        Modifiers.invertMouseY = false;
        Modifiers.invertMouseX = false;

        Modifiers.MoveSpeed = 5f;
        Modifiers.MusicPitch = 1f;
    }

    public void UpdateRandomModifier()
    {
        int target = Random.Range(0, Modifiers.modifierCount * 2);

        switch(target)
        {
            case 0:
                Modifiers.CanMoveForward = ToggleMovementDisable(Modifiers.CanMoveForward);
                break;
            case 1:
                Modifiers.CanMoveBackward = ToggleMovementDisable(Modifiers.CanMoveBackward);
                break;
            case 2:
                Modifiers.CanMoveRight = ToggleMovementDisable(Modifiers.CanMoveRight);
                break;
            case 3:
                Modifiers.CanMoveLeft = ToggleMovementDisable(Modifiers.CanMoveLeft);
                break;
            case 4:
                Modifiers.invertMouseY = !Modifiers.invertMouseY;
                UpdatePitch(Modifiers.invertMouseY);
                break;
            case 5:
                Modifiers.invertMouseX = !Modifiers.invertMouseX;
                UpdatePitch(Modifiers.invertMouseX);
                break;
            case 6:
            case 7:
            case 8:
                Modifiers.MoveSpeed = Random.Range(1f, 30f);
                break;
            default:
                break;
        }
    }

    public bool ToggleMovementDisable(bool movementModifier)
    {
        int movementDisableCount = GetNumberOfMovementDisables();

        if (!movementModifier)
        {
            UpdatePitch(false);
            return true;
        }
        else if(movementDisableCount < 2)
        {
            UpdatePitch(true);
            return false;
        }

        return true;
    }

    private int GetNumberOfMovementDisables()
    {
        int count = 0;

        if(!Modifiers.CanMoveForward)
        {
            count++;
        }

        if (!Modifiers.CanMoveBackward)
        {
            count++;
        }

        if (!Modifiers.CanMoveLeft)
        {
            count++;
        }

        if (!Modifiers.CanMoveRight)
        {
            count++;
        }

        return count;
    }

    private void UpdatePitch(bool shouldGoUp)
    {
        if(shouldGoUp)
        {
            Modifiers.MusicPitch += .1f;
        } 
        else
        {
            Modifiers.MusicPitch -= .1f;
        }
    }
}
