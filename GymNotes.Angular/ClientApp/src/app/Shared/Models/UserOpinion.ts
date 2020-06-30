import { User } from './User';
export class UserOpinion {
  id: Number;
  dateAdded: Date;
  rating: Number;
  opinionMessage: string;
  profileUser: User;
}
