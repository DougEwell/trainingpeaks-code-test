using dotnet.Entities;

namespace dotnet.Calculations
{
    public partial class Calculations
    {
        /// <summary>
        /// Retrieves the total weight lifted by all users in all exercises in the entire workout data set.
        /// </summary>
        /// <param name="workouts">Array of workouts for all users.</param>
        /// <param name="exercise">Exercise object.</param>
        /// <returns>Total weight (pounds).</returns>
        public static int GetTotalWeightByExercise(Workout[] workouts, Exercise? exercise)
        {
            var totalWeight = workouts
                .SelectMany(w => w.Blocks!)
                .Where(b => b.ExerciseID == exercise?.ID)
                .SelectMany(b => b.Sets!)
                .Sum(s => s.Reps * s.Weight ?? 0);

            return totalWeight;
        }

        /// <summary>
        /// Retrieves the total weight lifted by the specified user in the specified exercise and calendar year.
        /// </summary>
        /// <param name="workouts">Array of workouts for all users.</param>
        /// <param name="user">User object.</param>
        /// <param name="exercise">Exercise object.</param>
        /// <param name="year">Calendar year.</param>
        /// <returns>Total weight (pounds).</returns>
        public static int GetTotalWeightByUserAndExerciseAndYear(Workout[] workouts, User? user, Exercise? exercise, int year)
        {
            var totalWeight = workouts
                .Where(w => w.UserID == user?.ID
                    && w.DateTimeCompleted.Year == year)
                .SelectMany(w => w.Blocks!)
                .Where(b => b.ExerciseID == exercise?.ID)
                .SelectMany(b => b.Sets!)
                .Sum(s => s.Reps * s.Weight ?? 0);

            return totalWeight;
        }
    }
}
