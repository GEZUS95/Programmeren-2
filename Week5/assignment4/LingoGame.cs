using System.Collections.Generic;

namespace assignment4
{
    class LingoGame
    {
        

        public string lingoWord;
        public string playerWord;

        public void Init(string word)
        {
            lingoWord = word;
            playerWord = "";
        }

        public bool WordGuessed()
        {
            return (lingoWord == playerWord);
        }

        public LetterState[] ProcessWord(string playerword)
        {
            this.playerWord = playerword;
            LetterState[] letterResults = new LetterState[lingoWord.Length];

            List<char> refLetters = new List<char>();
            for (int i = 0; i < lingoWord.Length; i++)
            {
                if (lingoWord[i] != playerWord[i])
                {
                    refLetters.Add(lingoWord[i]);
                }
            }

            for (int i = 0; i < playerword.Length; i++)
            {
                if (lingoWord[i] == char.ToUpper(playerWord[i]))
                {
                    letterResults[i] = LetterState.Correct;
                }
                else
                {
                    if (refLetters.Contains(playerWord[i]))
                    {
                        letterResults[i] = LetterState.WrongPosition;
                        refLetters.Remove(playerWord[i]);
                    }
                    else
                    {
                        letterResults[i] = LetterState.Incorrect;
                    }
                }
            }

            return letterResults;
        }
    }

    public enum LetterState
    {
        Correct, Incorrect, WrongPosition
    }
}
