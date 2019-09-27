using Assets.Scripts.Game.CombatEngine.Abstractions;
using Assets.Scripts.Game.CombatEngine.Enums;
using Assets.Scripts.Game.CombatEngine.Structs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Implementation
{
    public class HumanPlayer : MonoBehaviour, IPlayer
    {
        [SerializeField]
        private Team _team;

        [SerializeField]
        private TokenOrderType[] _tokenOrderTypes;

        [SerializeField]
        private char _splitChar;

        [SerializeField]
        private int _correctNumberOfTokensInOrder;

        private Dictionary<string, OrderType> _tokenToOrderType;

        private void Awake()
        {
            Initialize();
            DecodeAndSendOrderToTeam("Alpha Zero;move to;0,4");
        }

        private void Initialize()
        {
            _tokenToOrderType = new Dictionary<string, OrderType>();

            foreach (var item in _tokenOrderTypes)
            {
                var tn = item.TokenName.ToLower();
                if (_tokenToOrderType.ContainsKey(tn))
                {
                    continue;
                }

                _tokenToOrderType.Add(tn, item.OrderType);
            }
        }

        public void DecodeAndSendOrderToTeam(string orderText)
        {
            var tokens = orderText.Split(_splitChar);
            if (tokens.Length != _correctNumberOfTokensInOrder)
            {
                //error handling
                return;
            }

            if (!_tokenToOrderType.ContainsKey(tokens[1]))
            {
                //error handling
                return;
            }
            var targ = tokens[2].Split(',');
            var x = float.Parse(targ[0]);
            var y = float.Parse(targ[1]);

            var order = Instantiate(_team.OrderInWorldObject).GetComponent<Order>();
            order.OrderType = _tokenToOrderType[tokens[1]];
            order.Target = new Vector2(x, y);
            _team.SendOrderToUnit(order, tokens[0]);
        }
}
}
