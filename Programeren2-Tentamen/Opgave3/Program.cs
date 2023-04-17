using System;
using System.Collections.Generic;
using System.IO;

namespace Opgave3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            List<StateResult> stateResult = ReadStateResults("2020-votes.csv");
            if (stateResult == 0)
            {
                Console.WriteLine("No StateResults!");
                return;
            }
            List<StateElectors> stateElectors = ReadStateElectors("2020-electors.csv");
            if (stateElectors == 0)
            {
                Console.WriteLine("No StateElectors!");
                return;
            }
            Console.WriteLine("number of StateResults read: {1} \nnumber of StateElectors read: {1}\n", stateResult.Count, stateElectors.Count);
        }

        List<StateResult> ReadStateResults(string filename)
        {
            List<StateResult> stateResults = new List<StateResult>();

            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(';');
                    StateResult result = new StateResult();
                    result.StateName = data[0];
                    result.CandidateName = data[1];
                    result.PartyName = data[2];
                    result.CandidateVotes = int.Parse(data[3]);
                    stateResults.Add(result);
                }
                reader.Close();
            }
            return stateResults;
        }

        List<StateElectors> ReadStateElectors(string filename)
        {
            List<StateElectors> stateElectors = new List<StateElectors>();

            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(';');
                    StateElectors stateEletor = new StateElectors();
                    stateEletor.StateName = data[0];
                    stateEletor.ElectorsCount = int.Parse(data[1]);
                    stateElectors.Add(stateEletor);
                }
                reader.Close();
            }
            return stateElectors;
        }

        void DisplayStateResults(List<StateResult> results)
        {
            foreach (StateResult result in results)
            {
                Console.WriteLine("{0, -3}: {1} ({2}), {3} votes", result.StateName, result.CandidateName, result.PartyName, result.CandidateVotes);
            }
        }

        string WinnerOfState(List<StateResult> stateResults, string stateName)
        {
            int tempVotesOfState = 0;
            foreach (StateResult stateres in stateResults)
            {
                if(stateres.StateName == stateName)
                {
                    tempVotesOfState += stateres.CandidateVotes;
                }
            }
        }
    }
}
