﻿using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.Test.Unit.ViewModels.Tools
{
    [TestClass]
    public class PencilAllToolVMTest
    {
        #region Fields

        private Mock<IChangeableCellVM> _changeableCellVMMock;
        private Mock<IGameBoardVM> _gameBoardVMMock;
        private IPencilAllToolVM _pencilAllToolVM;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void ImageIsSetCorrectly()
        {
            Assert.AreEqual(@"..\Images\PencilAll.png", _pencilAllToolVM.Image);
        }

        [TestInitialize]
        public void Initialize()
        {
            _changeableCellVMMock = new Mock<IChangeableCellVM>();
            _changeableCellVMMock.Setup(p => p.Number).Returns(1);

            _gameBoardVMMock = new Mock<IGameBoardVM>();
            _gameBoardVMMock.SetupGet(p => p.Cells).Returns(new List<ICellVM>());
            _gameBoardVMMock.Object.Cells.Add(_changeableCellVMMock.Object);
            _gameBoardVMMock.Setup(p => p.GetAllChangeableCellsThatDontHaveANumberSet()).Returns(
                new List<IChangeableCellVM> { _changeableCellVMMock.Object });

            _pencilAllToolVM = new PencilAllToolVM(_gameBoardVMMock.Object);
        }

        [TestMethod]
        public void TheToolCanAlwaysBeExecuted()
        {
            var canExecute = _pencilAllToolVM.ExecuteCommand.CanExecute(null);

            Assert.IsTrue(canExecute);
        }

        [TestMethod]
        public void WhenCommandIsExecutedAllPencilMarksAreEnabledAndThenSelectivelyDisabled()
        {
            _pencilAllToolVM.ExecuteCommand.Execute(null);

            _changeableCellVMMock.Verify(p => p.EnableAllPencilMarks(), Times.Once());
            _changeableCellVMMock.Verify(p => p.DisablePencilMarks(It.IsAny<IEnumerable<int>>()), Times.Exactly(3));
        }

        #endregion Public Methods
    }
}