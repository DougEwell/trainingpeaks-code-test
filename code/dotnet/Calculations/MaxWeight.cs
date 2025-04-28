using dotnet.Entities;
using System.Globalization;

namespace dotnet.Calculations
{
    public partial class Calculations
    {
        /// <summary>
        /// Retrieves the name of the month within the specified year when the user lifted the most total weight in the specified exercise.
        /// </summary>
        /// <param name="workouts">Array of workouts for all users.</param>
        /// <param name="user">User object.</param>
        /// <param name="exercise">Exercise object.</param>
        /// <param name="year">Calendar year.</param>
        /// <returns>Localized name of the month.</returns>
        public static string GetMonthOfMaxTotalWeightByUserAndExerciseAndYear(Workout[] workouts, User? user, Exercise? exercise, int year)
        {
            var bestMonth = workouts
                .Where(w => w.UserID == user?.ID
                    && w.DateTimeCompleted.Year == year)
                .GroupBy(w => w.DateTimeCompleted.Month)
                .MaxBy(m => m
                    .SelectMany(m => m.Blocks!)
                    .Where(b => b.ExerciseID == exercise?.ID)
                    .SelectMany(b => b.Sets!)
                    .Sum(s => s.Reps * s.Weight ?? 0));

            return new DateTime(year, bestMonth!.Key, 1)
                .ToString("MMMM", CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Retrieves the maximum weight that the specified user has ever lifted in the specified exercise (personal record).
        /// </summary>
        /// <param name="workouts">Array of workouts for all users.</param>
        /// <param name="user">User object.</param>
        /// <param name="exercise">Exercise object.</param>
        /// <returns>Maximum weight (pounds).</returns>
        public static int GetMaxWeightByUserAndExercise(Workout[] workouts, User? user, Exercise? exercise)
        {
            var maxWeight = workouts
                .Where(w => w.UserID == user?.ID)
                .SelectMany(w => w.Blocks!)
                .Where(b => b.ExerciseID == exercise?.ID)
                .SelectMany(b => b.Sets!)
                .Max(s => s.Weight ?? 0);

            return maxWeight;
        }
    }
}
