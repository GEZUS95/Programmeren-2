namespace assignment2
{
    class HangmanGame
    {
        public string secretWord;
        public string guessedWord;

        public void Init(string secretWord)
        {
            this.secretWord = secretWord;
            for (int i = 0; i < secretWord.Length; i++)
            {
                guessedWord += ".";
            }
        }

        public bool ContainsLetter(char letter)
        {
            if (secretWord.Contains(letter)) return true;
            return false;
        }

        public bool ProcessLetter(char letter)
        {
            string tmp = "";
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == letter)
                {
                    tmp += letter;
                }
                else if (guessedWord[i] != '.')
                {
                    tmp += guessedWord[i];
                }
                else
                {
                    tmp += ".";
                }
            }

            guessedWord = tmp;
            return true;
        }

        public bool IsGuessed()
        {
            if (guessedWord == secretWord)
            {
                return true;
            }
            return false;
        }
    }
}
