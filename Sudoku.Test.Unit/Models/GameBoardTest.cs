﻿using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Models;
using Sudoku.Services;

namespace Sudoku.Test.Unit.Models
{
    [TestClass]
    public class GameBoardTest
    {
        #region Fields

        private IGameBoard _gameBoard;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorShouldThrowExceptionWhenArgumentIsNull()
        {
            _gameBoard = new GameBoard(null, Difficulty.Easy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorShouldThrowExceptionWhenArrayIsLessThan81Elements()
        {
            _gameBoard = new GameBoard(new int[80], Difficulty.Easy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorShouldThrowExceptionWhenArrayIsMoreThan81Elements()
        {
            _gameBoard = new GameBoard(new int[82], Difficulty.Easy);
        }

        [TestMethod]
        public void GameBoardConsistsOf81Fields()
        {
            Assert.AreEqual(81, _gameBoard.Fields.Length);
        }

        [TestMethod]
        public void GameBoardWithAtLeastOneZeroIsNotCompleted()
        {
            _gameBoard.Fields[0] = 0;

            Assert.IsFalse(_gameBoard.IsCompleted());
        }

        [TestMethod]
        public void GetBoxWithIndex0ReturnsFirstBox()
        {
            var box = _gameBoard.GetBox(0).ToList();

            Assert.AreEqual(_gameBoard.Fields[0], box[0]);
            Assert.AreEqual(_gameBoard.Fields[1], box[1]);
            Assert.AreEqual(_gameBoard.Fields[2], box[2]);
            Assert.AreEqual(_gameBoard.Fields[9], box[3]);
            Assert.AreEqual(_gameBoard.Fields[10], box[4]);
            Assert.AreEqual(_gameBoard.Fields[11], box[5]);
            Assert.AreEqual(_gameBoard.Fields[18], box[6]);
            Assert.AreEqual(_gameBoard.Fields[19], box[7]);
            Assert.AreEqual(_gameBoard.Fields[20], box[8]);
        }

        [TestMethod]
        public void GetBoxWithIndex1ReturnsSecondBox()
        {
            var box = _gameBoard.GetBox(1).ToList();

            Assert.AreEqual(_gameBoard.Fields[3], box[0]);
            Assert.AreEqual(_gameBoard.Fields[4], box[1]);
            Assert.AreEqual(_gameBoard.Fields[5], box[2]);
            Assert.AreEqual(_gameBoard.Fields[12], box[3]);
            Assert.AreEqual(_gameBoard.Fields[13], box[4]);
            Assert.AreEqual(_gameBoard.Fields[14], box[5]);
            Assert.AreEqual(_gameBoard.Fields[21], box[6]);
            Assert.AreEqual(_gameBoard.Fields[22], box[7]);
            Assert.AreEqual(_gameBoard.Fields[23], box[8]);
        }

        [TestMethod]
        public void GetBoxWithIndex8ReturnsSecondBox()
        {
            var box = _gameBoard.GetBox(8).ToList();

            Assert.AreEqual(_gameBoard.Fields[60], box[0]);
            Assert.AreEqual(_gameBoard.Fields[61], box[1]);
            Assert.AreEqual(_gameBoard.Fields[62], box[2]);
            Assert.AreEqual(_gameBoard.Fields[69], box[3]);
            Assert.AreEqual(_gameBoard.Fields[70], box[4]);
            Assert.AreEqual(_gameBoard.Fields[71], box[5]);
            Assert.AreEqual(_gameBoard.Fields[78], box[6]);
            Assert.AreEqual(_gameBoard.Fields[79], box[7]);
            Assert.AreEqual(_gameBoard.Fields[80], box[8]);
        }

        [TestMethod]
        public void GetColumnWithIndex0ReturnsFirstColumn()
        {
            var column = _gameBoard.GetColumn(0).ToList();

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(_gameBoard.Fields[i * 9], column[i]);
            }
        }

        [TestMethod]
        public void GetColumnWithIndex1ReturnsSecondColumn()
        {
            var column = _gameBoard.GetColumn(1).ToList();

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(_gameBoard.Fields[(i * 9) + 1], column[i]);
            }
        }

        [TestMethod]
        public void GetRowWithIndex0ReturnsFirstRow()
        {
            var row = _gameBoard.GetRow(0).ToList();

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(_gameBoard.Fields[i], row[i]);
            }
        }

        [TestMethod]
        public void GetRowWithIndex1ReturnsSecondRow()
        {
            var row = _gameBoard.GetRow(1).ToList();

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(_gameBoard.Fields[i + 9], row[i]);
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            _gameBoard = new PuzzleGenerator().GeneratePuzzle(Difficulty.Easy);
        }

        #endregion Public Methods
    }
}