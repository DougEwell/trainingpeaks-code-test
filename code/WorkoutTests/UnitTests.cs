using dotnet.Calculations;
using dotnet.Entities;
using dotnet.Helpers;

namespace WorkoutTests
{
    public class UnitTests
    {
        public UnitTests()
        {
        }

        private static void GetValidData(out User[]? users, out Exercise[]? exercises, out Workout[]? workouts)
        {
            var userPath = Path.Combine("../../../TestData", "Users-valid.json");
            users = Helpers.Deserialize<User[]>(File.ReadAllText(userPath));
            var exercisePath = Path.Combine("../../../TestData", "Exercises-valid.json");
            exercises = Helpers.Deserialize<Exercise[]>(File.ReadAllText(exercisePath));
            var workoutPath = Path.Combine("../../../TestData", "Workouts-valid.json");
            workouts = Helpers.DeserializeWithOptions<Workout[]>(File.ReadAllText(workoutPath));
        }

        [Theory]
        [InlineData("Users-valid.json", true)]
        [InlineData("Users-invalid.json", false)]
        public void LoadUserData_ValidAndInvalidFile_ShouldReturnExpectedResult(string filename, bool expectSuccess)
        {
            var path = Path.Combine("../../../TestData", filename);
            var users = Helpers.Deserialize<User[]>(File.ReadAllText(path));
            Assert.Equal(expectSuccess, users?.Length > 0);
        }

        [Theory]
        [InlineData("Exercises-valid.json", true)]
        [InlineData("Exercises-invalid.json", false)]
        public void LoadExerciseData_ValidAndInvalidFile_ShouldReturnExpectedResult(string filename, bool expectSuccess)
        {
            var path = Path.Combine("../../../TestData", filename);
            var exercises = Helpers.Deserialize<Exercise[]>(File.ReadAllText(path));
            Assert.Equal(expectSuccess, exercises?.Length > 0);
        }

        [Theory]
        [InlineData("Workouts-valid.json", true)]
        [InlineData("Workouts-invalid.json", false)]
        public void LoadWorkoutData_ValidAndInvalidFile_ShouldReturnExpectedResult(string filename, bool expectSuccess)
        {
            var path = Path.Combine("../../../TestData", filename);
            var workouts = Helpers.DeserializeWithOptions<Workout[]>(File.ReadAllText(path));
            Assert.Equal(expectSuccess, workouts?.Length > 0);
        }

        [Fact]
        public void CalculateTotalWeightByExercise_ValidData_ShouldReturnExpectedResult()
        {
            GetValidData(out var users, out var exercises, out var workouts);
            Assert.NotNull(users);
            Assert.NotNull(exercises);
            Assert.NotNull(workouts);

            var totalWeight = Calculations.GetTotalWeightByExercise(
                workouts,
                Exercise.GetExerciseByTitle(exercises, "Grocery Bag Lift"));

            Assert.Equal(95, totalWeight);
        }

        [Fact]
        public void CalculateTotalWeightByUserAndExerciseAndYear_ValidData_ShouldReturnExpectedResult()
        {
            GetValidData(out var users, out var exercises, out var workouts);
            Assert.NotNull(users);
            Assert.NotNull(exercises);
            Assert.NotNull(workouts);

            var totalWeight = Calculations.GetTotalWeightByUserAndExerciseAndYear(
                workouts,
                User.GetUserByName(users, "Christopher", "Zappitello"),
                Exercise.GetExerciseByTitle(exercises, "Trash Bag Jerk"),
                2025);

            Assert.Equal(80, totalWeight);
        }

        [Fact]
        public void CalculateMonthOfMaxTotalWeightByUserAndExerciseAndYear_ValidData_ShouldReturnExpectedResult()
        {
            GetValidData(out var users, out var exercises, out var workouts);
            Assert.NotNull(users);
            Assert.NotNull(exercises);
            Assert.NotNull(workouts);

            var highestMonth = Calculations.GetMonthOfMaxTotalWeightByUserAndExerciseAndYear(
                workouts,
                User.GetUserByName(users, "Doug", "Ewell"),
                Exercise.GetExerciseByTitle(exercises, "Grocery Bag Lift"),
                2025);

            Assert.Equal("January", highestMonth);
        }

        [Fact]
        public void CalculateMaxWeightByUserAndExercise_ValidData_ShouldReturnExpectedResult()
        {
            GetValidData(out var users, out var exercises, out var workouts);
            Assert.NotNull(users);
            Assert.NotNull(exercises);
            Assert.NotNull(workouts);

            var totalWeight = Calculations.GetMaxWeightByUserAndExercise(
                workouts,
                User.GetUserByName(users, "Katherine", "Barnett"),
                Exercise.GetExerciseByTitle(exercises, "Laundry Basket Press"));

            Assert.Equal(25, totalWeight);
        }
    }
}