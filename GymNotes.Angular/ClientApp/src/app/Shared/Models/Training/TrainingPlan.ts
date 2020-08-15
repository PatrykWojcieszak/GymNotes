import { TrainingWeek } from './TrainingWeek';
import { User } from '../User';

export interface TrainingPlan {
	name: string;
	description: string;
	trainingWeeks: TrainingWeek[];
	owner: User;
	creator: User;
	modifiedAt: Date;
	id: number;
	isMain: boolean;
	isFavorite: boolean;
}
