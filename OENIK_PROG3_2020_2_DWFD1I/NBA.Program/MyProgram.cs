// <copyright file="MyProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Program
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ConsoleTools;
    using NBA.Data;
    using NBA.Logic;
    using NBA.Repository;

    /// <summary>
    /// Main Class of the Console App.
    /// </summary>
    /// just added the *internal* access modifier.
    internal class MyProgram
    {
        /// <summary>
        /// The main class of the one and only console application.
        /// </summary>
        private static void Main()
        {
            NBAdbContext ctx = new NBAdbContext();
            PlayerRepository playerRepo = new PlayerRepository(ctx);
            CoachRepository coachRepo = new CoachRepository(ctx);
            TeamRepository teamRepo = new TeamRepository(ctx);
            TeamManagerLogic teamManagerLogic = new TeamManagerLogic(playerRepo, coachRepo);
            FinancialOfficerLogic financialOfficerLogic = new FinancialOfficerLogic(playerRepo, coachRepo);
            NbaSecretaryLogic nbaSecretaryLogic = new NbaSecretaryLogic(teamRepo, playerRepo);

            var menu = new ConsoleMenu()
                .Add("The list of all players", () => ListAllPlayers(teamManagerLogic))
                .Add("The data of one player", () => GetOnePlayer(teamManagerLogic, nbaSecretaryLogic))
                .Add("Insert a player", () => InsertPlayer(teamManagerLogic, nbaSecretaryLogic))
                .Add("Remove a player", () => RemovePlayer(teamManagerLogic))
                .Add("Change a player's salary", () => ChangePlayerSalary(financialOfficerLogic))
                .Add("The Average salary of the players in each conference", () => GetPlayersAvgSalary(financialOfficerLogic))
                .Add("The Average salary of the players in each conference *Async Version*", () => GetPlayersAvgSalaryAsync(financialOfficerLogic))
                .Add("The Average Team's height", () => GetPlayersAvgHeight(nbaSecretaryLogic))
                .Add("The Average Team's height *Async version*", () => GetPlayersAvgHeightAsync(nbaSecretaryLogic))
                .Add("The list of all coaches", () => ListAllCoaches(teamManagerLogic))
                .Add("The data of one coach", () => GetOneCoach(teamManagerLogic))
                .Add("Insert a coach", () => InsertCoach(teamManagerLogic))
                .Add("Remove a coach", () => RemoveCoach(teamManagerLogic))
                .Add("Change a coach's salary", () => ChangeCoachSalary(financialOfficerLogic))
                .Add("The list of all teams", () => GetAllTeams(nbaSecretaryLogic))
                .Add("The data of one team", () => GetOneTeam(nbaSecretaryLogic))
                .Add("Insert a team", () => InsertTeam(nbaSecretaryLogic))
                .Add("Remove a team", () => RemoveTeam(nbaSecretaryLogic))
                .Add("Change the number of championships won by a team", () => ChangeNumChamps(nbaSecretaryLogic))
                .Add("The Average field goal of each team", () => GetTeamsAvgFieldGoal(nbaSecretaryLogic))
                .Add("The Average field goal of each team *Async version*", () => GetTeamsAvgFieldGoalAsync(nbaSecretaryLogic))
                .Add("Quit", ConsoleMenu.Close);
            menu.Show();

            Console.ReadLine();
        }

        private static void GetTeamsAvgFieldGoal(NbaSecretaryLogic tmLogic)
        {
            foreach (var item in tmLogic.GetFGAveragesResults())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void ListAllPlayers(TeamManagerLogic tmLogic)
        {
            foreach (var item in tmLogic.GetAllPlayers())
            {
                Console.WriteLine("Id: " + item.PlayerId + " - Name: " + item.PlayerName);
            }

            Console.ReadLine();
        }

        private static void GetOnePlayer(TeamManagerLogic tmLogic, NbaSecretaryLogic nbaSecretaryLogic)
        {
            Console.Write("Insert the ID of the player that you would like to get: ");
            int num = int.Parse(Console.ReadLine());
            if (tmLogic.GetOnePlayer(num) != null)
            {
                Console.WriteLine("Id: " + tmLogic.GetOnePlayer(num).PlayerId);
                Console.WriteLine("Name: " + tmLogic.GetOnePlayer(num).PlayerName);
                Console.WriteLine("Age: " + tmLogic.GetOnePlayer(num).PlayerAge);
                Console.WriteLine("Height: " + tmLogic.GetOnePlayer(num).PlayerHeight);
                Console.WriteLine("Weight: " + tmLogic.GetOnePlayer(num).PlayerWeight);
                Console.WriteLine("Draft Date: " + tmLogic.GetOnePlayer(num).PlayerDraftDate);
                Console.WriteLine("Position: " + tmLogic.GetOnePlayer(num).PlayerPosition);
                Console.WriteLine("Salary: " + tmLogic.GetOnePlayer(num).PlayerSalary);
                Console.WriteLine("Field Goal(%): " + tmLogic.GetOnePlayer(num).PlayerFieldGoal);
                Team team = nbaSecretaryLogic.GetOneTeam(tmLogic.GetOnePlayer(num).PlayerTeam);
                Console.WriteLine("Team: " + team.TeamName);
            }
            else
            {
                Console.WriteLine("This player's id is invalid.");
            }

            Console.ReadLine();
        }

        private static void InsertPlayer(TeamManagerLogic tmLogic, NbaSecretaryLogic nbaSecretaryLogic)
        {
            Console.WriteLine("Give the following data:\n");

            Console.Write("String Name: ");
            string name = Console.ReadLine();
            Console.Write("int Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("String Position: ");
            string position = Console.ReadLine();
            Console.Write("double height: ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("double weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("int salary: ");
            int salary = int.Parse(Console.ReadLine());
            Console.Write("double Field Goal: ");
            double fg = double.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach (Team item in nbaSecretaryLogic.GetAllTeams())
            {
                Console.WriteLine("Id: " + item.TeamId + " - Name: " + item.TeamName);
            }

            Console.Write("\nThe id of the player's team: ");
            int teamId = int.Parse(Console.ReadLine());

            int id = 1;
            while (tmLogic.GetOnePlayer(id) != null)
            {
                id++;
            }

            tmLogic.InsertPlayer(new Player()
            {
                PlayerId = id,
                PlayerName = name,
                PlayerAge = age,
                PlayerPosition = position,
                PlayerHeight = height,
                PlayerWeight = weight,
                PlayerSalary = salary,
                PlayerFieldGoal = fg,
                PlayerDraftDate = DateTime.Now,
                PlayerTeam = teamId,
            });
        }

        private static void RemovePlayer(TeamManagerLogic tmLogic)
        {
            Console.WriteLine("What is the id of the player that you would like to delete: ");
            int id = int.Parse(Console.ReadLine());

            Player playerToDelete = tmLogic.GetOnePlayer(id);
            tmLogic.RemovePlayer(playerToDelete);
        }

        private static void GetOneCoach(TeamManagerLogic tmLogic)
        {
            Console.Write("Insert the ID of the caoch that you would like to get: ");
            int num = int.Parse(Console.ReadLine());
            if (tmLogic.GetOneCoach(num) != null)
            {
                Console.WriteLine("Id: " + tmLogic.GetOneCoach(num).CoachId);
                Console.WriteLine("Name: " + tmLogic.GetOneCoach(num).CoachName);
                Console.WriteLine("Age: " + tmLogic.GetOneCoach(num).CoachAge);
                Console.WriteLine("Type: " + tmLogic.GetOneCoach(num).CoachType);
                Console.WriteLine("Salary: " + tmLogic.GetOneCoach(num).CoachSalary);
                Console.WriteLine("Hire Date: " + tmLogic.GetOneCoach(num).CoachHireDate);
                Console.WriteLine("Years of Experience: " + tmLogic.GetOneCoach(num).CoachYearsOfExperience);
                Console.WriteLine("Email: " + tmLogic.GetOneCoach(num).CoachEmail);
            }
            else
            {
                Console.WriteLine("This coach's id is invalid.");
            }

            Console.ReadLine();
        }

        private static void ListAllCoaches(TeamManagerLogic tmLogic)
        {
            foreach (var item in tmLogic.GetAllCoaches())
            {
                Console.WriteLine("Id: " + item.CoachId + " - Name: " + item.CoachName);
            }

            Console.ReadLine();
        }

        private static void RemoveCoach(TeamManagerLogic tmLogic)
        {
            Console.WriteLine("What is the id of the player that you would like to delete: ");
            int id = int.Parse(Console.ReadLine());

            Coach coachToDelete = tmLogic.GetOneCoach(id);
            tmLogic.RemoveCoach(coachToDelete);
        }

        private static void InsertCoach(TeamManagerLogic tmLogic)
        {
            Console.WriteLine("To hire a new coach, provide his data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Type: ");
            string type = Console.ReadLine();
            Console.Write("Years of Experience: ");
            int years = int.Parse(Console.ReadLine());
            Console.Write("Salary: ");
            int salary = int.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();

            int id = 1;
            while (tmLogic.GetOneCoach(id) != null)
            {
                id++;
            }

            tmLogic.InsertCoach(new Coach()
            {
                CoachId = id,
                CoachName = name,
                CoachAge = age,
                CoachType = type,
                CoachHireDate = DateTime.Now,
                CoachYearsOfExperience = years,
                CoachSalary = salary,
                CoachEmail = email,
            });
        }

        private static void ChangePlayerSalary(FinancialOfficerLogic foLogic)
        {
            Console.Write("The id of the player you want to make changes on the salary: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("The new salary: ");
            int salary = int.Parse(Console.ReadLine());

            if (foLogic.GetOnePlayer(id) != null)
            {
                foLogic.ChangePlayerSalary(id, salary);
            }
            else
            {
                Console.WriteLine("This player's id is invalid.");
            }
        }

        private static void ChangeCoachSalary(FinancialOfficerLogic foLogic)
        {
            Console.Write("The id of the coach you want to make changes on the salary: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("The new salary: ");
            int salary = int.Parse(Console.ReadLine());

            if (foLogic.GetOneCoach(id) != null)
            {
                foLogic.ChangeCoachSalary(id, salary);
            }
            else
            {
                Console.WriteLine("This player's id is invalid.");
            }
        }

        private static void GetAllTeams(NbaSecretaryLogic nbaSecretaryLogic)
        {
            foreach (Team item in nbaSecretaryLogic.GetAllTeams())
            {
                Console.WriteLine("Id: " + item.TeamId + " - Name: " + item.TeamName);
            }

            Console.ReadLine();
        }

        private static void GetOneTeam(NbaSecretaryLogic nbaSecretaryLogic)
        {
            Console.Write("Insert the ID of the caoch that you would like to get: ");
            int num = int.Parse(Console.ReadLine());

            if (nbaSecretaryLogic.GetOneTeam(num) != null)
            {
                Console.WriteLine("Id: " + nbaSecretaryLogic.GetOneTeam(num).TeamId);
                Console.WriteLine("Name: " + nbaSecretaryLogic.GetOneTeam(num).TeamName);
                Console.WriteLine("Conference: " + nbaSecretaryLogic.GetOneTeam(num).TeamConference);
                Console.WriteLine("Championships won: " + nbaSecretaryLogic.GetOneTeam(num).TeamChampionshipsWon);
                Console.WriteLine("Arena: " + nbaSecretaryLogic.GetOneTeam(num).TeamArena);
                Console.WriteLine("Foundation Date: " + nbaSecretaryLogic.GetOneTeam(num).TeamFoundationDate);
            }
            else
            {
                Console.WriteLine("This team's id is invalid.");
            }

            Console.ReadLine();
        }

        private static void InsertTeam(NbaSecretaryLogic nbaSecretaryLogic)
        {
            Console.WriteLine("To register your team, provide the following data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Conference: ");
            string conference = Console.ReadLine();
            Console.Write("Championships won: ");
            int champs = int.Parse(Console.ReadLine());
            Console.Write("Arena: ");
            string arena = Console.ReadLine();

            int id = 1;
            while (nbaSecretaryLogic.GetOneTeam(id) != null)
            {
                id++;
            }

            nbaSecretaryLogic.InsertOneTeam(new Team()
            {
                TeamId = id,
                TeamName = name,
                TeamConference = conference,
                TeamChampionshipsWon = champs,
                TeamArena = arena,
                TeamFoundationDate = DateTime.Now,
            });
        }

        private static void RemoveTeam(NbaSecretaryLogic nbaSecretaryLogic)
        {
            Console.WriteLine("What is the id of the player that you would like to delete: ");
            int id = int.Parse(Console.ReadLine());

            Team teamToDelete = nbaSecretaryLogic.GetOneTeam(id);
            nbaSecretaryLogic.RemoveTeam(teamToDelete);
        }

        private static void ChangeNumChamps(NbaSecretaryLogic nbaSecretaryLogic)
        {
            Console.Write("The id of the team you want to make changes on the number of Championships won: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("The new number of championships: ");
            int num = int.Parse(Console.ReadLine());

            if (nbaSecretaryLogic.GetOneTeam(id) != null)
            {
                nbaSecretaryLogic.ChangeNumberOfChampionships(id, num);
            }
            else
            {
                Console.WriteLine("This player's id is invalid.");
            }
        }

        private static void GetPlayersAvgSalary(FinancialOfficerLogic financialOfficerLogic)
        {
            foreach (AvgPlayerSalary item in financialOfficerLogic.GetAvgPlayerSalaries())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void GetPlayersAvgHeight(NbaSecretaryLogic nbaSecretaryLogic)
        {
            foreach (AvgPLayerHeight item in nbaSecretaryLogic.GetAvgPlayerHeight())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void GetPlayersAvgSalaryAsync(FinancialOfficerLogic financialOfficerLogic)
        {
            foreach (var item in financialOfficerLogic.GetAvgPlayerSalariesAsync().Result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void GetTeamsAvgFieldGoalAsync(NbaSecretaryLogic nbaSecretaryLogic)
        {
            foreach (var item in nbaSecretaryLogic.GetFGAveragesResultsAsync().Result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void GetPlayersAvgHeightAsync(NbaSecretaryLogic nbaSecretaryLogic)
        {
            foreach (var item in nbaSecretaryLogic.GetAvgPlayerHeightAsync().Result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
