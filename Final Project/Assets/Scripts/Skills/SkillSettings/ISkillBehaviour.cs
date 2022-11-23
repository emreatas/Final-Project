using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Skills
{
    public interface ISkillBehaviour
    {
        void StartSkill(PlayerSkillController skillController);
        void ExecuteSkill(PlayerSkillController skillController);
    }
}
