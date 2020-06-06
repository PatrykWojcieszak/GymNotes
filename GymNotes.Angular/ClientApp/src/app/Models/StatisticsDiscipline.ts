import { StatisticsExercise } from "./StatisticsExcercise";

export class StatisticsDiscipline {
  name: string;
  exerciseArray: Array<StatisticsExercise> = [];
  newAttribute: any = {};

  constructor(name: string, exerciseArray: Array<StatisticsExercise>) {
    this.name = name;
    this.exerciseArray = exerciseArray;
  }

  addExercise(exercise: StatisticsExercise) {
    this.exerciseArray.push(exercise);
  }

  deleteFieldValue(index) {
    this.exerciseArray.splice(index, 1);
  }

  addFieldValue() {
    this.exerciseArray.push(
      new StatisticsExercise(this.newAttribute.name, this.newAttribute.value)
    );
    this.newAttribute = {};
  }

  getName() {
    return this.name;
  }

  getExerciseList() {
      return this.exerciseArray;
  }
}
