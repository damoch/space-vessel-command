using System;
using Assets.Scripts.Game.CombatEngine.Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

namespace Assets.Scripts.Game.CombatEngine.Implementation
{
    public class HumanPlayer : MonoBehaviour, IPlayer
    {
        [SerializeField]
        private Team _team;

        [SerializeField]
        private Unit _selectedUnit;

        private void Update()
        {
            if (Input.GetMouseButton((int)MouseButton.LeftMouse))
                HandleLeftClick();
        }

        private Vector2 GetMouseToWorldCoordinates()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            return ray.GetPoint(distance);
        }

        private void HandleLeftClick()
        {
            if (_team.GameController.GameState.GamePlayState == Controllers.Enums.GamePlayState.GamePhase) return;
            var gameObject = GetClickedObject();
            if (!gameObject) return;

            var unit = gameObject.GetComponent<Unit>();
            if (unit)
            {
                SelectUnit(unit);
                return;
            }
        }

        private void SelectUnit(Unit unitComponent)
        {
            DeselectUnit();
            if (_team.UnitBelongsToTeam(unitComponent))
            {
                _selectedUnit = unitComponent;

            }
        }

        private void DeselectUnit()
        {
            _selectedUnit = null;
        }

        private GameObject GetClickedObject()
        {
            var screenToWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            var hit = Physics2D.Raycast(new Vector2(screenToWorld.x, screenToWorld.y), Vector2.zero, 0f);

            return hit.transform?.gameObject;

        }
    }
}
