﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels
{
    public class GameVM : ViewModelBase, IGameVM
    {
        private ICommand _enterNumberCommand;

        private ISelectableToolVM _selectedTool;

        public GameVM(IGameBoardVM gameBoardVM, IEnumerable<IToolVM> tools)
        {
            GameBoard = gameBoardVM;

            Tools = new ReadOnlyCollection<IToolVM>(tools.ToList());

            foreach (var toolVM in Tools.OfType<ISelectableToolVM>())
            {
                toolVM.IsSelected += ToolIsSelected;
            }
        }

        public ICommand EnterNumberCommand
        {
            get
            {
                return _enterNumberCommand ?? (_enterNumberCommand = new RelayCommand(OnNumberEntered));
            }
        }

        private void ToolIsSelected(object sender, System.EventArgs e)
        {
            _selectedTool = sender as ISelectableToolVM;
        }

        public ReadOnlyCollection<IToolVM> Tools { get; private set; }

        public IGameBoardVM GameBoard { get; private set; }

        public ISelectableToolVM SelectedTool
        {
            get
            {
                return _selectedTool;
            }
        }

        private void OnNumberEntered(object obj)
        {
            if (obj == null || _selectedTool == null || GameBoard.SelectedCell == null)
            {
                return;
            }

            int number;
            if (!int.TryParse(obj.ToString(), out number))
            {
                return;
            }

            _selectedTool.EnterNumber(GameBoard.SelectedCell, number);
        }
    }
}