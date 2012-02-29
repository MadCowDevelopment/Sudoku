using System;

namespace Sudoku.Services.DancingLinks
{
    class dlx_generator
    {
        #region Fields

        private static readonly int DefaultPuzzleSetSize = 100;
        private static readonly int SolveCycles = 100;
        private static readonly bool WANT_DEBUG_MESSAGES = false;

        int[] A = new int[88];
        char[] B = {'0',
                    '1','1','1','2','2','2','3','3','3',
                    '1','1','1','2','2','2','3','3','3',
                    '1','1','1','2','2','2','3','3','3',
                    '4','4','4','5','5','5','6','6','6',
                    '4','4','4','5','5','5','6','6','6',
                    '4','4','4','5','5','5','6','6','6',
                    '7','7','7','8','8','8','9','9','9',
                    '7','7','7','8','8','8','9','9','9',
                    '7','7','7','8','8','8','9','9','9'
                   };
        int b, s1, m0, c1, r1, l, i1, m1, a, i, j, r, c, n = 729,
            m = 324, x, y, s, fi;
        int[] C = new int[88];
        long c2, w; //seed;
        char ch;
        int[,] Col = new int[730, 5];
        int[] Cols = new int[730];
        char[][] H = new char[326][];
        int hintIndex, q7, part, nodes, solutions, min, samples, clues;
        int[] I = new int[88];
        char[] L = { '.', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        int numSolutions;
        int[] P = new int[88];
        private System.Random rnd = new System.Random();
        int[,] Row = new int[325, 10];
        int[] Rows = new int[325];
        int[] Two = new int[888];
        int[] Uc = new int[325];
        int[] Ur = new int[730];
        int[] V = new int[325];
        int[] W = new int[325];

        #endregion Fields

        #region Constructors

        public dlx_generator()
        {
            dbg("In constructor");
            for (int i = 0; i < H.Length; i++)
                H[i] = new char[7];
        }

        #endregion Constructors

        #region Enumerations

        /** State machine states */
        public enum GeneratorState : short
        {
            M0S = 10,
            M0 = 11,
            MR1 = 12,
            MR3 = 13,
            MR4 = 14,
            M2 = 15,
            M3 = 16,
            M4 = 17,
            M9 = 18,
            MR = 19,
            END = 20,
            M6 = 21
        }

        #endregion Enumerations

        #region Public Methods

        /// <summary>
        /// generate a set of Sudoku puzzles, starting with a given seed 
        /// for the random-number generator.
        /// </summary>
        /// <param name="Seed">RNG Seed</param>
        /// <param name="Samples">how many puzzles to generate</param>
        /// <returns>puzzles, in string form. </returns>
        public String[] GeneratePuzzleSet(int Seed, int Samples)
        {
            dbg("Entering generate");

            InitializeRandomNumberGenerator(Seed);

            // samples = number of puzzles to generate
            samples = 1000;
            if (Samples <= 0) Samples = DefaultPuzzleSetSize;
            samples = Samples;

            String[] result = new String[Samples];
            for (i = 0; i < samples; i++)
                result[i] = "";

            initialize();

            dbg("Entering state machine");

            int currentSample = -1;

            GeneratorState engineState = GeneratorState.M0S;
            while (engineState != GeneratorState.END)
            {
                switch (engineState)
                {
                    case GeneratorState.M0S:
                        currentSample++;
                        if (currentSample >= samples)
                        {
                            engineState = GeneratorState.END;
                        }
                        else
                            engineState = GeneratorState.M0;
                        break;

                    case GeneratorState.M0:
                        for (i = 1; i <= 81; i++) A[i] = 0;
                        part = 0;
                        q7 = 0;
                        engineState = GeneratorState.MR1;
                        break;

                    case GeneratorState.MR1:
                        i1 = (int)((MWC() >> 8) & 127);
                        if (i1 > 80)
                        {
                            engineState = GeneratorState.MR1;
                            break;
                        }

                        i1++;
                        if (A[i1] > 0)
                        {
                            engineState = GeneratorState.MR1;
                            break;
                        }
                        engineState = GeneratorState.MR3;
                        break;

                    case GeneratorState.MR3:
                        s = (int)((MWC() >> 9) & 15);
                        if (s > 8)
                        {
                            engineState = GeneratorState.MR3;
                            break;
                        }

                        s++;
                        A[i1] = s;
                        numSolutions = solve();
                        q7++;

                        if (numSolutions < 1)
                            A[i1] = 0;

                        if (numSolutions != 1)
                        {
                            engineState = GeneratorState.MR1;
                            break;
                        }

                        part++;
                        if (solve() != 1)
                        {
                            engineState = GeneratorState.M0;
                            break;
                        }
                        engineState = GeneratorState.MR4;
                        break;

                    case GeneratorState.MR4:
                        for (i = 1; i <= 81; i++)
                        {
                            x = (int)((MWC() >> 8) & 127);
                            while (x >= i)
                            {
                                x = (int)((MWC() >> 8) & 127);
                            }
                            x++;
                            P[i] = P[x];
                            P[x] = i;
                        }

                        for (i1 = 1; i1 <= 81; i1++)
                        {
                            s1 = A[P[i1]];
                            A[P[i1]] = 0;
                            if (solve() > 1) A[P[i1]] = s1;
                        }

                        for (i = 1; i <= 81; i++)
                        {
                            result[currentSample] += L[A[i]];
                            if (i % 9 == 0)
                            {
                                result[currentSample] += "\n";
                            }
                        }
                        result[currentSample] += "\n";

                        engineState = GeneratorState.M0S;
                        break;

                    default:
                        dbg("Default case. New state M0S");
                        engineState = GeneratorState.M0S;
                        break;
                } // end of switch statement
            } // end of while loop
            return result;
        }

        /// <summary>
        /// Solve the puzzle many times, generating an "average" rating
        /// of all those solutions.  
        /// </summary>
        /// <param name="puzzle">string representation of the puzzle.  No newline chars, please.</param>
        /// <returns>rating, an integer, between 5600 and 12000</returns>
        public long Rate(String puzzle)
        {
            GeneratorState engineState = GeneratorState.M6;

            fi = 0;
            int rateFlag = 1;
            int puzzleRating = 0;

            for (i = 0; i < 88; i++)
                A[i] = 0;

            initialize();

            while (engineState != GeneratorState.END)
            {
                switch (engineState)
                {
                    case GeneratorState.M6:
                        clues = 0;
                        for (i = 1; i <= 81; i++)
                        {
                            ch = (char)puzzle[i - 1];
                            j = 0;

                            if (ch == '-' || ch == '.' || ch == '0' || ch == '*')
                            {
                                A[i] = j;
                            }
                            else
                            {
                                while ((j <= 9) && (L[j] != ch))
                                    j++;

                                if (j <= 9)
                                {
                                    A[i] = j;
                                }
                            }
                        }

                        if (clues == 81)
                        {
                            clues--;
                            A[1] = 0;
                        }

                        puzzleRating = RatePuzzle();

                        if (puzzleRating < 0)
                        {
                            engineState = GeneratorState.END;
                            break;
                        }

                        if (fi > 0) if ((puzzleRating / SolveCycles) > fi)
                        {
                            for (i = 1; i <= 81; i++)
                                Console.WriteLine(L[A[i]]);
                            Console.WriteLine();
                            engineState = GeneratorState.M6;
                            break;
                        }

                        if (fi > 0)
                        {
                            engineState = GeneratorState.M6;
                            break;
                        }

                        if ((SolveCycles & 1) > 0)
                        {  //????
                            Console.WriteLine(puzzleRating / SolveCycles);
                            engineState = GeneratorState.M6;
                            break;
                        }

                        if (rateFlag > 1)
                            Console.WriteLine("hint: " + new String(H[hintIndex]));

                        engineState = GeneratorState.END;
                        break;
                } // End of switch statement
            } // End of while loop
            return (puzzleRating);
        }

        #endregion Public Methods

        #region Private Methods

        /** Output trace messages */
        void dbg(String s)
        {
            if (WANT_DEBUG_MESSAGES)
                Console.WriteLine(s);
        }

        /**
         * Initialization code for both generate() and rate()
         */
        void initialize()
        {
            for (i = 0; i < 888; i++)
            {
                j = 1;
                while (j <= i)
                    j += j;
                Two[i] = j - 1;
            }

            r = 0;
            for (x = 1; x <= 9; x++) for (y = 1; y <= 9; y++) for (s = 1; s <= 9; s++)
            {
                r++;
                Cols[r] = 4;
                Col[r, 1] = x * 9 - 9 + y;
                Col[r, 2] = (B[x * 9 - 9 + y] - 48) * 9 - 9 + s + 81;
                Col[r, 3] = x * 9 - 9 + s + 81 * 2;
                Col[r, 4] = y * 9 - 9 + s + 81 * 3;
            }

            for (c = 1; c <= m; c++) Rows[c] = 0;

            for (r = 1; r <= n; r++) for (c = 1; c <= Cols[r]; c++)
            {
                a = Col[r, c];
                Rows[a]++;
                Row[a, Rows[a]] = r;
            }

            c = 0;
            for (x = 1; x <= 9; x++) for (y = 1; y <= 9; y++)
            {
                c++;
                H[c][0] = 'r';
                H[c][1] = L[x];
                H[c][2] = 'c';
                H[c][3] = L[y];
                H[c][4] = (char)0;
            }

            c = 81;
            for (b = 1; b <= 9; b++) for (s = 1; s <= 9; s++)
            {
                c++;
                H[c][0] = 'b';
                H[c][1] = L[b];
                H[c][2] = 's';
                H[c][3] = L[s];
                H[c][4] = (char)0;
            }

            c = 81 * 2;
            for (x = 1; x <= 9; x++) for (s = 1; s <= 9; s++)
            {
                c++;
                H[c][0] = 'r';
                H[c][1] = L[x];
                H[c][2] = 's';
                H[c][3] = L[s];
                H[c][4] = (char)0;
            }

            c = 81 * 3;
            for (y = 1; y <= 9; y++) for (s = 1; s <= 9; s++)
            {
                c++;
                H[c][0] = 'c';
                H[c][1] = L[y];
                H[c][2] = 's';
                H[c][3] = L[s];
                H[c][4] = (char)0;
            }
        }

        // long zr = 362436069, wr = 521288629;
        //   long MWC() {
        //     return ((zr = 36969 *(zr & 65535) + (zr >> 16)) ^ ( wr = 18000 * (wr & 65535) + (wr >> 16)));
        //   }
        private void InitializeRandomNumberGenerator(int seed)
        {
            rnd = new System.Random(seed);
        }

        private long MWC()
        {
            int i = rnd.Next();
            if (i < 0) return -1 * i;
            return i;
        }

        /// <summary>
        /// Rates the puzzle specified in A[]
        /// This routine solves the puzzle N times (specified by SolveCycles),
        /// tallying the number of nodes in each solution trial.  
        /// Side-effect: sets the hintIndex 
        /// </summary>
        /// 
        /// <returns>
        /// puzzle rating 
        /// (5600 <= r <= 9999999) if puzzle is valid
        /// r < 0 if puzzle is invalid (eg., multiple solutions or other problem).
        /// </returns>
        private int RatePuzzle()
        {
            int nodeTotal = 0;
            int minNodes = 999999;
            hintIndex = 0;
            for (int i = 0; i < SolveCycles && nodeTotal >= 0; i++)
            {
                int numSolutionsFound = solve();
                if (numSolutionsFound != 1)
                {
                    if (numSolutionsFound > 1)
                        nodeTotal = -1 * numSolutionsFound;
                }
                else
                {
                    nodeTotal += nodes;
                    if (nodes < minNodes)
                    {
                        minNodes = nodes;
                        hintIndex = C[clues];
                    }
                }
            }
            return nodeTotal;
        }

        private int solve()
        {
            //returns 0 (no solution), 1 (unique sol.), 2 (more than one sol.)

            GeneratorState engineState = GeneratorState.M2;
            int i = 0, j = 0, k = 0, d, r, c;
            for (i = 0; i <= n; i++) Ur[i] = 0;
            for (i = 0; i <= m; i++) Uc[i] = 0;
            clues = 0;

            for (i = 1; i <= 81; i++)
                if (A[i] > 0)
                {
                    clues++;
                    r = i * 9 - 9 + A[i];

                    for (j = 1; j <= Cols[r]; j++)
                    {
                        d = Col[r, j];
                        if (Uc[d] > 0) return 0;
                        Uc[d]++;

                        for (k = 1; k <= Rows[d]; k++)
                        {
                            Ur[Row[d, k]]++;
                        }
                    }
                }

            for (c = 1; c <= m; c++)
            {
                V[c] = 0;
                for (r = 1; r <= Rows[c]; r++) if (Ur[Row[c, r]] == 0)
                    V[c]++;
            }

            i = clues;
            m0 = 0;
            m1 = 0;
            solutions = 0;
            nodes = 0;

            dbg("Solve: Entering state machine");

            while (engineState != GeneratorState.END)
            {
                switch (engineState)
                {
                    case GeneratorState.M2:
                        i++;
                        I[i] = 0;
                        min = n + 1;
                        if ((i > 81) || (m0 > 0))
                        {
                            engineState = GeneratorState.M4;
                            break;
                        }

                        if (m1 > 0)
                        {
                            C[i] = m1;
                            engineState = GeneratorState.M3;
                            break;
                        }

                        w = 0;
                        for (c = 1; c <= m; c++) if (Uc[c] == 0)
                        {
                            if (V[c] < 2)
                            {
                                C[i] = c;
                                engineState = GeneratorState.M3;
                                break;
                            }

                            if (V[c] <= min)
                            {
                                w++;
                                W[(int)w] = c;
                            }
                            ;

                            if (V[c] < min)
                            {
                                w = 1;
                                W[(int)w] = c;
                                min = V[c];
                            }
                        }

                        if (engineState == GeneratorState.M3)
                        {
                            // break in for loop detected, continue breaking
                            break;
                        }
                        engineState = GeneratorState.MR;
                        break;

                    case GeneratorState.MR:
                        c2 = (MWC() & Two[(int)w]);
                        while (c2 >= w)
                        {
                            c2 = (MWC() & Two[(int)w]);
                        }
                        C[i] = W[(int)c2 + 1];
                        engineState = GeneratorState.M3;
                        break;

                    case GeneratorState.M3:
                        c = C[i];
                        I[i]++;
                        if (I[i] > Rows[c])
                        {
                            engineState = GeneratorState.M4;
                            break;
                        }

                        r = Row[c, I[i]];
                        if (Ur[r] > 0)
                        {
                            engineState = GeneratorState.M3;
                            break;
                        }
                        m0 = 0;
                        m1 = 0;
                        nodes++;
                        for (j = 1; j <= Cols[r]; j++)
                        {
                            c1 = Col[r, j];
                            Uc[c1]++;
                        }

                        for (j = 1; j <= Cols[r]; j++)
                        {
                            c1 = Col[r, j];
                            for (k = 1; k <= Rows[c1]; k++)
                            {
                                r1 = Row[c1, k];
                                Ur[r1]++;
                                if (Ur[r1] == 1) for (l = 1; l <= Cols[r1]; l++)
                                {
                                    c2 = Col[r1, l];
                                    V[(int)c2]--;
                                    if (Uc[(int)c2] + V[(int)c2] < 1)
                                        m0 = (int)c2;
                                    if (Uc[(int)c2] == 0 && V[(int)c2] < 2)
                                        m1 = (int)c2;
                                }
                            }
                        }

                        if (i == 81)
                            solutions++;

                        if (solutions > 1)
                        {
                            engineState = GeneratorState.M9;
                            break;
                        }
                        engineState = GeneratorState.M2;
                        break;

                    case GeneratorState.M4:
                        i--;
                        if (i == clues)
                        {
                            engineState = GeneratorState.M9;
                            break;
                        }
                        c = C[i];
                        r = Row[c, I[i]];

                        for (j = 1; j <= Cols[r]; j++)
                        {
                            c1 = Col[r, j];
                            Uc[c1]--;
                            for (k = 1; k <= Rows[c1]; k++)
                            {
                                r1 = Row[c1, k];
                                Ur[r1]--;
                                if (Ur[r1] == 0) for (l = 1; l <= Cols[r1]; l++)
                                {
                                    c2 = Col[r1, l];
                                    V[(int)c2]++;
                                }
                            }
                        }

                        if (i > clues)
                        {
                            engineState = GeneratorState.M3;
                            break;
                        }
                        engineState = GeneratorState.M9;
                        break;

                    case GeneratorState.M9:
                        engineState = GeneratorState.END;
                        break;
                    default:
                        engineState = GeneratorState.END;
                        break;
                } // end of switch statement
            } // end of while statement
            return solutions;
        }

        #endregion Private Methods
    }
}