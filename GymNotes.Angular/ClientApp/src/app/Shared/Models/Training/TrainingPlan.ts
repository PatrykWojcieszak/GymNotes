import { TrainingWeek } from './TrainingWeek';

export interface TrainingPlan {
  Name: string;
  Description: string;
  TrainingWeek: TrainingWeek[];
}
