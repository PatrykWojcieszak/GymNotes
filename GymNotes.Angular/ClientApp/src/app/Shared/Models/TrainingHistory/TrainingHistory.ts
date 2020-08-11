import { PlannedTraining } from './PlannedTraining';
import { TrainingExercise } from './../Training/TrainingExercise';
import { User } from './../User';

export class TrainingHistory {
  id: number;
  isCustomTraining: boolean;
  date: Date;
  workoutName: string;
  userId: string;
  user: User
  trainingExercise: TrainingExercise[];
  plannedTrainingId: number;
  plannedTraining: PlannedTraining;
}
