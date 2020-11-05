import { Groups } from './groups.model';
import { User } from './user.model';

export interface GroupMembers{
  memberId :number;
  groupId :number;
  userId :string;
  groups? :Groups;
  users? :User;
}
