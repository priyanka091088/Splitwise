import { User } from './user.model';

export interface Groups{
  groupId :number;
  groupName :string;
  groupType :string;
  creatorId :string;
  creator? :User
}
