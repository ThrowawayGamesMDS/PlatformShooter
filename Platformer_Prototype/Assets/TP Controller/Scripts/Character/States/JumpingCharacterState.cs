using UnityEngine;
using System.Collections;

/// <summary>
/// The character is in the air, and he jumped to achieve that
/// </summary>
public class JumpingCharacterState : CharacterStateBase
{
    public override void OnEnter(Character character)
    {
        character.transform.parent = null;
       

    }
    public override void Update(Character character)
    {
     
        base.Update(character);
        character.partent = false;
        if (character.IsGrounded)
        {
            this.ToState(character, CharacterStateBase.GROUNDED_STATE);
            character.ExtraJump = character.maxJump;
        }
        if (PlayerInput.GetJumpInput())
        {
            if (character.ExtraJump != 0)
            {
                character.ExtraJump--;
                character.DoubleJump();
                
            }
        }
    }
}
