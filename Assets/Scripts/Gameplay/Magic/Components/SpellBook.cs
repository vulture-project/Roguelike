using Gameplay.Magic.Spells;

using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Magic.Components
{
    public class SpellBook : MonoBehaviour
    {
        [SerializeField]
        private List<ProjectileCastSpell> _projectileCastSpells;
    }
}