import { User } from './user.model';

export interface Friends{
  Id :number;
  Balance :number;
  creatorId :string;
  friendId :string;
  creator? :User;
  users? :User;
}
