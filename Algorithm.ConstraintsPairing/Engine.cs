﻿using Algorithm.ConstraintsPairing.Model;
using Google.OrTools.LinearSolver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algorithm.ConstraintsPairing
{
    public class Engine
    {
        private Solver _solver;

        public Engine()
            : this("SCIP")
        {
            // intentionally left blank
        }

        public Engine(string solverType)
        {
            _solver = Solver.CreateSolver(solverType);
        }

        public async Task<OutputDataSummary> CalculateAsync(InputData input)
        {
            try
            {
                var variables = CreateVariables(input);
                
                CreateConstraints(input, variables);
                CreateObjectiveFunction(input, variables);

                Solver.ResultStatus resultStatus = _solver.Solve();

                return new OutputDataSummary()
                {
                    IsError = resultStatus != Solver.ResultStatus.OPTIMAL && resultStatus != Solver.ResultStatus.FEASIBLE ? true : false,
                    Reason = string.Empty,
                    Data = new OutputData()
                    {
                        Status = resultStatus,
                        Variables = variables,
                        Input = input,
                        Pairs = ToPairs(resultStatus, variables, input.GifterAmount)
                    }
                };
            }
            catch (Exception ex)
            {
                return new OutputDataSummary()
                {
                    IsError = true,
                    Reason = ex.Message,
                    Data = new OutputData()
                    {
                        Status = Solver.ResultStatus.NOT_SOLVED,
                        Input = input,
                    }
                };
            }
        }

        private Pair[] ToPairs(Solver.ResultStatus status, Variable[,] variables, int gifterAmount)
        {
            var result = new List<Pair>();

            if (status == Solver.ResultStatus.OPTIMAL || status == Solver.ResultStatus.FEASIBLE)
            {
                for (int i = 0; i < gifterAmount; ++i)
                {
                    for (int j = 0; j < gifterAmount; ++j)
                    {
                        if (variables[i, j].SolutionValue() > 0.5)
                        {
                            result.Add(
                                new Pair()
                                {
                                    FromIndex = i,
                                    ToIndex = j
                                });
                        }
                    }
                }
            }

            return result.ToArray();
        }

        private Variable[,] CreateVariables(InputData input)
        {
            Variable[,] x = new Variable[input.GifterAmount, input.GifterAmount];
            for (int i = 0; i < input.GifterAmount; ++i)
            {
                for (int j = 0; j < input.GifterAmount; ++j)
                {
                    if(i == j)
                    {
                        x[i, j] = _solver.MakeIntVar(0, 0, $"No assignment to yourself");
                    } else if(input.Costs[i,j] == 100)
                    {
                        x[i, j] = _solver.MakeIntVar(0, 0, $"No assignment when the participant is excluded");
                    }
                    else
                    {
                        x[i, j] = _solver.MakeIntVar(0, 1, $"gifter_{i}_participant_{j}");
                    }
                }
            }

            return x;
        }

        private void CreateConstraints(InputData input, Variable[,] variables)
        {
            try
            {
                for (int i = 0; i < input.GifterAmount; ++i)
                {
                    Constraint constraint1 = _solver.MakeConstraint(0, 1, "");
                    for (int j = 0; j < input.GifterAmount; ++j)
                    {
                        constraint1.SetCoefficient(variables[i, j], 1);
                    }
                }

                for (int j = 0; j < input.GifterAmount; ++j)
                {
                    Constraint constraint2 = _solver.MakeConstraint(1, 1, "");
                    for (int i = 0; i < input.GifterAmount; ++i)
                    {
                        constraint2.SetCoefficient(variables[i, j], 1);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateObjectiveFunction(InputData input, Variable[,] variables)
        {
            try
            {
                Objective objective = _solver.Objective();

                for (int i = 0; i < input.GifterAmount; ++i)
                {
                    for (int j = 0; j < input.GifterAmount; ++j)
                    {
                        objective.SetCoefficient(variables[i, j], input.Costs[i, j]);
                    }
                }

                objective.SetMinimization();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
