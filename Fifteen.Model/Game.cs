﻿using Fifteen.BLL;
using Fifteen.BLL.Bonuses;
using Fifteen.BLL.Commands;
using Fifteen.BLL.DeskGenerators;
using Fifteen.BLL.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL
{
    public class Game
    {
        private static Game _game = new Game();
        private Stack<Command> _commands;
        private IDeskGenerator _deskGenerator;
        private readonly Random rnd;

        private Desk _desk;

        private bool isDeskGenerated = false;
        
        private Game()
        {
            _deskGenerator = new SimpleGenerator();
            rnd = new Random(DateTime.Now.Minute);
        }
        public static Game GetInstance()
        {
            return _game;
        }

        public void Move(MoveDirection direction)
        {
            if (!isDeskGenerated)
                return;
            Command command = MovementInitializers.Initializers[direction].Invoke(_desk);
            command.Execute();
            _commands.Push(command);
        }
        public void UndoLastCommand()
        {
            if(_commands.Count > 0)
            {
                var lastCommand = _commands.Pop();
                lastCommand.Undo();
            }
        }
        public bool IsInWinPosition()
        {
            return _desk.IsInWinPosition();
        }

        public void UseBonus()
        {
            switch (rnd.Next(1))
            {
                case 0:
                    var bonus = new RandomMovementsBonus(_desk, rnd.Next(50));
                    bonus.Execute();
                    _commands.Push(bonus);
                    break;
            }
        }

        public int?[,] GetDesk()
        {
            return _desk.GetDesk();
        }
        public void SetGenerator(IDeskGenerator generator)
        {
            _deskGenerator = generator;
        }
        public void GenerateDesk(int size, int iterationsCount)
        {
            if(!isDeskGenerated)
            {
                _desk = new Desk(size);
                _desk.GenerateDesk();
                _deskGenerator.MoveCells(_desk, iterationsCount);
                _commands = new Stack<Command>();
                isDeskGenerated = true;
            } 
        }
    }
}
