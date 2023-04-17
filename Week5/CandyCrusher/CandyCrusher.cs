namespace CandyCrusherLogic
{
    public class CandyCrusher
    {
        public static bool ScoreRowPresent(int[,] playingField)
        {
            for (int r = 0; r < playingField.GetLength(0); r++)
            {
                int count = 0;
                int candy = 0;
                for (int k = 0; k < playingField.GetLength(1); k++)
                {
                    if (candy == playingField[r, k])
                    {
                        count++;
                    }
                    else
                    {
                        candy = playingField[r, k];
                        count = 1;
                    }
                    if (count >= 3)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public static bool ScoreColumnPresent(int[,] playingField)
        {
            for (int k = 0; k < playingField.GetLength(1); k++)
            {
                int count = 0;
                int candy = 0;
                for (int r = 0; r < playingField.GetLength(0); r++)
                {
                    if (candy == playingField[r, k])
                    {
                        count++;
                    }
                    else
                    {
                        candy = playingField[r, k];
                        count = 1;
                    }
                    if (count >= 3)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
    }
}
