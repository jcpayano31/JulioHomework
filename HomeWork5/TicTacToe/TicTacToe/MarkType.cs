using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// The type of value a cell in the game
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// The cel hasn't been clicked yet
        /// </summary>
        Free,
        /// <summary>
        /// the cell is a O
        /// </summary>
        Nought,
        /// <summary>
        /// the cell is an X
        /// </summary>
        Cross
    }
}
