﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;

using Sudoku.ViewModels.Framework;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels
{
    [Export(typeof(IGameVM))]
    public class GameVM : ViewModelBase, IGameVM
    {
        #region Fields

        private ICommand _enterNumberCommand;
        private ISelectableToolVM _selectedTool;

        #endregion Fields

        #region Constructors

        public GameVM(IGameBoardVM gameBoardVM, IEnumerable<IToolVM> tools)
        {
            GameBoard = gameBoardVM;

            Tools = new ReadOnlyCollection<IToolVM>(tools.ToList());

            foreach (var toolVM in Tools.OfType<ISelectableToolVM>())
            {
                toolVM.IsSelected += ToolIsSelected;
            }
        }

        #endregion Constructors

        #region Events

        public event EventHandler<EventArgs> GameCompleted;

        #endregion Events

        #region Public Properties

        public ICommand EnterNumberCommand
        {
            get
            {
                return _enterNumberCommand ?? (_enterNumberCommand = new RelayCommand<string>(OnNumberEntered));
            }
        }

        public IGameBoardVM GameBoard
        {
            get; private set;
        }

        public ISelectableToolVM SelectedTool
        {
            get
            {
                return _selectedTool;
            }
        }

        public ReadOnlyCollection<IToolVM> Tools
        {
            get; private set;
        }

        #endregion Public Properties

        #region Public Methods

        public void RaiseGameCompleted(EventArgs e)
        {
            var handler = GameCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void OnNumberEntered(string enteredNumber)
        {
            if (enteredNumber == null ||
                _selectedTool == null ||
                GameBoard.SelectedCell == null ||
                !(GameBoard.SelectedCell is IChangeableCellVM))
            {
                return;
            }

            int number;
            if (!int.TryParse(enteredNumber, out number))
            {
                return;
            }

            _selectedTool.EnterNumber(number);

            if (GameBoard.IsCompleted)
            {
                RaiseGameCompleted(new EventArgs());
            }
        }

        private void ToolIsSelected(object sender, EventArgs e)
        {
            _selectedTool = sender as ISelectableToolVM;
        }

        #endregion Private Methods
    }
}