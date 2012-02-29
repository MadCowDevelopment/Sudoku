using System;

namespace Sudoku.Services.DancingLinks
{
    /****************************************************************************
    * dlx_solver solve any Sudoku in a fraction of a second. Input is
    * a string of dots and digits representing the puzzle to solve and
    * output is the solved puzzle.
    *
    * @author Rolf Sandberg
    ****************************************************************************/
    // A sample of the string representation:
    //     ..3.69.5.
    //     9.1.2...3
    //     .........
    //     .7.9..4..
    //     2....3...
    //     3.6....8.
    //     8..6921..
    //     .6.7...4.
    //     ....5....
    //
    // There are (3x3+1)x3x3  characters = 90 chars in the string, plus a trailing newline.
    // Each "row" in the printed string is 9 chars followed by \n.
    // And then there is a \n at the end.
    /******************************************************************************
     * dlx_generator generate single solution locally minimized Sudoku puzzles.
     * Locally minimized means that all keys that can be removed without creating
     * a degenerate Sudoku (multiple solutions) are removed.
     ******************************************************************************/
    /**
     *
     * @author Rolf Sandberg
     */
    public class DancingLinksEngine
    {
        #region Fields

        private static readonly int MaxGenerateLoops = 99;
        private static readonly int SampleSetSize = 5;

        private RatingLimits[] RatingsByLevel = new RatingLimits[]  
        {
          new RatingLimits(){min=5600,max=5800},
          new RatingLimits(){min=5800,max=6100},
          new RatingLimits(){min=6100,max=6400},
          new RatingLimits(){min=6400,max=6800},
          new RatingLimits(){min=6800,max=7000},
          new RatingLimits(){min=7000,max=7500},
          new RatingLimits(){min=7500,max=8000},
          new RatingLimits(){min=8000,max=9000},
          new RatingLimits(){min=9000,max=10000},
          new RatingLimits(){min=10000,max=12000},
          new RatingLimits(){min=12000,max=999999},
        };
        dlx_generator _generator;

        #endregion Fields

        #region Constructors

        public DancingLinksEngine()
        {
            _generator = new dlx_generator();
        }

        #endregion Constructors

        #region Public Methods

        public SudokuPuzzle GenerateOne(int ratingLevel)
        {
            return internalGenerate(ratingLevel, 0);
        }

        public SudokuPuzzle GenerateOne(int ratingLevel, long seed)
        {
            return internalGenerate(ratingLevel, seed);
        }

        #endregion Public Methods

        #region Private Methods

        private SudokuPuzzle internalGenerate(int desiredRatingLevel, long initialSeed)
        {
            // validate the passed-in desired rating level:
            if ((desiredRatingLevel < 0) && (desiredRatingLevel >= RatingsByLevel.Length))
                desiredRatingLevel = 0;

            RatingLimits RL = RatingsByLevel[desiredRatingLevel];

            SudokuPuzzle p = new SudokuPuzzle();
            p.DesiredRatingLevel = desiredRatingLevel;
            p.Seed = initialSeed;
            p.NumHints = 0;

            // Find a Sudoku having a rating within a specified rating interval.
            // Do it by generating multiple samples and examining them.
            // Continue until an appropriate puzzle is found.

            // Sometimes we need to iterate over multiple sets of puzzles.
            // Iteration doesn't make sense though, if there is an initialSeed
            // provided. So we set the loopLimit appropriately.
            int loopLimit = (initialSeed == 0) ? MaxGenerateLoops : 1;

            for (int tries = 0; tries < loopLimit; tries++, System.Threading.Thread.Sleep(20))
            {
                long actualSeed = (initialSeed == 0) ? System.DateTime.Now.Ticks : initialSeed;

                string[] puzzles = _generator.GeneratePuzzleSet((int)actualSeed, SampleSetSize);
                for (var i = 0; i < SampleSetSize; i++)
                {
                    // get the rating
                    long rating = _generator.Rate(puzzles[i].Replace("\n", string.Empty).Trim());

                    if ((i == 0) || RL.Delta(rating) < p.Delta)
                    {
                        p.ActualRating = rating;
                        p.StringRep = puzzles[i];
                        p.Seed = actualSeed;
                        p.Delta = RL.Delta(rating);
                    }
                }

                if (RL.WithinRange(p.ActualRating))
                {
                    return p;
                }
            }

            return p;
        }

        #endregion Private Methods

        #region Nested Types

        class RatingLimits
        {
            #region Fields

            public int max;
            public int min;

            int _centrum = 0;

            #endregion Fields

            #region Private Properties

            int Centrum
            {
                get
                {
                    if (_centrum == 0)
                    {
                        _centrum = (max - min) / 2 + min;
                    }

                    return _centrum;
                }
            }

            #endregion Private Properties

            #region Public Methods

            public int Delta(long rating)
            {
                int intRating = (int)rating;
                return Math.Abs(intRating - Centrum);
            }

            public bool WithinRange(long rating)
            {
                return ((rating >= min) && (rating <= max));
            }

            #endregion Public Methods
        }

        #endregion Nested Types
    }
}