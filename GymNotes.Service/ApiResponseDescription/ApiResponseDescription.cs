using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service
{
  public static class ApiResponseDescription
  {
    public const string USER_NOT_FOUND = "User not found";
    public const string TOKEN_IS_NO_LONGER_VALID = "User token is no longer valid";
    public const string OPINION_NOT_FOUND = "Opinions not found";
    public const string ACHIEVEMENT_DYSCYPLINE_NOT_FOUND = "Achievement dyscypline not found";
    public const string ACHIEVEMENT_NOT_FOUND = "Achievement not found";
    public const string EMAIL_ADDRESS_COULD_NOT_BE_CONFIRMED = "Email address could not be confirmed!";
    public const string EMAIL_ADDRESS_IS_NOT_CONFIRMED = "Email address is not confirmed!";
    public const string INCORECT_EMAIL = "Incorrect email address.";
    public const string INCORECT_PAASWORD = "Incorrect password. Please try again or click 'Forgot password' to reset it.";
    public const string EMAIL_ALREADY_IN_USE = "Email already in use.";

    public const string TRAINING_PLAN_NOT_FOUND = "Training plan not found.";
    public const string TRAINING_WEEK_NOT_FOUND = "Training week not found.";

    public const string WORKOUT_HISTORY_NOT_FOUND = "Workout history not found.";
  }
}