using dotnet.Calculations;
using dotnet.Entities;
using dotnet.Helpers;
using System.Text.Json;

// Load data
var users = Helpers.Deserialize<User[]>(File.ReadAllText("../../data/users.json"));
var exercises = Helpers.Deserialize<Exercise[]>(File.ReadAllText("../../data/exercises.json"));
var workouts = Helpers.DeserializeWithOptions<Workout[]>(File.ReadAllText("../../data/workouts.json"));

if (users is null || exercises is null || workouts is null)
{
    Console.Error.WriteLine("One or more data files were not found.");
    return;
}

/** Candidate TODO: Write code to answer questions **/

// In total, how many pounds have these athletes Bench Pressed?
var answerOne = Calculations.GetTotalWeightByExercise(
    workouts,
    Exercise.GetExerciseByTitle(exercises, "Bench Press"));

// How many pounds did Barry Moore Back Squat in 2016?
var answerTwo = Calculations.GetTotalWeightByUserAndExerciseAndYear(
    workouts,
    User.GetUserByName(users, "Barry", "Moore"),
    Exercise.GetExerciseByTitle(exercises, "Back Squat"),
    2016);

// In what month of 2017 did Barry Moore Back Squat the most total weight?
var answerThree = Calculations.GetMonthOfMaxTotalWeightByUserAndExerciseAndYear(
    workouts,
    User.GetUserByName(users, "Barry", "Moore"),
    Exercise.GetExerciseByTitle(exercises, "Back Squat"),
    2017);

// What is Abby Smith's Bench Press PR weight?
// (PR defined as the most the person has ever lifted for that exercise, regardless of reps performed.)
var answerFour = Calculations.GetMaxWeightByUserAndExercise(
    workouts,
    User.GetUserByName(users, "Abby", "Smith"),
    Exercise.GetExerciseByTitle(exercises, "Bench Press"));

var results = new Dictionary<string, string> {
    {"Q1", answerOne.ToString()},
    {"Q2", answerTwo.ToString()},
    {"Q3", answerThree},
    {"Q4", answerFour.ToString()}
};

Console.WriteLine(JsonSerializer.Serialize(results));
