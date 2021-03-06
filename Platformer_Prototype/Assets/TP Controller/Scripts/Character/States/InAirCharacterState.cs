﻿using UnityEngine;
using System.Collections;

/// <summary>
/// The character is in the air, but he didn't jump to achieve that
/// </summary>
public class InAirCharacterState : CharacterStateBase
{
    public override void OnEnter(Character character)
    {
        character.transform.parent = null;
        base.OnEnter(character);
        character.ResetVerticalSpeed();
    }

    public override void Update(Character character)
    {
        base.Update(character);

        if (character.IsGrounded)
        {
            this.ToState(character, CharacterStateBase.GROUNDED_STATE);
        }
        if (PlayerInput.GetJumpInput())
        {
            this.ToState(character, CharacterStateBase.JUMPING_STATE);

        }
    }
}
