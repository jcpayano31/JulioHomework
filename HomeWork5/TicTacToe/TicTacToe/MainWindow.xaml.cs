using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToe;

namespace TicTactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Hold Result of cells in the active game
        private MarkType[] mResults;

        private bool mPlayer1Turn;

        private bool mGameEneded;

        public MainWindow()
        {
            InitializeComponent();

            NewGame();


        }

        private void NewGame()
        {
            // Create a new blak array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;


            uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.IsEnabled = true;
            });

            // Make sure Player 1 starts the game 
            mPlayer1Turn = true;

            // Interate every button on the grid..
            uxGrid.Children.Cast<Button>().ToList().ForEach(Button =>
            {
                // Change background, foreground and content to default values
                Button.Content = string.Empty;
                Button.Background = Brushes.White;
                Button.Foreground = Brushes.Blue;



            });

            // make sure the game hasn't finished
            mGameEneded = false;
        }

        // start a new game and Claers al values back to the start

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            // Create a new blak array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.IsEnabled = true;
            });

            // Make sure Player 1 starts the game 
            mPlayer1Turn = true;




            // Interate every button on the grid..
            uxGrid.Children.Cast<Button>().ToList().ForEach(Button =>
            {
                // Change background, foreground and content to default values
                Button.Content = string.Empty;
                Button.Background = Brushes.White;
                Button.Foreground = Brushes.Blue;

            });

            // make sure the game hasn't finished
            mGameEneded = false;


        }

        /// <summary>
        /// handles a button click event
        /// </summary>
        /// <param name="sender">the botton thae was clicked</param>
        /// <param name="e">the events of the click</param>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEneded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (mResults[index] != MarkType.Free)
                return;

            // set teh cell value base on whick player turn is is 
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // the same code but more compact 
            //if (mPlayer1Turn)
            //    mResults[index] = MarkType.Cross;
            //else
            //    mResults[index] = MarkType.Nought;


            // set button text to the result
            button.Content = mPlayer1Turn ? "X" : "0";

            //if (mPlayer1Turn)
            //    mPlayer1Turn = false;
            //else
            //    mPlayer1Turn = true;

            // cnage noughts to green
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red;

            //  toggle the player turns 
            mPlayer1Turn ^= true;

            // Check for a winner 
            CheckForWinner();


        }

        /// <summary>
        /// Checks if ther is a winner of a 3 line straight
        /// </summary>
        private void CheckForWinner()
        {


            // chec for horizontal  wins
            //
            //  Row 0
            //

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                // Game ends
                mGameEneded = true;




                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.IsEnabled = false;

                });

                MessageBox.Show("You are a Winner");



            }


            // chec for horizontal  wins
            //
            //  Row 1
            //

            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                // Game ends
                mGameEneded = true;


                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.IsEnabled = false;
                });

                MessageBox.Show("You are a Winner");


            }


            // chec for horizontal  wins
            //
            //  Row 2
            //

            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                // Game ends
                mGameEneded = true;



                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.IsEnabled = false;
                });


                MessageBox.Show("You are a Winner");
            }




            //-------------Vertical wins
            // chec for Vertical  wins
            //
            //  Column  0
            //

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                // Game ends
                mGameEneded = true;


                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {

                    button.IsEnabled = false;
                });

                MessageBox.Show("You are a Winner");

            }

            // chec for Vertical  wins
            //
            //  Column  1
            //

            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                // Game ends
                mGameEneded = true;


                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.IsEnabled = false;
                });

                MessageBox.Show("You are a Winner");
            }



            // chec for Vertical  wins
            //
            //  Column  2
            //

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                // Game ends
                mGameEneded = true;



                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.IsEnabled = false;
                });

                MessageBox.Show("You are a Winner");
            }




            //  Diagonal  win

            // chec for Vertical  wins
            //
            //  Diagonal   Top lef button right 
            //

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                // Game ends
                mGameEneded = true;



                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.IsEnabled = false;
                });

                MessageBox.Show("You are a Winner");
            }

            // chec for Vertical  wins
            //
            //  Diagonal   Top  Right  bottom left 
            //

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])


            {
                // Game ends
                mGameEneded = true;


                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.IsEnabled = false;
                });
                MessageBox.Show("You are a Winner");


            }




            if (!mResults.Any(result => result == MarkType.Free))
            {
                mGameEneded = true;

                // if not winner turn all cells orange
                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });


            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}

